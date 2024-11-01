using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TheTask> TheTask { get; set; }

        public string PropertyTest { get; set; }
    }
}
