using ShoelessJoe.App.Classes;
using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App
{
    class Program
    {
        static void Main()
        {
            Users currentUser = new Users();

            StartingPoint(currentUser);
        }

        static void StartingPoint(Users user)
        {
            Console.Write("Have you been here before? (y/n) ");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (userInput == "y".ToLower())
                user = AuthSystem.LogIn();
            else if(userInput == "n".ToLower())
            {
                AuthSystem.Register();
                user = AuthSystem.LogIn();
            }
            else
            {
                Console.WriteLine("That's not an option. Try again");
                StartingPoint(user);
            }

            StoreClass.MainMenu(user);
        }
    }
}