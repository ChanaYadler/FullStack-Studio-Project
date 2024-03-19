using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class WorkerService : IWorker
    {
        private StudioContext studioContext;
        public WorkerService(StudioContext context)
        {
            this.studioContext =context;
        }

        public bool addWorker(Worker worker)
        {
            if (worker == null) { return false; }
            studioContext.Workers.Add(worker);
            return true;
        }

        public bool removeWorker(string id)
        {
            if(id == null) { return false; }    
            var w = studioContext.Workers.FirstOrDefault(w => w.Id.Equals(id));
            if (w != null) { studioContext.Workers.Remove(w); }
            return true;

        }

        public Worker GetWorkerById(string id)
        {
            var w = studioContext.Workers.FirstOrDefault(w => w.Id.Equals(id));
            if (w != null) { return w; }
            return null;
        }

        public Worker updateWorker(Worker worker)
        {
            var w = studioContext.Workers.FirstOrDefault(c => c.Id.Equals(worker.Id));
            if (w == null) return null;
            w.PhoneNumber = worker.PhoneNumber;
            w.LastName = worker.LastName;
            w.FirstName = worker.FirstName;
            w.Meetings = worker.Meetings;
            studioContext.SaveChanges();
            return w;
        }
    }
}
