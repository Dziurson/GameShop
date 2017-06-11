using EFGameShopDatabase.Extensions;
using EFGameShopDatabase.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameShopDatabase
{
    public class OrderConnection : IDisposable
    {
        private GameShopDatabase MSSQLdb;
        private static readonly ILog log = LogManager.GetLogger(typeof(OrderConnection));

        public OrderConnection()
        {
            try
            {
                MSSQLdb = new GameShopDatabase();
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                log.Info("Database Orders extraction started".WithDate());
                IEnumerable<Order> result = MSSQLdb.Orders.ToList().Select(item => item.Map());
                log.Info("Database Orders extraction completed".WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error("Database Orders extraction failed".WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Order> GetUserOrders(User user)
        {
            try
            {
                log.Info(String.Concat("Database Orders with user id: ", user.UserId, " extraction started").WithDate());
                IEnumerable<Order> result = MSSQLdb.Orders.Where(order => order.UserId == user.UserId).ToList().Select(order => order.Map());
                log.Info(String.Concat("Database Users with user id: ", user.UserId, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database User with user id: ", user.UserId, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
            try
            {
                log.Info(String.Concat("Database Order with id: ", id, " extraction started").WithDate());
                Order result = MSSQLdb.Orders.Where(order => order.OrderId == id).ToList().FirstOrDefault().Map();
                log.Info(String.Concat("Database Order with id: ", id, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database Order with id: ", id, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Order> GetUndeliveredOrders()
        {
            try
            {
                log.Info("Database Orders extraction started".WithDate());
                IEnumerable<Order> result = MSSQLdb.Orders.Where(order => order.DeliveryDate == null).ToList().Select(order => order.Map());
                log.Info("Database Orders extraction completed".WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error("Database Orders extraction failed".WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<Order> GetDeliveredOrders()
        {
            try
            {
                log.Info("Database Orders extraction started".WithDate());
                IEnumerable<Order> result = MSSQLdb.Orders.Where(order => order.DeliveryDate != null).ToList().Select(order => order.Map());
                log.Info("Database Orders extraction completed".WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error("Database Orders extraction failed".WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
