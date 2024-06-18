using AutoMapper;
using BL.BlApi;
using DAL;
using DAL.DalApi;
using DAL.DalModels;

namespace BL.BlServices
{
    public class BLWorkerService : IBLWorker
    {
        readonly IMapper mapper;
        IWorker WorkerDAL;

        public BLWorkerService(DalManager dl, IMapper mapper)
        {
            this.WorkerDAL = dl.Worker;
            this.mapper = mapper;
        }
        public bool Type(string id)
        {
            if (GetDetailsById(id) != null) { return true; }
            return false;
        }
        public bool addNewWorker(BLWorker worker)
        {
            Worker Worker1 = mapper.Map<Worker>(worker);
            var w = WorkerDAL.addWorker(Worker1);
            if (w) return true;
            return false;
        }

        public bool deleteWorker(string id)
        {
            var w = WorkerDAL.removeWorker(id);
            if (w) return true;
            return false;

        }

        public Worker GetDetailsById(string id)
        {
            var w = WorkerDAL.GetWorkerById(id);
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
