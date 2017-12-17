using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Sudoku.Biz;
using Sudoku.Models;
using System;
using System.Linq;

namespace Sudoku.Hubs
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
        private MomoDBContext db = new MomoDBContext();

        /// <summary>
        /// td要素クリック時に発火
        /// </summary>
        /// <param name="id"></param>
        public void SelectTd(string id)
        {
            Clients.Caller.SelectTd(id);
        }
        /// <summary>
        /// 数字を入力した際に発火
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        public void InputNumber(string id, string number)
        {
            //Biz.Utility.WriteLog("InputNumber id:" + id + "number:" + number);
            Clients.All.inputNumber(id, number);
        }
        /// <summary>
        /// 数字を入力した際に発火
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        public void InputNumber(string id, string number, string groupName)
        {
            Clients.Group(groupName).inputNumber(id, number, Context.ConnectionId);

            var momo_id = int.Parse(groupName.Replace("nngo", ""));
            id = id.Replace(@"#trout", "");
            var index = int.Parse(id) - 10 - int.Parse(id.Substring(0, 1));
            using (var momoDB = new MomoDBContext())
            {
                var hoge = momoDB.MomoStates.FirstOrDefault(x => x.Momo_ID == momo_id);
                if (hoge == null) return;

                hoge.CurrentNanpre = hoge.CurrentNanpre.ChangeCharAt(index, number);
                momoDB.SaveChanges();
            }
        }
        // 指定されたグループへ参加する
        public void Join(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            Clients.Group(groupName).joinNotify(Context.ConnectionId);
        }

        // 指定されたグループから離脱する
        public void Leave(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        // 指定されたグループに参加しているクライアントへメッセージを送信する
        public void Send(string momo_id,string displayName, string message)
        {
            var talk = new Talk
            {
                Momo_ID = int.Parse(momo_id),
                DisplayName = displayName,
                Message = message,
                CreatedDateTime = DateTime.Now,
                SenderUser_ID = Context.ConnectionId
            };

            db.Talks.Add(talk);
            db.SaveChanges();

            Clients.Group("nngo" + momo_id).Receive(talk, talk.CreatedDateTime.ToShortDateString() + " " + talk.CreatedDateTime.ToShortTimeString());
        }
    }
}