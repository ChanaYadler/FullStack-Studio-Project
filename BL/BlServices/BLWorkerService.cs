using AutoMapper;
using BL.BlApi;
using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices
{
    internal class BLWorkerService : IBLWorker
    {
        readonly IMapper mapper;
        IWorker WorkerDAL;

        public BLWorkerService(IWorker WorkerBL, IMapper mapper)
        {
            this.WorkerDAL = WorkerBL;
            this.mapper = mapper;
        }
        public bool addNewWorker(BLWorker worker)
        {
            Worker Worker1 = mapper.Map<Worker>(worker);
            var w = WorkerDAL.addWorker(Worker1);
            if(w ) return true;
            return false;
        }

        public bool deleteWorker(string id)
        {
            var w = WorkerDAL.removeWorker(id);
            if(w) return true;
            return false;

        }

        public Worker GetDetailsById(string id)
        {
            var w= WorkerDAL.GetWorkerById(id);
            return w;
        }

        public Worker updateDetailsWorker(BLWorker worker)
        {
            Worker Worker1 = mapper.Map<Worker>(worker);
            WorkerDAL.updateWorker(Worker1);
            return Worker1;

        }
    }
}
