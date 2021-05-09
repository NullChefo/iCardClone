using System.Collections.Generic;

namespace iCard.ApplicationServices.DTOs
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        public double Balance { get; set; }

        public string Currency { get; set; }

        public bool Active { get; set; }

        public ICollection<VirtualCardDTO> VirtualCards { get; set; }

        public ICollection<TransactionHistoryDTO> Transactions { get; set; }

        public PlanDTO Plan { get; set; }

        public SettingsDTO Settings { get; set; }
    }
}