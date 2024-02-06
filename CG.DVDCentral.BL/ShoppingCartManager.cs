using CG.DVDCentral.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CG.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null)
            {
                // Check if the movieId is already in the cart
                Movie existingItem = cart.Items.FirstOrDefault(item => item.Id == movie.Id);

                if (existingItem != null)
                {
                    // If the movieId is already in the cart, increment the quantity by 1
                    existingItem.Quantity++;
                } 
                else
                {
                    // If the movieId is not in the cart, add it as a new item
                    cart.Items.Add(movie);
                }
            }
        }

        public static void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Remove(movie); }
        }

        
        // To do: Checkout Not Working
        /*
        public static void Checkout(ShoppingCart cart, Guid customerId, Guid userId) // Removed " = 1" from argument id's 
        {
            try
            {
                // Make a new order
                Order order = new Order()
                {
                    //  Set the Order fields as needed.
                    CustomerId = customerId, // TODO: Get the logged in user's customer id
                    UserId = userId, // TODO: Get the logged in user's id
                    OrderDate = DateTime.Now,
                    ShipDate = DateTime.Now.AddDays(3), // Ship in 3 days             
                };
                // Insert the order
                OrderManager.Insert(order);

                // For each item in the cart
                foreach (Movie item in cart.Items)
                {
                    // Make a new orderitem
                    OrderItem orderItem = new OrderItem();


                    // Set the OrderItem fields from the item.
                    orderItem.MovieId = item.Id;
                    orderItem.OrderId = order.Id;
                    orderItem.Cost = item.Cost * item.Quantity;
                    orderItem.Quantity = item.Quantity; // Assuming quantity is always 1 for each movie in the cart


                    // Add the orderItem to the DB
                    OrderItemManager.Insert(orderItem);

                    // Decrement the tblMovie.InStkQty appropriately.
                    int newStock = item.InStkQty - item.Quantity;
                    MovieManager.UpdateStock(item.Id, newStock);
                }

                cart = new ShoppingCart();
            }
            catch (Exception)
            {

                throw;
            }
        }
        */
    }
}
