using System;
using System.Collections.Generic;
using System.Linq;
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; } = new List<Order>();
}
public class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; }
}
public interface ISearchable
{
    List<Product> SearchProducts(Func<Product, bool> criteria);
}
public class Store : ISearchable
{
    public List<User> Users { get; set; } = new List<User>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Order> Orders { get; set; } = new List<Order>();

    public List<Product> SearchProducts(Func<Product, bool> criteria)
    {
        return Products.Where(criteria).ToList();
    }
    public void AddUser(User user)
    {
        Users.Add(user);
    }
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Данiїл Iванченко, КIб-1-23-4.0д");
        Store store = new Store();
        store.AddProduct(new Product { Name = "Laptop", Price = 1000, Description = "High-end laptop", Category = "Electronics" });
        store.AddProduct(new Product { Name = "Phone", Price = 500, Description = "Smartphone", Category = "Electronics" });
        User user = new User { Login = "user1", Password = "password" };
        store.AddUser(user);
        Order order = new Order
        {
            Products = new List<Product> { store.Products[0] },
            Quantity = 1,
            TotalPrice = store.Products[0].Price,
            Status = "Pending"
        };
        store.AddOrder(order);
        user.PurchaseHistory.Add(order);
        List<Product> electronics = store.SearchProducts(p => p.Category == "Electronics");
        foreach (var product in electronics)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
    }
}
