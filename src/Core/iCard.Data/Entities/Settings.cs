using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class Settings : BaseEntity
    {
        [StringLength(20)]
        [Required]
        public string AppTheme { get; set; }
       
        [Required]
        public bool GamblingBlock { get; set; }
       
        [Required]
        public bool AppNotifications { get; set; }

        public bool AutoUpdate { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }
    }
}