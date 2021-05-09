using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class VirtualCard: BaseEntity
    {
        [Required]
        public double Balance { get; set; }

        [Required]
        [StringLength(5)]
        public string Currency { get; set; }

        [Required]
        [StringLength(50)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string ValidDate { get; set; }

        [Required]
        [StringLength(3)]
        public string CVV { get; set; }		
		
        [Required]
        [StringLength(20)]

        public string Name { get; set; }


        [Required]
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}