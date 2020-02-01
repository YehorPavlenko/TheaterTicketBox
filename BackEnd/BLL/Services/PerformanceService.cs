using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class PerformanceService : IPerformanceService
	{
		private IUnitOfWork _unit;
		private IMapper _mapper;
		public PerformanceService(IUnitOfWork unit)
		{
			_unit = unit;
			_mapper = Mapper.Instance;
		}
		public void CratePerformance(PerformanceDTO performanceDTO)
		{
			Performance performance = _mapper.Map<Performance>(performanceDTO);
			_unit.PerformanceRepository.Create(performance);
			_unit.Save();
		}

		public void RemovePerformance(int id)
		{
			Performance performance = _unit.PerformanceRepository.Get(id);
			if (performance == null)
			{
				throw new NotFoundException("Performance is not found");
			}
			_unit.PerformanceRepository.Delete(performance);
			_unit.Save();
		}
		public IEnumerable<PerformanceDTO> GetAllPerformances()
		{
			IEnumerable<Performance> performances = _unit.PerformanceRepository.GetAll();
			List<PerformanceDTO> performancesDTO = new List<PerformanceDTO>();
			foreach (Performance p in performances)
			{
				PerformanceDTO perf = _mapper.Map<PerformanceDTO>(p);
				performancesDTO.Add(perf);
			}
			return performancesDTO;
		}
		public PerformanceDTO GetPerformanceTracking(int id)
		{
			Performance performance = _unit.PerformanceRepository.GetTracking(id);
			if (performance == null)
			{
				throw new NotFoundException("Performance is not found");
			}
			PerformanceDTO perf = _mapper.Map<PerformanceDTO>(performance);
			return perf;
		}
		public PerformanceDTO GetPerformance(int id)
		{
			Performance performance = _unit.PerformanceRepository.Get(id);
			if (performance == null)
			{
				throw new NotFoundException("Performance is not found");
			}
			PerformanceDTO perf = _mapper.Map<PerformanceDTO>(performance);
			return perf;
		}
		public void UpdatePerformance(PerformanceDTO performanceDTO)
		{
			Performance performance = _mapper.Map<Performance>(performanceDTO);
			_unit.PerformanceRepository.Update(performance);
			_unit.Save();

		}
	}
}
