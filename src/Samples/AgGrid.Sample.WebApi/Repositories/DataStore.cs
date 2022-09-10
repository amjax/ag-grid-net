using AgGrid.Sample.WebApi.Models;

namespace AgGrid.Sample.WebApi.Repositories;

    public class DataStore
    {
        public static IQueryable<Order> Orders()
        {
            return new List<Order>
        {
            new Order
            {
                Id = 1,
                Date = DateTime.Now,
                Items = new List<OrderItem>
                {
                    new OrderItem { Id = 1, Title = "CPU", Quantity = 1, Amount = 1000 },
                    new OrderItem { Id = 2, Title = "RAM", Quantity = 2, Amount = 700 },
                    new OrderItem { Id = 3, Title = "SSD", Quantity = 1, Amount = 500 },
                },
            },

            new Order
            {
                Id = 2,
                Date = DateTime.Now.AddDays(1),
                Items = new List<OrderItem>
                {
                    new OrderItem { Id = 4, Title = "Laptop", Quantity = 1, Amount = 2000 },
                    new OrderItem { Id = 5, Title = "keyboard", Quantity = 1, Amount = 250 },
                },
            },

            new Order
            {
                Id = 3,
                Date = DateTime.Now.AddDays(2),
                Items = new List<OrderItem>
                {
                    new OrderItem { Id = 6, Title = "Kindle", Quantity = 1, Amount = 400 },
                },
            },
        }.AsQueryable();
        }
    }
