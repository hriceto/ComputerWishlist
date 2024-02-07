using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CumputerWishlist.Data.Model
{
    [Table("ComponentType")]
    public class ComponentType
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public int MaxLimit { get; set; }
    }
}
