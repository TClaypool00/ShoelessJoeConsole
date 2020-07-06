using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App.Classes
{
    class StoreClass
    {
        public static Users MainMenu()
        {
            var userOptions = new UserClass();

            var currentUser = UserClass.LogIn();
            Console.WriteLine();
            Console.WriteLine($"Hello, {currentUser.FirstName }!");
            MenuOptions();
            userOptions.UserChooses();

            return currentUser;
        }

        static void MenuOptions()
        {
            string[] menuSelection = { "About Page", "Browse Page", "Shoe Form", "Tech Page" };

            Console.WriteLine("Below are a list of the following pages you can visit");
            for (int i = 0; i <= menuSelection.Length; i++)
            {
                Console.WriteLine($"{i}. {menuSelection[i++]}");
            }
            Console.WriteLine();
        }
    }
}
