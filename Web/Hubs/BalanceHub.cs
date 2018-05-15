using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Configuration;

namespace AspMain.Web.Hubs
{
    public class BalanceHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DbConnect"].ToString();

        public static void loadData()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<BalanceHub>();
            context.Clients.All.updateData();
        }
    }
}