using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App.Classes
{
    public class Navigation
    {
        private static readonly Users currentUser = new Users();
        public static void AboutPage()
        {
            string aboutHeader = "About Page";

            Console.WriteLine(aboutHeader);
            UnderlineMessage(aboutHeader);
            Console.WriteLine();
            Console.WriteLine(" This is the about Page!");

            Console.WriteLine();
            PressKeyToContenue();
        }
        
        public static void BrowsePage()
        {
            string browseHeader = "Browse Page";

            Console.WriteLine(browseHeader);
            UnderlineMessage(browseHeader);
            Console.WriteLine();
            Console.WriteLine(" This is the browse Page!");

            Console.WriteLine();
            PressKeyToContenue();
        }

        public static void ShoeFormPage(Users currentUser)
        {
            string shoeFormHeader = "Shoe Form Page";

            Console.WriteLine(shoeFormHeader);
            UnderlineMessage(shoeFormHeader);
            Console.WriteLine();
            ShoeClass.AddShoe(currentUser);

            Console.WriteLine();
            PressKeyToContenue();
        }

        public static void TechPage()
        {
            string techPageHeader = "Tech Page";

            Console.WriteLine(techPageHeader);
            UnderlineMessage(techPageHeader);
            Console.WriteLine();
            Console.WriteLine(" This is the Tech Page Page!");

            Console.WriteLine();
            PressKeyToContenue();
        }


        public static void UnderlineMessage(string message)
        {
            for (int i = 0; i <= message.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void PressKeyToContenue()
        {
            Console.Write("Press any key to back to the main menu");
            Console.ReadLine();
            StoreClass.MainMenu(currentUser);
        }
    }
}
