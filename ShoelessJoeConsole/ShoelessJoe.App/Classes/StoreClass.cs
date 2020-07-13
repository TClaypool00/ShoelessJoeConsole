using ShoelessJoe.DataAccess.DataModels;
using System;
using System.Linq;
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

        public static Stores SelectStore(Users user)
        {
            try
            {
                var stores = ctx.Stores
                .ToList();

                foreach (var item in stores)
                {
                    Console.WriteLine($"{item.StoreId}. {item.Street} {item.City}, {item.State} {item.ZipCode} ");
                }

                Console.Write("Select a Store: ");
                int select = int.Parse(Console.ReadLine());

                if (select == 5)
                    Navigation.MainMenu(user);

                var store = ctx.Stores.First(s => s.StoreId == select);
                return store;
            }
            catch (Exception)
            {
                Console.Write("Store does not exsist. Try again");
                Console.ReadLine();
                Console.WriteLine();
                return SelectStore(user);
            }
        }
    }
}
