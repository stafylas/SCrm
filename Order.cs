using System.Collections.Generic;



namespace ConsoleApp2

{

    class Order

    {

        public int OrderId { get; set; }

        public decimal TotalAmount { get; set; }

        public List<Product> Products;

    }

}