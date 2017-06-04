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
        Item[] GetAllItems();
    }
}
