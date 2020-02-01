using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PL.Controllers
{
	public class PerformanceController : ApiController
    {
		private IPerformanceService _performanceService;
		private IMapper _mapper;
		public PerformanceController(IPerformanceService service)
		{
			_performanceService = service;
			_mapper = Mapper.Instance;
		}
		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("Performances")]
		public IHttpActionResult CreatePerformance(PerformanceModel performanceModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			PerformanceDTO performance = _mapper.Map<PerformanceDTO>(performanceModel);
			try
			{
				_performanceService.CratePerformance(performance);
				return Ok("Performance was created");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("Performances/{Id}")]
		public IHttpActionResult RemovePerformance(int id)
		{
			try
			{
				_performanceService.RemovePerformance(id);
				return Ok("Performance was removed");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpGet]
		[Authorize(Roles = "User")]
		[Route("Performances")]
		public IHttpActionResult GetAllPerformances()
		{
			try
			{
				IEnumerable<PerformanceDTO> performancesDTO = _performanceService.GetAllPerformances();
				List<PerformanceModel> performances = new List<PerformanceModel>();
				foreach (PerformanceDTO p in performancesDTO)
				{
					PerformanceModel perf = _mapper.Map<PerformanceModel>(p);
					performances.Add(perf);
				}
				return Ok(performances);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);	
			}
		}
		[HttpPatch]
		[Authorize(Roles ="Admin")]
		[Route("Performances/{Id}")]
		public IHttpActionResult AddPerformancePhoto(int id)
		{
			try
			{
				var files = HttpContext.Current.Request.Files;
				var path = HttpContext.Current.Server.MapPath("~/Photos");
				if (files[0].FileName.Contains(".JPG") || files[0].FileName.Contains(".PNG") || files[0].FileName.Contains(".png") || files[0].FileName.Contains(".jpg"))
				{
					string storePath = files[0].FileName.ToString();
					string fullPath = Path.Combine(path, storePath);

					if (File.Exists(fullPath))
					{
						File.Delete(fullPath);
					}
					files[0].SaveAs(fullPath);
					PerformanceDTO perf = _performanceService.GetPerformanceTracking(id);
					perf.PhotoPath = PerformanceDTO.Path + storePath;
					_performanceService.UpdatePerformance(perf);

				}
				else
				{
					return BadRequest("Image should be .jpg or .png");
				}
				return Ok("Uploaded");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
