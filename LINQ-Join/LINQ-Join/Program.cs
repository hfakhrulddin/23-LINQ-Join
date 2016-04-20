using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };
            jointer (people, pets);
            Console.ReadLine();
        }

        //var innerGroupJoinQuery =
        //                                              from category in categories // for all categories
        //                                                                          // join with product table on product category ID
        //                                              join prod in products
        //                                              on category.ID equals prod.CategoryID into prodGroup
        //                                              // create a new object with just the product and category names
        //                                              select new { CategoryName = category.Name, Products = prodGroup };



        //var leftOuterJoinQuery =
        //                                            from category in categories
        //                                            join prod in products
        //                                            on category.ID equals prod.CategoryID into prodGroup
        //                                            from item in prodGroup.DefaultIfEmpty(new Product { Name = String.Empty, CategoryID = 0 })
        //                                            select new { CatName = category.Name, ProdName = item.Name };

        // Create a list where each element is an anonymous type
        // that contains the person's first name and a collection of 
        // pets that are owned by them.

        public static void jointer(List<Person> people, List<Pet> pets)
        {
            var query = from person in people
                        join pet in pets
                        on person equals pet.Owner
                        into gj
                        select new { OwnerName = person.Name, Pets = gj };

            foreach (var owner in query)
            {
                Console.WriteLine(owner.OwnerName);

                foreach (var pet in owner.Pets)
                { Console.WriteLine(pet.Name); }
            }
        }
    }
}
