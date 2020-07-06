﻿using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App.Classes
{
    public class StoreClass
    {
        public static Users PromptUser()
        {
            var currentUser = UserClass.LogIn();
            Console.WriteLine();
            Console.WriteLine($"Hello, {currentUser.FirstName }!");
            MainMenu();
            

            return currentUser;
        }

        public static void MainMenu()
        {
            var userOptions = new UserClass();
            string[] menuSelection = { "About Page", "Browse Page", "Shoe Form", "Tech Page" };

            Console.WriteLine("Below are a list of the following pages you can visit");

            for (int i = 0; i <= menuSelection.Length - 1; i++)
            {
                Console.WriteLine($"{i + 1}. {menuSelection[i]}");
            }
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            userOptions.UserChooses();
        }
    }
}
