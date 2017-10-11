using Microsoft.AspNet.SignalR;

namespace CarModsHeaven.Web.Hubs
{
    public class Discussions : Hub
    {
        public void SendMessage(string message)
        {
            string formattedMsg = $"{this.Context.User.Identity.Name} : {message}";
            this.Clients.All.getMessage(formattedMsg);
        }
    }
}