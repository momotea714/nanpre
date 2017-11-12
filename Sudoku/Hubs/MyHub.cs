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
            Clients.All.InputNumber(id, number);
            //Clients.Group(groupId.ToString(), null).InputNumber(id, number);
        }
        /// <summary>
        /// 次の問題ボタン押下時に発火
        /// </summary>
        public void NextQuestion()
        {
            Clients.All.NextQuestion();
        }


        // 指定されたグループへ参加する
        public void Join(string groupName)
        {
            //base.Groups.Add(null, groupName);
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