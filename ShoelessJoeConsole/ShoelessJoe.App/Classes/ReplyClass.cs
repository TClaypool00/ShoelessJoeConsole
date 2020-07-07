using ShoelessJoe.DataAccess.DataModels;
using System;
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


    }
}
