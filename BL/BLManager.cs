using BL.BlApi;
using BL.BlServices;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class BLManager
    {
        public IBLCustomer Customer { get; }
        public IBLWorker Worker { get; }
        public IBLRole Role { get; }
        public IBLMeeting Meeting { get; }
        public BLManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IBLCustomer, BLCutomerService>();
            services.AddSingleton<IBLWorker, BLWorkerService>();
            services.AddSingleton<IBLMeeting, BLMeetingService>();
            services.AddSingleton<IBLRole, BLRoleService>();
            ServiceProvider Provider = services.BuildServiceProvider();
            Customer = Provider.GetService<IBLCustomer>();
            Worker = Provider.GetService<IBLWorker>();
            Role = Provider.GetService<IBLRole>();
            Meeting = Provider.GetService<IBLMeeting>();



        }
    }
}
