namespace iCard.ApplicationServices.DTOs
{
    public class TransactionHistoryDTO
    {
        public double TransactionCost { get; set; }
        public string Currency { get; set; }
        public string TransactionTarget { get; set; }
        public string TransactionType { get; set; }
        public string TransactionStatus { get; set; }
        public string Name { get; set; }

        public int AccountId { get; set; }


        public TransactionHistoryDTO ShallowCopy()
        {
            return (TransactionHistoryDTO )this.MemberwiseClone();
        }
    }
}