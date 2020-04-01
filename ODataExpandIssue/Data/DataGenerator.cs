using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data
{
    public static class DataGenerator
    {
        public static void Initialize(MyDbContext context)
        {
            context.Database.Migrate();
            if (context.Orders.Any()) return;

            var customer = new Customer
            {
                Name = "test customer",
                Type = 1,
                Cpf = "80544235002"
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            var address = new CustomerAddress
            {
                Address = "test address",
                Number = 456,
                City = "test city",
                State = "SP",
                ZipCode = "04001-001",
                Country = "BRA",
                Type = 1,
                CustomerId = customer.Id
            };
            context.CustomersAddresses.Add(address);
            context.SaveChanges();

            var category = new Category
            {
                Name = "test category",
                Order = 2
            };
            context.Categories.Add(category);
            context.SaveChanges();

            var product = new Product
            {
                Name = "test product",
                Price = 0.01m,
                StartPromotion = DateTimeOffset.Parse("2020-06-01T00:00:00Z"),
                EndPromotion = DateTimeOffset.Parse("2020-07-01T00:00:00Z"),
                Category_Id = category.Id
            };
            context.Products.Add(product);
            context.SaveChanges();

            var order = new Order
            {
                Shipment = "Fedex",
                ShipmentValue = 12.00m,
                Discount = 2.90m,
                Customer_Id = customer.Id
            };
            context.Orders.Add(order);
            context.SaveChanges();

            var productSold = new ProductSold
            {
                Order_Id = order.Id,
                Product_Id = product.Id,
                Price = 42.90m,
                Quantity = 1
            };
            context.ProductsSold.Add(productSold);
            context.SaveChanges();
        }
    }
}