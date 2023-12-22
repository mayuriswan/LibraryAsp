namespace LibrairieDTICRosemont.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;

    public class ChatHub : Hub
    {
        // GetConnectionId method
        public string GetConnectionId()
        {
            var userId = Context.User?.FindFirst("ClientId")?.Value;
            return userId;
        }

        // SendMessageToAll method
        public async Task SendMessageToAll(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        // OnConnectedAsync method
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            UpdateUserConnectionId();
        }

        // OnDisconnectedAsync method
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            UpdateUserConnectionId();
        }

        // UpdateUserConnectionId method
        private void UpdateUserConnectionId()
        {
            var userId = Context.User?.FindFirst("ClientId")?.Value;

            if (userId != null)
            {
                // Update the ClientId property with the current connection id
                // This assumes you have a user management system with a User object
                // containing a property named ClientId
                // Example: _userManager.UpdateUserConnectionId(userId, Context.ConnectionId);
            }
        }

        // Bonus: SendPrivateMessage method
        public async Task SendPrivateMessage(string toUserId, string message)
        {
            var fromUserId = GetConnectionId();
            await Clients.User(toUserId).SendAsync("ReceivePrivateMessage", fromUserId, message);
        }
    }

}
