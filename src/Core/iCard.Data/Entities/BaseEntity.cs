using System;
using System.ComponentModel.DataAnnotations;

namespace iCard.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {
            this.CreatedDate = DateTime.UtcNow;
        }

    }
}