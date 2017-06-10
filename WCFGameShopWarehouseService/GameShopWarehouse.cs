using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EFGameShopDatabase;
using EFGameShopDatabase.Models;
using log4net;
using WCFGameShopWarehouseService.Extensions;
using EFGameShopDatabase.Enums;

namespace WCFGameShopWarehouseService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    
    public class GameShopWarehouse : IGameShopWarehouse
    {
        MSSQLDatabase MSSQLdb;
        private static readonly ILog log = LogManager.GetLogger(typeof(GameShopWarehouse));

        GameShopWarehouse()
        {
            log4net.Config.XmlConfigurator.Configure();
            MSSQLdb = new MSSQLDatabase();            
        }
        public IEnumerable<Item> GetAllItems() 
        {
            log.Info("All items requested".WithDate());
            return MSSQLdb.GetAllItems();
        }

        public Item GetItemById(int itemid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItemsByType(ItemType itemtype)
        {
            return MSSQLdb.GetItemByType(itemtype);
        }

        public IEnumerable<Item> GetItemsWithNoQty()
        {
            throw new NotImplementedException();
        }

        public bool InsertNewItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
