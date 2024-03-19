using DAL.DalApi;
using DAL.DalModels;
using DAL.DalServices;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class DalManager
    {
        public IWorker Worker { get;}
        public ICustomer Customer { get;}   
        public IMeeting Meeting { get;}
        public IRole Role { get;}
        public DalManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<StudioContext>();
            services.AddSingleton<ICustomer, CustomerService>();
            services.AddSingleton<IWorker, WorkerService>();
            services.AddSingleton<IMeeting, MeetingService>(); 
            services.AddSingleton<IRole, RoleService>();
            ServiceProvider Provider = services.BuildServiceProvider();
            Worker = Provider.GetService<IWorker>();
            Customer = Provider.GetService<ICustomer>();
            Meeting = Provider.GetService<IMeeting>();
            Role = Provider.GetService<IRole>();

        }

    }
}