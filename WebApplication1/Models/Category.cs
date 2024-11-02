using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Category
    {
        // [Key]
        public Guid Id { get; set; }
        // [Required]
        // [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<TheTask> TheTasks { get; set; }

        public string PropertyTest { get; set; }
    }
}
