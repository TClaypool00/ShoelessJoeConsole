using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Threading;

namespace ShoelessJoe.App.Classes
{
    public class StoreClass
    {
        private static readonly ShoelessJoeContext ctx = new ShoelessJoeContext();

        public static void AddStore(Users user)
        {
            try
            {


                var newStore = new Stores();

                Console.Write("Enter the street address: ");
                newStore.Street = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the city: ");
                newStore.City = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the State: ");
                newStore.State = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the zip code: ");
                newStore.ZipCode = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Enter the phone number of the store: ");
                newStore.PhoneNumber = Console.ReadLine();
                Console.WriteLine();

                ctx.Stores.Add(newStore);
                ctx.SaveChanges();
                Thread.Sleep(500);

                Console.WriteLine("Store has been added");
                Navigation.MainMenu(user);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Navigation.PressKeyToContenue(user);
            }
        }
    }
}
