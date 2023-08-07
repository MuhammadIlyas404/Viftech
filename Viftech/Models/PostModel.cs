namespace Viftech.Models
{
    public class PostModel
    {
        public decimal Age { get; set; }
        public string? Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ResponseModel
    {
        public decimal Total { get; set; }
        public string? Currency { get; set; }
        public int QuotationId { get; set; }
    }
}
