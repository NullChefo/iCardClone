using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class Account: BaseEntity
    {
        [Required]
        public double Balance { get; set; }
       
        [Required]
        [StringLength(5)]
        public string Currency { get; set; }

        [Required]
        public bool Active { get; set; }

        public ICollection<VirtualCard> VirtualCards { get; set; } = new List<VirtualCard>();
        
        public ICollection<TransactionHistory> Transactions { get; set; } = new List<TransactionHistory>();


        public int PlanId { get; set; }

        public Plan Plan { get; set; }


        public int SettingsId { get; set; }

        public Settings Settings { get; set; }
        
    }
}