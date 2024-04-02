#nullable disable

namespace CG.DVDCentral.PL2.Entities
{
    public  class tblCart : IEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public virtual tblUser User { get; set; }

        public string SortField { get { return User.LastName; } }

    }

}
