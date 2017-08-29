using Microsoft.AspNet.SignalR;

namespace ConwaysGameOfLife.Hubs
{
    public class LifeHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello("hello");
        }
    }
}