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
                    string bothShoes = ShoeClass.CovertBothShoesOrIsSoldToString(item.BothShoes);

                    Console.WriteLine($"{item.ShoeId}. Manufacter: {item.Manufacter}  Model: {item.Model} Both Shoes? {bothShoes}");
                    Console.WriteLine();
                    int number = ShoeClass.UserOptions(user);
                    ShoeClass.ShoeDetails(number, user);
                }
            }
            else
            {
                Console.WriteLine("You have no shoes");
                Navigation.PressKeyToContenue(user);
            }
            
        }

        public static void CurrentUserBuyComments(Users user)
        {
            try
            {
                var currentUserBuyComments = ctx.Comments
                    .Include(u => u.Buyer)
                    .Include(s => s.Shoe)
                    .ThenInclude(u => u.User)
                    .Where(a => a.Buyer.UserId == user.UserId)
                    .ToList();

                if (currentUserBuyComments.Count != 0)
                {
                    foreach (var item in currentUserBuyComments)
                    {
                        Console.WriteLine($"{item.CommentId}. Comment Head: {item.MessageHead}  Shoe Owner: {item.Shoe.User.FirstName} {item.Shoe.User.LastName}");
                        Console.WriteLine();
                    }
                    CommentClass.SelectComment(user);
                }
                else
                {
                    Console.WriteLine("You have no potential buys");
                    Navigation.PressKeyToContenue(user);
                }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine();
                Console.WriteLine("Comment does not exsist. Try again");
                CurrentUserBuyComments(user);
            }
        }

        public static void CurrentUserSellComment(Users user)
        {
            try
            {
                var currentUserBuyComments = ctx.Comments
                    .Include(u => u.Buyer)
                    .Include(s => s.Shoe)
                    .ThenInclude(u => u.User)
                    .Where(a => a.Shoe.User.UserId == user.UserId)
                    .ToList();

                if (currentUserBuyComments.Count != 0)
                {
                    foreach (var item in currentUserBuyComments)
                    {
                        Console.WriteLine($"{item.CommentId}. Comment Head: {item.MessageHead}  Potential Buyer: {item.Buyer.FirstName} {item.Buyer.LastName}");
                        Console.WriteLine();
                    }
                    CommentClass.SelectComment(user);
                }
                else
                {
                    Console.WriteLine("You have no potential sells");
                    Navigation.PressKeyToContenue(user);
                }
            }
            catch(NullReferenceException)
            {
                Console.WriteLine();
                Console.WriteLine("Comment does not exsist. Try again");
                CurrentUserSellComment(user);
            }
        }
    }
}
