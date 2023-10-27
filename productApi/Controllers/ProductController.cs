using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace productApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(new List<string> { "Kalem", "Kitap", "Silgi", "Defter" });
		}

	}
}
