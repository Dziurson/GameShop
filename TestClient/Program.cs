using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.GameShopWarehouseService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GameShopWarehouseClient client = new GameShopWarehouseClient();
            foreach (Item item in client.GetAllItems())
            {
                Console.WriteLine(item.name + " " + item.description);
            }
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
