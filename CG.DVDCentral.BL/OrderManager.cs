using Microsoft.EntityFrameworkCore.Storage;

using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace CG.DVDCentral.BL
{
    public class OrderManager
    {
        public static int Insert(Order order, bool rollback = false) // Id by reference
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder entity = new tblOrder();
                    entity.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(s => s.Id) + 1 : 1;
                    entity.CustomerId = order.CustomerId;
                    entity.OrderDate = order.OrderDate; 
                    entity.UserId = order.UserId;
                    entity.ShipDate = order.ShipDate;

                    // Inserts OrderItems objects into the list at Order
                    foreach (OrderItem orderItem in order.OrderItems)
                    {
                        // set the orderId on tblOrderItem
                                //orderItem.OrderId = order.Id;
                        results += OrderItemManager.Insert(orderItem, rollback);
                    }

                    //entity.OrderItems = order.OrderItems;   

                    // IMPORTANT - BACK FILL THE ID 
                    order.Id = entity.Id;

                    dc.tblOrders.Add(entity);
                    results += dc.SaveChanges(); // Make sure to add the += and not only = 

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception) { throw; }
        }

        public static int Update(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    // Get the row that we are trying to update
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == order.Id);
                    if (entity != null)
                    {
                        entity.CustomerId = order.CustomerId;
                        entity.OrderDate = order.OrderDate;
                        entity.UserId = order.UserId;
                        entity.ShipDate = order.ShipDate;

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

        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    //tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);
                    var entity = (from s in dc.tblOrders
                                  join oi in dc.tblOrderItems on s.Id equals oi.OrderId
                                  where oi.OrderId == id
                                  select new
                                  {
                                      s.Id,
                                      s.CustomerId,
                                      s.OrderDate,
                                      s.UserId,
                                      s.ShipDate,
                                      
                                  })
                                  .FirstOrDefault();

                        if (entity != null)
                        {
                            return new Order
                            {
                                Id = entity.Id,
                                CustomerId = entity.CustomerId,
                                OrderDate = entity.OrderDate,
                                UserId = entity.UserId,
                                ShipDate = entity.ShipDate,
                                OrderItems = OrderItemManager.LoadByOrderId(id) // Checkpoint 4 - Instruction 3.c       
                        };
                    }
                    else { throw new Exception(); }
                }
            }
            catch (Exception) { throw; }
        }

        public static List<Order> Load(int? CustomerId = null)
        {
            try
            {
                List<Order> list = new List<Order>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from s in dc.tblOrders
                     join oi in dc.tblOrderItems on s.Id equals oi.OrderId
                     join c in dc.tblCustomers on s.CustomerId equals c.Id
                     where s.CustomerId == CustomerId || CustomerId == null 
                     select new
                     {
                         // what info should display for this join? 

                         s.Id,
                         s.CustomerId,
                         s.OrderDate,
                         s.UserId,
                         s.ShipDate,

                     })
                    .ToList()
                    .ForEach(order => list.Add(new Order
                    {
                        Id = order.Id,
                        CustomerId = order.CustomerId,
                        OrderDate = order.OrderDate,
                        UserId = order.UserId,
                        ShipDate = order.ShipDate,
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
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.tblOrders.Remove(entity);

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
