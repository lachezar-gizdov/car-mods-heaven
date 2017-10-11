using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CarModsHeaven.Web.Hubs
{
    [HubName("discussionsHub")]
    public class DiscussionsHub : Hub
    {
        public void SendMessage(string message)
        {
            string formattedMsg = $"{this.Context.User.Identity.Name} : {message}";
            this.Clients.Caller.getMessage(formattedMsg);
        }
    }
}