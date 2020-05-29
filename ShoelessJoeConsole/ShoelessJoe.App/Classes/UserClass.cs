﻿using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class UserClass
    {
        /// <summary>
        /// Registers the user by asking him or her to add their info
        /// with accordance of the fields in Database
        /// </summary>
        /// <param name="ctx">Object - an instance of the context class </param>
        /// <returns> returns the new user </returns>
        public static Users Register()
        {
            using var ctx = new ShoelessJoeContext();
            var newUser = new Users();

            Console.Write("Please ener your first Name: ");
            newUser.FirstName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your last name: ");
            newUser.LastName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your email address: ");
            newUser.Email = Console.ReadLine();
            Console.WriteLine();

            var userPassword = CheckPassword(newUser);

            Console.Write("Please enter your street address: ");
            newUser.Street = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your state: ");
            newUser.Street = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Please enter your zip code: ");
            newUser.Zip = int.Parse(Console.ReadLine());
            Console.WriteLine();

            newUser.IsAdmin = false;

            Console.Write("Please enter your phone number: ");
            newUser.PhoneNumber = Console.ReadLine();
            Console.WriteLine();

            ctx.Users.Add(newUser);
            ctx.SaveChanges();
            Thread.Sleep(500);

            Console.WriteLine("You have sucessfully regeristered");

            return newUser;
        }

        /// <summary>
        /// A class to class to check the user password
        /// if the strings are not equal, calls the function again
        /// </summary>
        /// <param name="user"> User object - new user </param>
        /// <returns> returns user's password if both passwords match </returns>
        public static string CheckPassword(Users user)
        {
            Console.Write("Please enter a password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Verify password: ");
            string password2 = Console.ReadLine();
            Console.WriteLine();

            if (user.Password != password2)
            {
                Console.WriteLine("Passwords do not match. Plase try again");
                Console.WriteLine();
                CheckPassword(user);
            }

            return user.Password;
        }

        public static Users LogIn()
        {
            using var ctx = new ShoelessJoeContext();
            try
            {
                Console.WriteLine("Please enter your email address? ");
                string email = Console.ReadLine();
                Console.WriteLine("Plase enter your password");
                string password = Console.ReadLine();

                var user = ctx.Users.FirstOrDefault(u => u.Email == email);
                if (user.Password != password)
                {
                    Console.WriteLine("Sorry Username and/or password is incorrect. Would you like to try again? (y/n)");
                    string userOldNew = Console.ReadLine();
                    switch (userOldNew)
                    {
                        case "no":
                        case "No":
                            return Register();
                        case "yes":
                        case "Yes":
                        default:
                            return LogIn();
                    }
                }
                return user;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Could find that user");
                return Register();
            }
        }

        public static Users StartingPoint()
        {
            string message = "Welcome to ShoelessJoe Console Application!";
            Console.WriteLine(message);

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            Console.WriteLine("Have you been here before? ");
            string startingUserInput = Console.ReadLine();
            if (startingUserInput == "y".ToLower())
                return LogIn();
            else if (startingUserInput == "n".ToLower())
                return Register();

            return StartingPoint();
        }
    }
}
