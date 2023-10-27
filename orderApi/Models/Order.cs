using orderApi.Models.Shared;

namespace orderApi.Models
{
    public class Order : EntityBase
    {
        public int customerid { get; set; }
        public List<int> ProductId { get; set; } = new List<int>();
        public DateTime shipDate { get; set; } = DateTime.Now;
        public string Firstname { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
     

    }
}
