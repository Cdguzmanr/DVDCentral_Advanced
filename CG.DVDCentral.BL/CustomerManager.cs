using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;

namespace CG.DVDCentral.BL
{
    public class CustomerManager
    {
        public static int Insert(Customer customer, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblCustomer entity = new tblCustomer();
                    entity.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.UserId = customer.UserId;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.ZIP = customer.ZIP;
                    entity.Phone = customer.Phone;
                    entity.ImagePath = customer.ImagePath;
                    entity.State = customer.State;

                    // IMPORTANT - BACK FILL THE ID 
                    customer.Id = entity.Id;

                    dc.tblCustomers.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Customer customer, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == customer.Id);
                    if (entity != null)
                    {                        
                        entity.FirstName = customer.FirstName;
                        entity.LastName = customer.LastName;
                        entity.UserId = customer.UserId;
                        entity.Address = customer.Address;
                        entity.City = customer.City;
                        entity.ZIP = customer.ZIP;
                        entity.Phone = customer.Phone;
                        entity.ImagePath = customer.ImagePath;
                        entity.State = customer.State;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }

                    if (rollback) transaction.Rollback();
                }

                return results;
            }
            catch (Exception) { throw; }
        }

        public static Customer LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        return new Customer
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            UserId = entity.UserId,
                            Address = entity.Address,
                            City = entity.City,
                            ZIP = entity.ZIP,
                            Phone = entity.Phone,
                            ImagePath = entity.ImagePath,
                            State = entity.State,

                        };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Customer> Load()
        {
            try
            {
                List<Customer> list = new List<Customer>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblCustomers
                     select new
                     {
                         s.Id,
                         s.FirstName, 
                         s.LastName,
                         s.UserId,
                         s.Address,
                         s.City,
                         s.ZIP,
                         s.Phone,
                         s.ImagePath,
                         s.State,
                     })
                    .ToList()
                    .ForEach(customer => list.Add(new Customer
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        UserId = customer.UserId,
                        Address = customer.Address,
                        City = customer.City,
                        ZIP = customer.ZIP,
                        Phone = customer.Phone,
                        ImagePath = customer.ImagePath,
                        State = customer.State,
                    }));
                }
                return list;
            }
            catch (Exception) { throw; }
        }

        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblCustomers.Remove(entity);

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();
                } 
                return results;
            }
            catch (Exception) { throw; }
        }
    }
}
