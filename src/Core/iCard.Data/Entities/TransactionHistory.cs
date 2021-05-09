using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iCard.Data.Entities
{
    public class TransactionHistory : BaseEntity
    {
        [Required]
        public double TransactionCost { get; set; }

        [Required]
        [StringLength(5)]
        public string Currency { get; set; }

        [Required]
        [StringLength(50)]
        public string TransactionTarget { get; set; }	
		
        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; }	
		
        [Required]
        [StringLength(10)]
        public string TransactionStatus { get; set; }		

        [StringLength(20)]

        public string Name { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

    }
}
