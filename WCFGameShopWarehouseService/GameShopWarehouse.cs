using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFGameShopDatabase.Entities;

namespace WCFGameShopWarehouseService
{
    public class GameShopWarehouse : IGameShopWarehouse
    {
        public void GetItems() 
        {
            Console.WriteLine("All items requested.");            
        }
    }
}
