using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi
{
    public interface IMeeting
    {
        public List<Meeting> getMeetingsById(string id);
        public bool addMeeting(Meeting meeting);
        public bool ifAvailable(DateTime date);
        public bool removeMeeting(string id);
        public Meeting updateMeeting(Meeting meeting);
    }
}
