namespace iCard.ApplicationServices.DTOs
{
    public class VirtualCardDTO
    {
        	public double Balance { get; set; }
        		public string Currency { get; set; }
        		public string CardNumber { get; set; }
        		public string ValidDate { get; set; }
        		public string CVV { get; set; }
        		public string Name { get; set; }
        		public int AccountId { get; set; }
    }
}