using productApi.Models.Shared;

namespace productApi.Models
{
	public class Product:EntityBase
	{
		public string Name { get; set; }=String.Empty;
		public string Description { get; set; }=String.Empty;
		public int Quantity { get; set; } = 0;
		public int Price { get; set; } = 0;
		public int Discount { get; set; } = 0;
		public Product() { }
	}
}
