using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace customerApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(new List<string> { "Hilmi Celayir", "Saniye Yıldız", "Nevin Yıldız", "Fatih Yılmaz" });
		}

	}
}
