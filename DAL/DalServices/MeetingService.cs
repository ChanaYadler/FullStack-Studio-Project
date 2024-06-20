using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices
{
    internal class MeetingService : IMeeting
    {
        private StudioContext studioContext;
        public MeetingService(StudioContext context)
        {
                studioContext = context;
        }

        public bool addMeeting(Meeting meeting)
        {
            if(meeting == null) { return false; }
            studioContext.Meetings.Add(meeting);return true;
            
            
        }

        public List<Meeting> getMeetingsById(string id)                                                                                    
        {
            List<Meeting> meet = new List<Meeting>();
            foreach (var m in studioContext.Meetings)
            {
                if(m.CustomersId == id) { meet.Add(m); }    
            }
            return meet;
        }
        public List<Meeting> getMeetingsByIdOfWorker(string id)
        {
            List<Meeting> meet = new List<Meeting>();
            foreach (var m in studioContext.Meetings)
            {
                if (m.WorkerId == id&& m.Date==DateTime.Now) { meet.Add(m); }
            }
            return meet;
        }

        public bool ifAvailable(DateTime date)
        {
            foreach (var m in studioContext.Meetings)
            {
                if (m.Date == date) return false;
            }
            return true;
        }

        public bool removeMeeting(string id)
        {
            var s = studioContext.Meetings.FirstOrDefault(m => m.Id.Equals(id));
            if (s != null) {
                studioContext.Meetings.Remove(s);
                return true;
            }
            return false;
        }

        public Meeting updateMeeting(Meeting meeting)
        {
            var m = studioContext.Meetings.FirstOrDefault(m => m.Id.Equals(meeting.Id));
            if (m == null) return null;
            m.Date=meeting.Date;    
            m.WorkerId=meeting.WorkerId;
            m.CustomersId=meeting.CustomersId;
            studioContext.SaveChanges();
            return m;
        }
    }
}
