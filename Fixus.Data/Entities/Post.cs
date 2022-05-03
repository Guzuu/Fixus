using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fixus.Data.Entities
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public User AddedByUser { get; set; }

        public User AssignedToUser { get; set; }

        public Post()
        {
            AddedByUser = new User();
            Category = new Category();
            AssignedToUser = new User();
        }
    }
}
