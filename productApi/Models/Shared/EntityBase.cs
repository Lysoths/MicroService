using System.ComponentModel.DataAnnotations;
using productApi.Helpers;

namespace productApi.Models.Shared
{
	public class EntityBase
	{
		public int Id { get; set; }
		[MaxLength(14)]
		public string CreatedDateTime { get; set; } = DateTime.Now.ToString("yyyyMMddhhmmss");
		public int Status { get; set; } = (int)productApi.Helpers.Status.Active;
	}
}
