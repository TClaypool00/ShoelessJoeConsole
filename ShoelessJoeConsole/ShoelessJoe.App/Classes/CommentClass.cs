using ShoelessJoe.DataAccess.DataModels;
using System;
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
    }
}
