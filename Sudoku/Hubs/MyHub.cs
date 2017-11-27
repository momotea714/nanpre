using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Sudoku.Hubs
{
    [HubName("myHub")]
    public class MyHub : Hub
    {
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
            Clients.All.InputNumber(id, number);
        }
        /// <summary>
        /// 数字を入力した際に発火
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        public void InputNumber(string id, string number,string groupName)
        {
            //Biz.Utility.WriteLog("InputNumber id:" + id + "number:" + number + "groupName:" + groupName);
            //Clients.All.InputNumber(id, number);
            Clients.Group(groupName).inputNumber(id, number);
        }
        // 指定されたグループへ参加する
        public void Join(string groupName)
        {
            //Biz.Utility.WriteLog("Join groupName:" + groupName);
            Groups.Add(Context.ConnectionId, groupName);
        }


        // 指定されたグループから離脱する
        public void Leave(string groupName)
        {
            Groups.Remove(Context.ConnectionId, groupName);
        }

        // 指定されたグループに参加しているクライアントへメッセージを送信する
        public void Send(string groupName, string text)
        {
            Clients.Group(groupName).Receive(text);
        }
    }
}