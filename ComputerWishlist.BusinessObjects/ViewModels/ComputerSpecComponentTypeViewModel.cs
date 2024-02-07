namespace ComputerWishlist.Server.ViewModels
{
    public class ComputerSpecComponentTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ComputerSpecComponentViewModel> Components { get; set; }
        }
}
