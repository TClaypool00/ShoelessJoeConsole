using ShoelessJoe.App.Classes;
using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App
{
    class Program
    {
        static void Main()
        {
            Users currentUser;
            
            Console.Write("Have you been here before? (y/n) ");
            string userInput = Console.ReadLine();
            Console.WriteLine();
            
            if (userInput == "y".ToLower())
                currentUser = AuthSystem.LogIn();
            else
            {
                AuthSystem.Register();
                currentUser = AuthSystem.LogIn();
            }

            StoreClass.MainMenu(currentUser);
        }


    }
}