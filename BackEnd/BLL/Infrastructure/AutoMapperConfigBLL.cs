using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
	public class AutoMapperConfigBLL : Profile
	{
		public AutoMapperConfigBLL()
		{
			CreateMap<UserProfile, UserDTO>().ReverseMap();
		

			CreateMap<Hall, HallDTO>().ReverseMap();


			CreateMap<Performance, PerformanceDTO>().ReverseMap();

			CreateMap<Seat, SeatDTO>().ReverseMap();

			CreateMap<Ticket, TicketDTO>().ReverseMap();


			CreateMap<Session, SessionDTO>().ReverseMap();
				
				
		}
	}
}
