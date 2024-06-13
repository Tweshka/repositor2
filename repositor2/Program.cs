using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System;


public abstract class Delivery
{
    public string Address { get; private set; }
    public Delivery(string address)
    {
        Address = address;
    }

    
    public abstract decimal CalculateDeliveryCost();
}


public class HomeDelivery : Delivery
{
    public HomeDelivery(string address) : base(address) { }

    public override decimal CalculateDeliveryCost()
    {
        return 10; 
    }
}

public class PickPointDelivery : Delivery
{
    public PickPointDelivery(string address) : base(address) { }

    public override decimal CalculateDeliveryCost()
    {
        return 5; 
    }
}

public class ShopDelivery : Delivery
{
    public ShopDelivery(string address) : base(address) { }

    public override decimal CalculateDeliveryCost()
    {
        return 0; 
    }
}


public class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}


public class Order<TDelivery> where TDelivery : Delivery
{
   
    public TDelivery Delivery { get; private set; }

    
    public int Number { get; private set; }


    private List<Product> _products;

    
    public string Description { get; private set; }

    public Order(int number, TDelivery delivery, string description)
    {
        Number = number;
        Delivery = delivery;
        Description = description;
        _products = new List<Product>();
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        foreach (var product in _products)
        {
            totalCost += product.Price * product.Quantity;
        }
        return totalCost + Delivery.CalculateDeliveryCost();
    }

   
    public void DisplayOrder()
    {
        Console.WriteLine($"Заказ №{Number}: {Description}");
        Console.WriteLine("Товары:");
        foreach (var product in _products)
        {
            Console.WriteLine($"{product.Quantity} x {product.Name} - {product.Price * product.Quantity}");
        }
        Console.WriteLine($"Стоимость доставки: {Delivery.CalculateDeliveryCost()}");
        Console.WriteLine($"Общая стоимость: {CalculateTotalCost()}");
        Console.WriteLine($"Адрес доставки: {Delivery.Address}");
    }
}


public class Program
{
    public static void Main(string[] args)
    {
       
        var homeDelivery = new HomeDelivery("Ул. Ленина, д. 10");

        
        var order = new Order<HomeDelivery>(123, homeDelivery, "Заказ одежды");

       
        order.AddProduct(new Product("Футболка", 10, 2));
        order.AddProduct(new Product("Штаны", 20, 1));

       
        order.DisplayOrder();
    }
}

































