namespace ComputerWishlist.Server.ViewModels
{
    public class ComputerSpecViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComputerSpecComponentTypeViewModel> ComponentTypes { get; set; }
    }
}
