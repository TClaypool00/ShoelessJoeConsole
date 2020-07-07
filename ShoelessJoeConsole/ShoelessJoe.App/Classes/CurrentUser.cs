using Microsoft.EntityFrameworkCore;
using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;

namespace ShoelessJoe.App.Classes
{
    public class CurrentUser
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void MyShoes(Users user)
        {
            var myShoes = ctx.Shoes
                .Include(u => u.User)
                .Where(a => a.User.UserId == user.UserId)
                .ToList();

            if (myShoes.Count != 0)
            {
                foreach (var item in myShoes)
                {
                    Console.WriteLine($"{item.ShoeId}. Manufacter: {item.Manufacter}  Model: {item.Model} Both Shoes? {item.BothShoes}");
                    Console.WriteLine();
                    int number = ShoeClass.UserOptions(user);
                    ShoeClass.ShoeDetails(number, user);
                }
            }
            else
            {
                Console.WriteLine("You have no potential buys");
                Navigation.PressKeyToContenue(user);
            }
            
        }
    }
}
