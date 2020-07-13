using Microsoft.EntityFrameworkCore;
using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoelessJoe.App.Classes
{
    public class FoodClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddFoodGroup(Users user)
        {
            try
            {
                var newFoodGroup = new FoodGroup();

                Console.Write("Enter the name of a food group: ");
                newFoodGroup.FoodGroups = Console.ReadLine();
                Console.WriteLine();

                ctx.FoodGroup.Add(newFoodGroup);
                ctx.SaveChanges();
                Console.WriteLine();
            }
            catch(Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
            Navigation.MainMenu(user);
        }

        public static void AddFood(Users user)
        {
            try
            {
                var newFood = new Foods();

                Console.Write("Enter the group it belongs to: ");
                newFood.FoodGroupId = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Ener the name of food: ");
                newFood.FoodTitle = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the price of the food: ");
                newFood.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Enter the quantity of item: ");
                newFood.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine();

                ctx.Foods.Add(newFood);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong.");
            }
            Navigation.MainMenu(user);
        }

        public static List<FoodGroup> GetGroups()
        {
            var group = ctx.FoodGroup
                .ToList();

            return group;
        }

        public static FoodGroup GetGroup(int id)
        {
            var food = ctx.FoodGroup
                .FirstOrDefault(f => f.FoodGroupId == id);

            return food;
        }

        public static List<Foods> GetFoodsByGroup(int id)
        {
            var foods = ctx.Foods
                .Include(f => f.FoodGroup)
                .Where(s => s.FoodGroupId == id)
                .ToList();

            return foods;
        }

        public static Foods GetFoodById(int id)
        {
            var food = ctx.Foods
                .Include(f => f.FoodGroup)
                .FirstOrDefault(f => f.FoodId == id);

            return food;
        }

        public static void DisplayFood(List<Foods> foods)
        {
            foreach (var item in foods)
            {
                Console.WriteLine($"{item.FoodId}. {item.FoodTitle} {item.FoodGroup.FoodGroups} {item.Price:C2}");
            }
        }
    }
}
