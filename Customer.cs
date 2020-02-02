using System.Collections.Generic;



namespace ConsoleApp2

{

    class Customer : Person

    {

        public int CustomerId { get; set; }



        public List<Order> Orders { get; set; }



        public Customer(string lastname)

            : base(lastname)

        {

            Orders = new List<Order>();

        }

    }

}