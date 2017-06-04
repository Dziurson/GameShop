using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EFGameShopDatabase;
using EFGameShopDatabase.Models;

namespace WCFGameShopWarehouseService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    
    public class GameShopWarehouse : IGameShopWarehouse
    {
        MSSQLDatabase MSSQLdb;

        GameShopWarehouse()
        {
            MSSQLdb = new MSSQLDatabase();            
        }
        public Item[] GetAllItems() 
        {
            Console.WriteLine("All Items Requested.");
            return MSSQLdb.GetAllItems();
        }
    }
}
