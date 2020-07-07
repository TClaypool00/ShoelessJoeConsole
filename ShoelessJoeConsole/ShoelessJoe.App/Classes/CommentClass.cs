using Microsoft.EntityFrameworkCore;
using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class CommentClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddComment(Users user, int id)
        {
            var newComment = new Comments();

            Console.Write("Enter a comment Head (Like a subject in an email): ");
            newComment.MessageHead = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter a comment Body (Like the actual email): ");
            newComment.MessageBody = Console.ReadLine();
            Console.WriteLine();

            newComment.CommentDate = new DateTime();

            newComment.IsApproved = 0;

            newComment.ShoeId = id;

            newComment.BuyerId = user.UserId;

            ctx.Comments.Add(newComment);
            ctx.SaveChanges();
            Thread.Sleep(500);
        }

        public static void CurrentUserBuyComments(Users user)
        {
            var currentUserBuyComments = ctx.Comments
                .Include(u => u.Buyer)
                .Include(s => s.Shoe)
                .ThenInclude(u => u.User)
                .Where(a => a.Buyer.UserId == user.UserId)
                .ToList();

            if(currentUserBuyComments.Count != 0)
            {
                foreach (var item in currentUserBuyComments)
                {
                    Console.WriteLine($"{item.CommentId}. Comment Head: {item.MessageHead}  Shoe Owner: {item.Shoe.User.FirstName} {item.Shoe.User.LastName}");
                    Console.WriteLine();
                }
                SelectComment(user);
            }
            else
            {
                Console.WriteLine("You have no potential buys");
                Navigation.PressKeyToContenue(user);
            }
        }

        public static void CurrentUserSellComment(Users user)
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
                SelectComment(user);
            }
            else
            {
                Console.WriteLine("You have no potential sells");
                Navigation.PressKeyToContenue(user);
            }

            
        }

        public static void CommentDetails(int id, Users user)
        {
            var comment = ctx.Comments
                .Include(u => u.Buyer)
                .Include(s => s.Shoe)
                .ThenInclude(u => u.User)
                .FirstOrDefault(a => a.CommentId == id);

            Console.WriteLine($" Potential Buyer: {comment.Buyer.FirstName } {comment.Buyer.LastName} \n Shoe Owner: {comment.Shoe.User.FirstName} {comment.Shoe.User.LastName}");
            Console.WriteLine();
            Console.WriteLine($" {comment.MessageHead} \n {comment.MessageBody}");
        }

        public static void SelectComment(Users user)
        {
            Console.Write("Select a comment (or press 001 to go back): ");
            int userSelect = int.Parse(Console.ReadLine());
            Navigation.BackToMainMenu(user, userSelect);
            CommentDetails(userSelect, user);
        }
    }
}
