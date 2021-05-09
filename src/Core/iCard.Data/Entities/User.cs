using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class User : BaseEntity
    {

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        public bool Active { get; set; }

        public Account Account { get; set; }

        public int? AccountId {get; set;}
    }
}