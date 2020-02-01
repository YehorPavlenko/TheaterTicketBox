using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace PL
{
    public class HallController : ApiController
    {
		private IHallService _hallService;
		private IMapper _mapper;
		public HallController(IHallService service)
		{
			_hallService = service;
			_mapper = Mapper.Instance;
		}
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("Halls")]
		public IHttpActionResult CreateHall(HallModel hallModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				HallDTO hall = _mapper.Map<HallDTO>(hallModel);
				_hallService.CreateHall(hall);
				return Ok("Hall was created");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpGet]
		[Authorize(Roles = "User")]
		[Route("Halls")]
		public IHttpActionResult GetAllHalls()
		{
			try
			{
				IEnumerable<HallDTO> hallsDTO = _hallService.GetAllHalls();
				List<HallModel> halls = new List<HallModel>();
				foreach (HallDTO h in hallsDTO)
				{
					halls.Add(_mapper.Map<HallModel>(h));
				}
				return Ok(halls);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("Halls/{Id}")]
		public IHttpActionResult RemoveHall(int id)
		{
			try
			{
				_hallService.RemoveHall(id);
				return Ok("Hall was removed");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
