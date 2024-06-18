using DAL.DalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL
{
    public class BLProfile : Profile
    {
        public BLProfile() {
            CreateMap<Meeting, BLMeeting>().ReverseMap();
            CreateMap<Customer, BLCustomer>().ReverseMap();
            CreateMap<Role, BLRole>().ReverseMap();
            CreateMap<Worker, BLWorker>().ReverseMap();
        }
    }
}
//https://github.com/YehuditShrg/RetirementSimulator/blob/master/server/RetirementSimulator/Profiles/UserProfile.cs