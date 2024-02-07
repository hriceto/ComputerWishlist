using System.ComponentModel.DataAnnotations.Schema;

namespace CumputerWishlist.Data.Model
{
    [Table("ComputerSpec")]
    public class ComputerSpec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsSystem { get; set; }
        public string Weight { get; set; }
    }
}
