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
            StoreClass.MainMenu(user);
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
            Console.WriteLine(" This is the Tech Page Page!");

            Console.WriteLine();
            PressKeyToContenue(user);
        }

        public static void PotentialBuyComments(Users user)
        {
            string myCommentsHeader = "Potential Buy Comments";

            Console.WriteLine(myCommentsHeader);
            UnderlineMessage(myCommentsHeader);
            Console.WriteLine();

            CommentClass.CurrentUserBuyComments(user);
        }

        public static void PotentialSellcomments(Users user)
        {
            string mySellComments = "Potential Sell Comments";

            Console.WriteLine(mySellComments);
            UnderlineMessage(mySellComments);
            Console.WriteLine();

            CommentClass.CurrentUserSellComment(user);
            
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
            StoreClass.MainMenu(user);
        }

        public static void BackToMainMenu(Users user, int choice)
        {
            if (choice == 001)
                StoreClass.MainMenu(user);
        }
    }
}
