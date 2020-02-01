using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL;

namespace TheaterTicketBox.App_Start
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
		}
		public static void Initialize()
		{
			Mapper.Initialize(nfg => nfg.AddProfiles(new Profile[] { new AutoMapperConfig(), new AutoMapperConfigBLL() }));
		}
	}
}