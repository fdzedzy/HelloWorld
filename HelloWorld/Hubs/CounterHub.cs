using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using HelloWorld.Models;

namespace HelloWorld.Hubs
{
    public class CounterHub : Hub
    {
        public async Task SendCounter()
        {
            await Clients.All.SendAsync("ReceiveMessage", Counter.CounterValue.ToString());
        }
    }
}