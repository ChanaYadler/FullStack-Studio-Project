using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IWorker
    {
        public Worker GetWorkerById(string id);
        public bool removeWorker(string id);
        public bool addWorker(Worker worker);
        public Worker updateWorker(Worker worker);
    }
}
