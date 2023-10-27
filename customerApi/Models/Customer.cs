using customerApi.Models.Shared;

namespace customerApi.Models
{
	public class Customer:EntityBase
	{
		public string Firstname { get; set; }=String.Empty;
		public string Lastname { get; set; } = String.Empty;
		public string Phone {  get; set; } = String.Empty;
		public string Email {  get; set; } = String.Empty;
		public string Description { get; set; }=String.Empty;
		public Customer() { }
	}
}
