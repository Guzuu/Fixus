using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fixus.Data.Entities
{
    [Table("Profile")]
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsRepairman { get; set; }

        [Required]
        public User User { get; set; }

        public Profile()
        {
            User = new User();
        }
    }
}
