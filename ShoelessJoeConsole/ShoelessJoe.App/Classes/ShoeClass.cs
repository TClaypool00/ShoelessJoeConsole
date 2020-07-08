using Microsoft.EntityFrameworkCore;
using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class ShoeClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddShoe(Users currentUseer)
        {
            try
            {
                var newShoe = new Shoes();

                Console.Write("What is the name of the manufacter? ");
                newShoe.Manufacter = Console.ReadLine();
                Console.WriteLine();

                Console.Write("What is the Model of the shoe(s)");
                newShoe.Model = Console.ReadLine();
                Console.WriteLine();

                BothShoes(newShoe);

                CheckGenderOfShoe(newShoe);

                Console.WriteLine("Now enter the sizes of the shoes. If the shoe doesn't exist enter 0");

                Console.Write("Please enter the right size:");
                newShoe.RightSize = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Please enter the left size:");
                newShoe.LeftSize = int.Parse(Console.ReadLine());
                Console.WriteLine();

                newShoe.IsSold = false;

                Console.Write("Please enter a description of the shoe: ");
                newShoe.Description = Console.ReadLine();
                Console.WriteLine();

                newShoe.UserId = currentUseer.UserId;

                ctx.Shoes.Add(newShoe);
                ctx.SaveChanges();
                Thread.Sleep(500);
            }
            catch(Exception)
            {
                Console.WriteLine();
                Console.Write("Something went wrong. Would you like to try again ");
                string userinput = Console.ReadLine();
                if (userinput == "y".ToLower())
                    AddShoe(currentUseer);
                else
                    StoreClass.MainMenu(currentUseer);
            }
        }

        public static bool BothShoes(Shoes currentShoe)
        {
            Console.WriteLine("Are you selling 1 shoe or 2 shoes");
            string bothShoesUserInput = Console.ReadLine();
            Console.WriteLine();

            if (bothShoesUserInput == "y".ToLower())
                currentShoe.BothShoes = true;
            else
               currentShoe.BothShoes = false;

            return currentShoe.BothShoes;
        }

        public static bool CheckGenderOfShoe(Shoes currentShoe)
        {
            Console.WriteLine("Is the shoe(s) for men or women");
            string genderOfShoeInput = Console.ReadLine();
            Console.WriteLine();

            if (genderOfShoeInput == "men".ToLower())
                currentShoe.Gender = true;
            else
                currentShoe.Gender = false;

            return currentShoe.Gender;
        }

        public static Shoes DeleteShoe(Shoes shoe)
        {

            CommentClass.DeleteCommentsByShoe(shoe);

            shoe = ctx.Shoes
                .Include(u => u.User)
                .FirstOrDefault(a => a.ShoeId == shoe.ShoeId);

            CommentClass.DeleteCommentsByShoe(shoe);

            ctx.Shoes.Remove(shoe);
            ctx.SaveChanges();

            return shoe;
        }

        public static Shoes DisplayShoe(Users user)
        {
            var shoes = ctx.Shoes
                .Include(u => u.User)
                .ToList();
            var shoe = new Shoes();

            if (shoes.Count != 0)
            {
                foreach (var item in shoes)
                {
                    Console.WriteLine($"{item.ShoeId}. Manufacter: {item.Manufacter} Model: {item.Model} Owner: {item.User.FirstName} {item.User.LastName}");
                    Console.WriteLine();
                }

                int userNumber = UserOptions(user);

                shoe = ShoeDetails(userNumber, user);

                CommentClass.AddComment(user, userNumber);
            }
            else
                Navigation.PressKeyToContenue(user);
            

            return shoe;
        }

        public static Shoes ShoeDetails(int id, Users user)
        {
            try
            {
                var shoe = ctx.Shoes
                    .Include(u => u.User)
                    .FirstOrDefault(s => s.ShoeId == id);

                string header = "Shoe Details";
                Console.WriteLine();
                Console.WriteLine(header);
                Navigation.UnderlineMessage(header);
                Console.WriteLine();
                Console.WriteLine($" Manufacter: {shoe.Manufacter} \n Model: {shoe.Model} \n Color: {shoe.Color} \n {shoe.Gender} \n Left Size: {shoe.LeftSize} Right Size: {shoe.RightSize} \n Description: {shoe.Description} \n Owner: {shoe.User.FirstName} {shoe.User.LastName}");

                Console.WriteLine();
                string userSelect;
                if (user.UserId != shoe.User.UserId)
                {
                    Console.Write("Would you to select these shoes?(y/n) ");
                    userSelect = Console.ReadLine();

                    if (userSelect == "y".ToLower())
                        return shoe;
                    else
                        return DisplayShoe(user);
                }
                else
                {
                    Console.WriteLine("You can delete this shoe by typing 'delete'");
                    Console.WriteLine("Or go back to my shoes by typing 'shoes'");
                    userSelect = Console.ReadLine();
                    if (userSelect == "delete".ToLower())
                        return DeleteShoe(shoe);
                    else if(userSelect == "shoes".ToLower())
                        return DisplayShoe(user);
                    else
                    {
                        Console.WriteLine("Not an option. Try again.");
                        return ShoeDetails(id, user);
                    }

                }
            }
            catch(NullReferenceException)
            {
                Console.Write("Shoe Does not exist. Try again: ");
                string shoeError = Console.ReadLine();

                return DisplayShoe(user);
            }
        }

        public static int UserOptions(Users user)
        {
            try
            {
                Console.Write("Please enter a number a number (or press 001 to go back): ");
                int userNumber = int.Parse(Console.ReadLine());
                Navigation.BackToMainMenu(user, userNumber);

                return userNumber;

            } catch(FormatException)
            {
                Console.WriteLine("You have to enter a number. Try again");
                return UserOptions(user);
            }
        }
    }
}
