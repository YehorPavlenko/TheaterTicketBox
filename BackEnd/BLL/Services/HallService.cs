using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class HallService : IHallService
	{
		private IUnitOfWork _unit;
		private IMapper _mapper;
		public HallService(IUnitOfWork unit)
		{
			_unit = unit;
			_mapper = Mapper.Instance;
		}
		public void CreateHall(HallDTO hallDTO)
		{
			if (hallDTO.NumberOfSeats != hallDTO.NumberOfRows * hallDTO.NumberOfSeatsInRow)
			{
				throw new IncorrectDataException("Incorrect number of seats");
			}
			Hall hall = _mapper.Map<Hall>(hallDTO);
			List<Seat> seats = new List<Seat>();
			for (int i = 1; i <= hall.NumberOfRows; i++)
			{
				for (int k = 1; k <= hall.NumberOfSeatsInRow; k++)
				{
					Seat seat = new Seat
					{
						HallId = hall.Id,
						Hall = hall,
						SeatNumber = k,
						RowNumber = i
					};
					seats.Add(seat);
					_unit.SeatRepository.Create(seat);
				}
			}
			hall.Seats = seats;
			_unit.HallRepository.Create(hall);
			_unit.Save();
		}
		public IEnumerable<HallDTO> GetAllHalls()
		{
			IEnumerable<Hall> halls = _unit.HallRepository.GetAll();
			List<HallDTO> HallsDTO = new List<HallDTO>();
			foreach (Hall p in halls)
			{
				HallDTO perf = _mapper.Map<HallDTO>(p);
				HallsDTO.Add(perf);
			}
			return HallsDTO;
		}
		public void RemoveHall(int id)
		{
			Hall hall =_unit.HallRepository.Get(id);
			if (hall == null)
			{
				throw new NotFoundException("Hall is not found");
			}
			List<Seat> seats = hall.Seats.ToList();
			foreach (Seat s in seats)
			{
				_unit.SeatRepository.Delete(s);
			}
			_unit.HallRepository.Delete(hall);
			_unit.Save();
		}
		public void ChangeHallName(int id, string NewName)
		{
			Hall hall = _unit.HallRepository.Get(id);
			if (hall == null)
			{
				throw new NotFoundException("Hall is not found");
			}
			hall.Name = NewName;
			_unit.HallRepository.Update(hall);
			_unit.Save();
		}
	}
}
