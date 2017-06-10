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
            log.Info("All items requested".WithDate());
            using(var db = new GameShopDatabase())
            {
                return db.Items.ToList().Select(x => x.Map());
            }
        }

        public Item GetItemById(int itemId)
        {
            log.Info("Item requested".WithDate());
            using (var db = new GameShopDatabase())
            {
                var item = db.Items.Where(x => x.ItemId == itemId).FirstOrDefault();
                return item == null ? item.Map() : null;
            }
        }

        public IEnumerable<Item> GetItemsByType(ItemType itemType)
        {
            log.Info("Items by type requested".WithDate());
            using (var db = new GameShopDatabase())
            {
                var typeStr = itemType.ToString();
                return db.Items.Where(x => x.Type == typeStr).ToList().Select(x => x.Map());
            }
        }

        public IEnumerable<Item> GetItemsWithNoQty()
        {
            throw new NotImplementedException();
        }

        public bool InsertNewItem(Item item)
        {
            log.Info("Item insertion requested".WithDate());
            using (var db = new GameShopDatabase())
            {
                // jak ma dzialac jak update, to trzeba zmodyfikowac
                var itemDb = item.ReverseMap();
                db.Items.Add(itemDb);
                return db.SaveChanges() > 0;
            }
        }
    }
}
