using AutoMapper;
using BLL;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.App_Start
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{
			CreateMap<UserRegistrationModel, UserDTO>().ReverseMap()
				.ForMember("Email", opt => opt.MapFrom(c => c.Email))
				.ForMember("Password", opt => opt.MapFrom(c => c.Password))
				.ForMember("PhoneNumber", opt => opt.MapFrom(c => c.PhoneNumber))
				.ForMember("Name", opt => opt.MapFrom(c => c.Name))
				.ForMember("Surname", opt => opt.MapFrom(c => c.Surname));

			CreateMap<SeatDTO, SeatModel>().ReverseMap();

			CreateMap<HallDTO, HallModel>().ReverseMap();

			CreateMap<PerformanceDTO, PerformanceModel>().ReverseMap();


			CreateMap<TicketDTO, TicketModel>().ReverseMap();
				

			CreateMap<SessionDTO, SessionModel>()
				.ForMember(c => c.Date,x => x.MapFrom(c => c.Date.ToString().Remove(16,3)))
				.ReverseMap()
			     .ForMember(c => c.Id, x => x.MapFrom(c => c.Id))
				 .ForMember(c => c.Date, x => x.MapFrom(c => DateTime.ParseExact(c.Date, "dd-MM-yyyy HH:mm", null)))
				 .ForMember(c => c.PerformanceId, x => x.MapFrom(c => c.PerformanceId))
				 .ForMember(c => c.HallId, x => x.MapFrom(c => c.HallId))
				 .ForMember(c => c.Tickets, x => x.MapFrom(c => c.Tickets));


		}

		public static void Initialize()
		{
			Mapper.Initialize(nfg => nfg.AddProfiles(new Profile[] { new AutoMapperConfig(), new AutoMapperConfigBLL() }));
		}
	}
}