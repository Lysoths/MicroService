using basketApi.Models.Shared;

namespace basketApi.Models
{
	public class Basket:EntityBase
	{
		public int CustomerId { get; set; }
		public HashSet<int> ProductId { get; set; }=new HashSet<int>();
	}
}
