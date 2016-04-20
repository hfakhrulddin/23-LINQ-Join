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
            jointer(people, pets);
            jointer2(people, pets);

            Category electronics = new Category { Name = "electronics", ID = 1 };
            Category books = new Category { Name = "books", ID = 2 };
            Category clothes = new Category { Name = "clothes", ID = 3 };
            Category cars = new Category { Name = "Challenger", ID = 4 };

            Product tv = new Product { Name = "tv", CategoryID = 1 };
            Product pc = new Product { Name = "pc", CategoryID = 1 };
            Product learnVB = new Product { Name = "learnVB", CategoryID = 2 };
            Product shirt = new Product { Name = "shirt", CategoryID = 3 };

            List<Category> categories = new List<Category> { electronics, books, clothes };
            List<Product> products = new List<Product> { tv, pc, learnVB, shirt };
            //jointer3(categories, products);
            jointer4(categories, products);

            Console.ReadLine();
        }

        public static void jointer(List<Person> people, List<Pet> pets)
        {
            // Create a list where each element is an anonymous type
            // that contains the person's first name and a collection of 
            // pets that are owned by them.
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

        public static void jointer2(List<Person> people, List<Pet> pets)
        {

            // Create a list where each element is an anonymous 
            // type that contains a person's name and 
            // a collection of names of the pets they own.
            var query2 =
                            people.GroupJoin(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, petCollection) =>
                                                        new
                                                        {
                                                            OwnerName = person.Name,
                                                            Pets = petCollection.Select(pet => pet.Name)
                                                        });
            foreach (var owner in query2)
            {
                Console.WriteLine(owner.OwnerName);

                foreach (var pet in owner.Pets)
                { Console.WriteLine(pet); }
            }
        }

        //public static void jointer3(List<Category> categories, List<Product> products)
        //{
        //    var innerGroupJoinQuery =
        //                                from category in categories // for all categories
        //                                join prod in products // join with product table on product category ID
        //                                on category.ID equals prod.CategoryID into prodGroup // create a new object with just the product and category names
        //                                select new { CategoryName = category.Name, Products = prodGroup };

        //    foreach (var cate in innerGroupJoinQuery)
        //    {
        //        Console.WriteLine("*******");
        //        Console.WriteLine(cate.CategoryName);
        //        Console.WriteLine("-------");

        //        foreach (var product in cate.Products)
        //        { Console.WriteLine(product.Name); }
        //    }
        //}

        public static void jointer4(List<Category> categories, List<Product> products)
        {
            var leftOuterJoinQuery =
                                                        from category in categories
                                                        join prod in products
                                                        on category.ID equals prod.CategoryID into prodGroup
                                                        from item in prodGroup.DefaultIfEmpty(new Product { Name = String.Empty, CategoryID = 0 })
                                                        select new { CatName = category.Name, ProdName = item.Name, Products = prodGroup };

            foreach (var cate in leftOuterJoinQuery)
            {
                Console.WriteLine("*******");
                Console.WriteLine(cate.CatName);
                Console.WriteLine("-------");

                foreach (var product in cate.Products)
                { Console.WriteLine(product.Name); }
            }

        }
    }
}