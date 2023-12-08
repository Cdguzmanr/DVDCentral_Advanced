namespace CG.DVDCentral.UI.ViewModels
{
    public class OrderVM
    {

        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        public OrderVM(int id)
        {
            Order = OrderManager.LoadById(id);
            OrderItems = OrderItemManager.LoadByOrderId(id);
        }

    }
}
