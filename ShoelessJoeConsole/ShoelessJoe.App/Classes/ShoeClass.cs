﻿using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class ShoeClass
    {
        public static void AddShoe(Users currentUseer)
        {
            using var ctx = new ShoelessJoeContext();
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
    }
}