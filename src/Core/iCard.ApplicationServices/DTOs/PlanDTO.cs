namespace iCard.ApplicationServices.DTOs
{
    public class PlanDTO
    {
        public double Cost { get; set; }
        public string Currency { get; set; }
        public double MaxExchange { get; set; }
        public string Type { get; set; }
        public int CardTransactions { get; set; }
        public bool Insurance { get; set; }
    }
}