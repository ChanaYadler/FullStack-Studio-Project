using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface IBLWorker
    {
        public bool Type(string id);
        public Worker GetDetailsById(string id);
        public bool deleteWorker(string id);
        public bool addNewWorker(BLWorker worker);
        public Worker updateDetailsWorker(BLWorker worker);
    }
}
