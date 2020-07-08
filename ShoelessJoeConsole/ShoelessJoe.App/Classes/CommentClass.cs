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
            try
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
            catch(Exception)
            {
                Console.WriteLine("Something went wrong. Would you like to try again? (y/n)");
                string input = Console.ReadLine();

                if (input == "y".ToLower())
                    AddComment(user, id);
                else
                    StoreClass.MainMenu(user);

            }
        }

        public static void DeleteComment(Comments comment)
        {
            comment = ctx.Comments
                .Include(u => u.Buyer)
                .Include(s => s.Shoe)
                .ThenInclude(u => u.User)
                .FirstOrDefault(a => a.CommentId == comment.CommentId);
            ctx.Comments.Remove(comment);
            ctx.SaveChanges();
            Console.WriteLine("Comment has been deleted");
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

            ReplyClass.DisplyReplies(comment, user);

            OptionsCommentDetails(comment, user);
            StoreClass.MainMenu(user);
        }

        public static void SelectComment(Users user)
        {
            Console.Write("Select a comment (or press 001 to go back): ");
            int userSelect = int.Parse(Console.ReadLine());
            Navigation.BackToMainMenu(user, userSelect);
            CommentDetails(userSelect, user);
        }

        public static void OptionsCommentDetails(Comments comment, Users user)
        {
            Console.WriteLine("Below are a list of options you can perform. (Type '001' to go back to the Main Menu) Casing doesn't matter");
            Console.WriteLine();
            if (comment.Shoe.User.UserId == user.UserId)
            {
                Console.WriteLine("If you are the owner of the shoe. You can type 'approve' to approve the sale");
                Console.WriteLine("Or type 'deny' to deny the sale");
            }
            Console.WriteLine();
            string[] options = { "Reply", "Cancel" };

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($" {options[i]}");
                Console.WriteLine();
            }
            string userSelection = Console.ReadLine();
            UserSelects(userSelection, comment, user);
        }

        public static void DeleteCommentsByShoe(Shoes shoe)
        {
            var comments = ctx.Comments
                .Include(u => u.Buyer)
                .Include(s => s.Shoe)
                .ThenInclude(d => d.User)
                .Where(a => a.Shoe.ShoeId == shoe.ShoeId);

            ctx.Remove(comments);
            ctx.SaveChanges();
        }

        public static void UserSelects(string option, Comments comment, Users user)
        {
            switch (option)
            {
                case "reply":
                case "Reply":
                    ReplyClass.CreateReply(comment, user);
                    break;
                case "cancel":
                case "Cancel":
                    DeleteComment(comment);
                    break;
                case "001":
                    Navigation.BackToMainMenu(user, option);
                    break;
                case "approve":
                case "Approve":
                    if (comment.Shoe.User.UserId == user.UserId)
                        DeleteComment(comment);
                    else
                    {
                        Console.WriteLine("You can not do that");
                        UserSelects(option, comment, user);
                    }
                    break;
                case "deny":
                case "Deny":
                    if (comment.Shoe.User.UserId == user.UserId)
                        DeleteComment(comment);
                    else
                    {
                        Console.WriteLine("You can not do that");
                        UserSelects(option, comment, user);
                    }
                    break;
                default:
                    Console.WriteLine("Not an option. Please try again");
                    UserSelects(option, comment, user);
                    break;
            }
        }
    }
}
