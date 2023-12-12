namespace CG.DVDCentral.UI.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public ShoppingCart ShoppingCart { get; set; } = new ShoppingCart();
    }
}
