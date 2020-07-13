using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App.Classes
{
    public class Navigation
    {
        public static void AboutPage(Users user)
        {
            string aboutHeader = "About Page";

            Console.WriteLine(aboutHeader);
            UnderlineMessage(aboutHeader);
            Console.WriteLine();

            Console.WriteLine("About ShoelessJoe");
            Console.WriteLine("Have you ever tried to buy shoes in different sizes or even just one shoe? It's nearly impossible. I am ver blessed to have a mother who can afford to purchase two pairs of shoes so I could have one that fits. I want this organization to benefit others who may have different size feet or perhaps one foot. I know thereare others out there with Cerebral Palsy, cancer, birth defects, amputees, or veterans who could be helped by this project. The group will only grow if others are willing to donate their if others are willing to donatthem to people in need who give from their from their heart for the shoe(s) are worth to them.");
            Console.WriteLine();
            Console.WriteLine("About Me");
            Console.WriteLine();
            Console.WriteLine("My name is Tyler Claypool. This product is very special to me. I was born too early in the country of Guatemala. I was adopted at 6 months of age.At 18 months I was diagnosed with Cerebral Palsy.I was never able to crawl and did learn to walk until I was 4.I have had numerous surgeries.My last surgery involved a bone graft to my left foot.After the graft, my left quit growing while my right kept growing.I remember the first time my mother offered to buy me two different pairs of shoes. After years of a size 6.5 on my left foot and a 9 on my right, I have boxes of mismatched shoes that someone must need.");

            Console.WriteLine();
            PressKeyToContenue(user);
        }

        public static void BrowsePage(Users user)
        {
            string browseHeader = "Browse Page";

            Console.WriteLine(browseHeader);
            UnderlineMessage(browseHeader);
            Console.WriteLine();
            ShoeClass.DisplayShoe(user);

            Console.WriteLine();
            MainMenu(user);
        }

        public static void ShoeFormPage(Users user)
        {
            string shoeFormHeader = "Shoe Form Page";

            Console.WriteLine(shoeFormHeader);
            UnderlineMessage(shoeFormHeader);
            Console.WriteLine();
            ShoeClass.AddShoe(user);

            Console.WriteLine();
            PressKeyToContenue(user);
        }

        public static void TechPage(Users user)
        {
            string techPageHeader = "Tech Page";

            Console.WriteLine(techPageHeader);
            UnderlineMessage(techPageHeader);
            Console.WriteLine();
            Console.WriteLine("About ShoelessJoe Console's Technical Side");
            Console.WriteLine("This console application was written in C# and uses a database in 3rd Normalizatino. It is being hosted on Azure Portal, but it is written in SQL");

            Console.WriteLine();

            PressKeyToContenue(user);
        }

        public static void PotentialBuyComments(Users user)
        {
            string myCommentsHeader = "Potential Buy Comments";

            Console.WriteLine(myCommentsHeader);
            UnderlineMessage(myCommentsHeader);
            Console.WriteLine();

            CurrentUser.CurrentUserBuyComments(user);
        }

        public static void PotentialSellcomments(Users user)
        {
            string mySellComments = "Potential Sell Comments";

            Console.WriteLine(mySellComments);
            UnderlineMessage(mySellComments);
            Console.WriteLine();

            CurrentUser.CurrentUserSellComment(user);
            
        }

        public static void MyShoes(Users user)
        {
            string myShoes = "My Shoes";

            Console.WriteLine(myShoes);
            UnderlineMessage(myShoes);
            Console.WriteLine();

            CurrentUser.MyShoes(user);
        }

        public static void AddStore(Users user)
        {
            string addStore = "Add a store";

            Console.WriteLine(addStore);
            UnderlineMessage(addStore);
            Console.WriteLine();
            StoreClass.AddStore(user);
        }

        public static void AddGroup(Users user)
        {
            string header = "Add a Food Group";

            Console.WriteLine(header);
            UnderlineMessage(header);
            Console.WriteLine();
            FoodClass.AddFoodGroup(user);
        }

        public static void AddFood(Users user)
        {
            string header = "Add a food";

            Console.WriteLine(header);
            UnderlineMessage(header);
            Console.WriteLine();
            FoodClass.AddFood(user);
        }

        public static void MainMenu(Users user)
        {
            Console.WriteLine($"Hello, {user.FirstName}!");
            Console.WriteLine();
            var userOptions = new UserClass();
            string[] menuSelection = { "About Page", "Browse Page", "Shoe Form", "Tech Page", "My Potential Buys", "My Potential Sells", "My Shoes" };

            Console.WriteLine("Below are a list of the following pages you can visit");

            for (int i = 0; i <= menuSelection.Length - 1; i++)
            {
                Console.WriteLine($"{i + 1}. {menuSelection[i]}");
            }

            if (user.IsAdmin == true)
            {
                Console.WriteLine("8. Add Store");
                Console.WriteLine("9. Add a food Group");
                Console.WriteLine("10. Add a Food");
            }

            Console.WriteLine("0. Exit");
            Console.WriteLine();

            userOptions.UserChooses(user);
            Console.WriteLine();
        }

        public static void Menu(Users user, Stores store)
        {
            var foods = FoodClass.GetGroups();

            Console.WriteLine($"Welcome {user.FirstName} to the restruant on {store.Street} in {store.State}");
            Console.WriteLine();
            Console.WriteLine("Below is a list of the food types we offer.");

            foreach (var item in foods)
            {
                Console.WriteLine($"{item.FoodGroupId}. {item.FoodGroups}");
            }

            Console.WriteLine($"{foods.Count + 1}. My Orders");

            Console.Write("Please select a number: ");
            int selection = int.Parse(Console.ReadLine());
            var group = FoodClass.GetGroup(selection);
            var foodByGroup = FoodClass.GetFoodsByGroup(group.FoodGroupId);
            FoodClass.DisplayFood(foodByGroup);
            Console.Write("Please select a number: ");

            int foodSelect = int.Parse(Console.ReadLine());
            var food = FoodClass.GetFoodById(foodSelect);

            OrderClass.AddOrder(user, store, food);
        }

        public static void UnderlineMessage(string message)
        {
            for (int i = 0; i <= message.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void PressKeyToContenue(Users user)
        {
            Console.Write("Press any key to back to the main menu");
            Console.ReadLine();
            MainMenu(user);
        }

        public static void BackToMainMenu(Users user, int choice)
        {
            if (choice == 001)
                MainMenu(user);
        }

        public static void BackToMainMenu(Users user, string choice)
        {
            if (choice == "001")
                MainMenu(user);
        }
    }
}
