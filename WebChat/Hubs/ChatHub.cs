using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace WebChat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void SendMessager(string message)
        {
            // lấy thông tin người gửi
            var sender = Context.User.FindFirst(ClaimTypes.Name);

            //gửi đến tất cả user

            Clients.All.SendAsync("ReceiveMessage", message).Wait();
        }
    }
}
