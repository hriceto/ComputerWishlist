using System.ComponentModel.DataAnnotations.Schema;

namespace CumputerWishlist.Data.Model
{
    [Table("ComputerSpecComponent")]
    public class ComputerSpecComponent
    {
        public int Id { get; set; }
        public int ComputerSpecId { get; set; }
        public ComputerSpec ComputerSpec { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public int Count { get; set; }
    }
}
