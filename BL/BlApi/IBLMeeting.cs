using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlApi
{
    internal interface IBLMeeting
    {
        public List<Meeting> getDetailsById(string id);
        public bool addNewMeeting(BLMeeting meeting);
        public bool deleteMeeting(string id);
        public Meeting updateDetailsMeeting(BLMeeting meeting);
    }
}
