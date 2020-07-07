using Microsoft.EntityFrameworkCore;
using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class ReplyClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void CreateReply(Comments comment, Users user)
        {
            var newReply = new Reply();

            Console.Write("Please enter a Reply: ");
            newReply.ReplyBody = Console.ReadLine();
            Console.WriteLine();

            newReply.ReplyDate = new DateTime().Date;
            newReply.ReplyUserId = user.UserId;
            newReply.CommentId = comment.CommentId;

            ctx.Reply.Add(newReply);
            ctx.SaveChanges();
            Thread.Sleep(500);
        }

        public static void DisplyReplies(Comments comment, Users user)
        {
            if (user is null)
            {
                Console.WriteLine("You must be logged in");
                StoreClass.MainMenu(user);
            }

            var replies = ctx.Reply
                .Include(u => u.ReplyUser)
                .Include(c => c.Comment)
                .Where(a => a.Comment.CommentId == comment.CommentId);
            Console.WriteLine();
            Console.WriteLine("List of replies");
            Console.WriteLine();

            foreach (var item in replies)
            {
                Console.WriteLine($"Body:{item.ReplyBody} \n Date: {item.ReplyDate} User: {item.ReplyUser.FirstName} {item.ReplyUser.LastName}");
                Console.WriteLine();
            }
        }
    }
}
