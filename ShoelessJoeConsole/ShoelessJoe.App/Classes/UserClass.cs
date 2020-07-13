using ShoelessJoe.DataAccess.DataModels;
using System;

namespace ShoelessJoe.App.Classes
{
    public class UserClass: IChoice
    {
        public int UserChooses(Users user)
        {
            try
            {
                Console.Write("Press the coresponding number: ");
                int userOptions = int.Parse(Console.ReadLine());
                switch (userOptions)
                {
                    case 1:
                        Navigation.AboutPage(user);
                        break;
                    case 2:
                        Navigation.BrowsePage(user);
                        break;
                    case 3:
                        Navigation.ShoeFormPage(user);
                        break;
                    case 4:
                        Navigation.TechPage(user);
                        break;
                    case 5:
                        Navigation.PotentialBuyComments(user);
                        break;
                    case 6:
                        Navigation.PotentialSellcomments(user);
                        break;
                    case 7:
                        Navigation.MyShoes(user);
                        break;
                    case 8:
                        if (user.IsAdmin == true)
                            Navigation.AddStore(user);
                        else
                        {
                            Console.WriteLine("You can cannot do that. Try again.");
                            UserChooses(user);
                        }
                        break;
                    case 9:
                        if (user.IsAdmin == true)
                            Navigation.AddGroup(user);
                        else
                        {
                            Console.WriteLine("You can not do that. Try again");
                            UserChooses(user);
                        }
                        break;
                    case 10:
                        if (user.IsAdmin == true)
                            Navigation.AddFood(user);
                        else
                        {
                            Console.WriteLine("Try again.");
                            UserChooses(user);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Good-bye! Come again!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("That is not an options. Try again");
                        UserChooses(user);
                        break;
                }

                return userOptions;
            }
            catch(FormatException)
            {
                Console.WriteLine("You must enter a number. Try again.");
                return UserChooses(user);
            }
        }

        public static Users TryAgain()
        {
            string tryAgain = Console.ReadLine();

            if (tryAgain == "y".ToLower())
                return AuthSystem.LogIn();
            else if(tryAgain == "n".ToLower())
                return AuthSystem.Register();
            else
            {
                Console.WriteLine("Not an option Try again");
                return TryAgain();
            }
                
        }
    }
}
