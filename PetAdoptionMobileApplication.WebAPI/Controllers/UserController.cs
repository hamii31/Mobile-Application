﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionMobileApplication.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
	}
}
