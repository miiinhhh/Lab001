using System;

namespace Bai003
{
    class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }

        public int Quantity{ get; set; }

        public Product(int id, string name, double price, int quantity = 0)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double GetTotalValue()
        {
            return Price * Quantity;
        }

        public List<Product> products = new List<Product>()
        {
            new Product(1, "Laptop", 1000, 10),
            new Product(2, "Smartphone", 500, 20),
            new Product(3, "Tablet", 300, 15),
            new Product(4, "Headphones", 150, 25),
            new Product(5, "Smartwatch", 200, 30)
        };



        public void findProduct(int quantity)
        {
            for(int i = 0; i < products.Count; i++)
            {
                if(products[i].Quantity < quantity)
                {
                    Console.WriteLine($"Product found: {products[i].Name} with quantity {quantity}");
                    return;
                }
            }
        }

        //Tính tổng giá trị kho
        public double calculateTotalInventoryValue()
        {
            double totalValue = 0;
            for(int i = 0; i < products.Count; i++)
            {
                totalValue += products[i].GetTotalValue();
            }
            return totalValue;
        }
        //Tìm sản phẩm có giá trị cao nhất
        public void findMostValuableProduct()
        {
            Product mostValuableProduct = products[0];
            for(int i = 1; i < products.Count; i++)
            {
                if(products[i].GetTotalValue() > mostValuableProduct.GetTotalValue())
                {
                    mostValuableProduct = products[i];
                }
            }
            Console.WriteLine($"Most valuable product: {mostValuableProduct.Name} with total value {mostValuableProduct.GetTotalValue()}");
        }
    }
}