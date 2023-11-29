namespace CG.DVDCentral.UI.ViewModels
{
    public class OrderVM
    {

        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
