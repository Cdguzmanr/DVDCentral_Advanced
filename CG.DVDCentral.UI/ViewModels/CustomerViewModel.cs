namespace CG.DVDCentral.UI.ViewModels
{
    public class CustomerViewModel
    {

        public int CustomerId { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public int UserId { get; set; }

        public ShoppingCart Cart { get; set; } = new ShoppingCart();

        public CustomerViewModel()
        {
            Customers = CustomerManager.Load();
        }


    }
}
