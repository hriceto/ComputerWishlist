using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CumputerWishlist.Data.Model
{
    [Table("Component")]
    public class Component
    {
        public int Id { get; set; }
        public int ComponentTypeId { get; set; }
        [MaxLength(100)]
        [Required]
        public ComponentType ComponentType { get; set; }
        public string Name { get; set; }
    }
}
