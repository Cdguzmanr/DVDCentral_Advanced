#nullable disable

namespace CG.DVDCentral.PL2.Entities;

public class tblUser : IEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string SortField { get { return LastName; } }
}
