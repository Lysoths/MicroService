using basketApi.Context;
using DotNetCore.CAP;
using orderApi.Models;

namespace orderApi.Services
{
    public class OrderService
    {
        orderDbContext orderDbContext;
        

        public OrderService()
        {

            orderDbContext = new orderDbContext();
        }

        public Order InsertOrder(Order order)
        {
            orderDbContext.Orders.Add(order);
            orderDbContext.SaveChanges();
            return order;
        }

        public Order UpdateOrder(Order order)
        {
            orderDbContext.Orders.Update(order);
            orderDbContext.SaveChanges();
            return order;
        }

        public Order DeleteOrder(Order order)
        {
            var data = orderDbContext.Orders.Where(o => o.Id == order.Id).FirstOrDefault();
            if (data != null)
            {
                orderDbContext.Remove(data);
                orderDbContext.SaveChanges();
                return order;
            }
            else
            {
                return order;
            }

        }

        public List<Order> GetAll()
        {
            var data = orderDbContext.Orders.ToList();

            return data;

        }

        public List<Order> GetCustomerOrderCount(int id)
        {
            var data = orderDbContext.Orders.Where(x => x.customerid == id).ToList();

            return data;

        }

        public List<Order> getOrdersByCustomerId(int customerId)
        {
            var data = orderDbContext.Orders.Where(x => x.customerid == customerId).ToList();

            return data;

        }

        public List<Order> getOrdersByProductId(int productId)
        {
            var data = orderDbContext.Orders.Where(x => x.ProductId.Contains(productId)).ToList();
           
            return data;

        }

  


        


    }
}
