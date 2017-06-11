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
        private static readonly ILog log = LogManager.GetLogger(typeof(GameShopWarehouse));        

        GameShopWarehouse()
        {            
            log4net.Config.XmlConfigurator.Configure();
        }

        public IEnumerable<Item> GetAllItems() 
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                log.Info("All items requested".WithDate());
                return db.GetAllItems();
            }
        }
        public Item GetItemById(int itemId)
        {            
            using (WarehouseConnection db = new WarehouseConnection())
            {
                log.Info(String.Concat("Item with id: ", itemId, " requested").WithDate());
                return db.GetItemById(itemId);                
            }
        }
        public IEnumerable<Item> GetItemsByType(ItemType itemType)
        {            
            using (WarehouseConnection db = new WarehouseConnection())
            {
                log.Info(String.Concat("Items by type: ", itemType.ToString(), " requested. ").WithDate());
                return db.GetItemByType(itemType);
            }
        }
        public IEnumerable<Item> GetItemsWithNoQty()
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                log.Info(String.Concat("Items with 0 quantity requested.").WithDate());
                return db.GetItemsWithNoQty();
            }
        }
        public bool InsertNewItem(Item item)
        {
            log.Info("Item insertion requested".WithDate());
            using (WarehouseConnection db = new WarehouseConnection())
            {
                // jak ma dzialac jak update, to trzeba zmodyfikowac
                //var itemDb = item.ReverseMap();
                //db.Items.Add(itemDb);
                //return db.SaveChanges() > 0;
                return false;
            }
        }
    }
}
