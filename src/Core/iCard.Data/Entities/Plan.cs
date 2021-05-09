using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class Plan: BaseEntity
    {
        [Required]
        public double Cost { get; set; }

        [Required]
        [StringLength(5)]
        public string Currency { get; set; }

        [Required]
        public double MaxExchange { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }


        [Required]
        public int CardTransactions { get; set; }

        [Required]
        public bool Insurance { get; set; }

    }
}