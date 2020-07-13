using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoelessJoe.App.Classes
{
    public class OrderClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddOrder(Users user, Stores store, Foods food)
        {
            var newOrder = new Orders
            {
                StoreId = store.StoreId,
                CustomerId = user.UserId,
                OrderDate = new DateTime(),
                OrderTotal = food.Price
            };

            ctx.Orders.Add(newOrder);
            ctx.SaveChanges();

            Navigation.Menu(user, store);
        }
    }
}
