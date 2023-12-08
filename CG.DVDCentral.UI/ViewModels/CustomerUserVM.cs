namespace CG.DVDCentral.UI.ViewModels
{
    public class CustomerUserVM
    {
        public Customer Customer { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }

}
