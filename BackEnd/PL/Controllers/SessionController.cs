using AutoMapper;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PL
{
	public class SessionController : ApiController
    {
		private ISessionService _sessionService;
		private IMapper _mapper;
		public SessionController(ISessionService service)
		{
			_sessionService = service;
			_mapper = Mapper.Instance;
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[Route("Sessions")]
		public IHttpActionResult CreateSession(SessionModel sessionModel)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			try
			{
				SessionDTO session = _mapper.Map<SessionDTO>(sessionModel);
				_sessionService.CreateSession(session);
				return Ok("Session was created");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpGet]
		[Authorize(Roles = "User")]
		[Route("Sessions")]
		public IHttpActionResult GetAllSessions()
		{
			try
			{
				IEnumerable<SessionDTO> sessionsDTO = _sessionService.GetAllSessions();
				List<SessionModel> sessions = new List<SessionModel>();
				foreach (SessionDTO s in sessionsDTO)
				{
					SessionModel sess = _mapper.Map<SessionModel>(s);
					sessions.Add(sess);
				}
				return Ok(sessions);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
		[HttpGet]
		[Authorize(Roles = "User")]
		[Route("Sessions/{Id}")]
		public IHttpActionResult GetSession(int id)
		{
			try
			{
				SessionDTO  sessionDTO = _sessionService.GetSession(id);
				SessionModel sessionModel = _mapper.Map<SessionModel>(sessionDTO);
				return Ok(sessionModel);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpDelete]
		[Authorize(Roles = "Admin")]
		[Route("Sessions/{Id}")]
		public IHttpActionResult RemoveSession(int id)
		{
			try
			{
				_sessionService.RemoveSession(id);
				return Ok("Session was removed");
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}
	}
}
