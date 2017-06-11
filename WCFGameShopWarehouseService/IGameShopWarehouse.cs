using EFGameShopDatabase.Enums;
using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFGameShopWarehouseService
{
    [ServiceContract]
    public interface IGameShopWarehouse
    {
        [OperationContract]
        IEnumerable<Item> GetAllItems();

        [OperationContract]
        IEnumerable<Item> GetItemsByType(ItemType itemtype);

        [OperationContract]
        IEnumerable<Item> GetItemsWithNoQty();

        [OperationContract]
        bool InsertNewItem(Item item);

        [OperationContract]
        Item GetItemById(int itemid);

        [OperationContract]
        bool RemoveItem(Item item);
    }
}
