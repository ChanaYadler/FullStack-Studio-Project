using AutoMapper;
using BL.BlApi;
using DAL.DalApi;
using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices
{
    internal class BLMeetingService : IBLMeeting
    {
        readonly IMapper mapper;
        IMeeting MeetingDal;

        public BLMeetingService(IMeeting MeetingDal, IMapper mapper)
        {
            this.MeetingDal = MeetingDal;
            this.mapper = mapper;
        }
        public bool addNewMeeting(BLMeeting meeting)
        {
            Meeting meeting1 = mapper.Map<Meeting>(meeting);
            var m = MeetingDal.ifAvailable(meeting1.Date);
            if (m)
            {
                MeetingDal.addMeeting(meeting1);
                return true;
            }
            return false;
        }

        public bool deleteMeeting(string id)
        {
            var m = MeetingDal.removeMeeting(id);
            if (m) { return true; }
            return false;
        }

        public List<Meeting> getDetailsById(string id)
        {
            var m= MeetingDal.getMeetingsById(id);
            return m;
        }

        public Meeting updateDetailsMeeting(BLMeeting meeting)
        {
            Meeting meeting1 = mapper.Map<Meeting>(meeting);
            MeetingDal.updateMeeting(meeting1);
            return meeting1;
        }
    }
}
