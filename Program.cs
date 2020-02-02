using System;

using System.Linq;

using System.Collections.Generic;
using System.IO;


namespace ConsoleApp2

{

    class Program

    {
        public static List<string> productIdList = new List<string>();
        public static List<Product> productList = new List<Product>();


        public static ILogger Logger;



        static void Main(string[] args)

        {

            Logger = FileLogger.GetInstance();

            //Console.WriteLine("Please enter your Lastname:");

            //var lastName = Console.ReadLine();

            //Console.WriteLine("please enter your first name:");

            //var firstName = Console.ReadLine();

            //var age = GetAge();

            //if (age == null) {

            //    return;

            //}

            //var person1 = default(Person);

            //try {

            //    person1 = new Person(lastName);

            //    person1.Age = age.Value;

            //    person1.FirstName = firstName;

            //} catch (Exception e) {

            //    Logger.Log(e);

            //    return;
            //}

            //Console.WriteLine(@$"Your lastname is {person1.LastName},

            //    your firstname is {person1.FirstName} and you are

            //    {(person1.IsAdult() ? "" : "not")} an adult");


            // using (FileStream stream = File.Open("C:/Users/KCA9/Downloads/kl-oop-master/kl-oop-master/products", FileMode.Open))
            //  using (BinaryReader reader = new BinaryReader(stream)) 
            string path = @"C:/Users/KCA9/Downloads/kl-oop-master/kl-oop-master/products.csv";
            //string readText = File.ReadAllText(path);
            //Console.WriteLine(readText);
            readFile(path);

            Customer customer1 = new Customer(" stafylas ");
            Customer customer2 = new Customer(" papadopoulos ");

            Order order1 = new Order();
            Order order2 = new Order();

            order1.Products = (CustomerList(productList));
            order2.Products=  (CustomerList(productList));

            foreach (Product i in order1.Products) {
                Console.WriteLine(i.ProductDescription);
                Console.WriteLine(i.ProductID);
            }
            customer1.Orders.Add(order1);
            customer2.Orders.Add(order2);

        }

        public static int? GetAge()

        {
            Console.WriteLine("please enter your age:");

            var value = Console.ReadLine();

            if (!int.TryParse(value, out var age)) {
                Logger.Log($"Value {value} is not a valid age");
                Console.WriteLine("Age is not a number");
                return null;
            }
            return age;

        }
        public static void readFile(string path)
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null) {
                var words = line.Split(';');
                var p = new Product();
                p.ProductID = words[0];
                p.ProductDescription = words[1];
                p.ProductPrice = RandomPrice();
                productList.Add(p);
                productIdList.Add(words[0]);
                checkForDuplicates(productIdList, words[0]);
               
            }
            
            //foreach (Product item in productList)
            //    Console.WriteLine(item.ProductID);
            file.Close();
        }
        public static decimal RandomPrice()
        {
            var num = (new Random().NextDouble() * (new Random()).Next(1000)).ToString("0.00");
            var number = System.Convert.ToDecimal(num);
            return number;
        }
        public static bool checkForDuplicates(List<string> productlist, string productid)
        {
            if (!string.IsNullOrWhiteSpace(productid)) {
                productlist.SingleOrDefault(select => select.Equals(productid));
                return false;
            } else {
                throw new Exception("There is another Product Id");
            }
        }
        public static List<Product> CustomerList(List<Product> productlist)
        {
            var customerList = new List<Product>();
            Random random = new Random();
            for (var i = 0; i < 10; i++) {
                int num = random.Next(29);
                customerList.Add(productList[num]);
            }
            return customerList;
        }


    }

}