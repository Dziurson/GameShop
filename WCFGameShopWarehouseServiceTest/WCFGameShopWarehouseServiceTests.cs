using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFGameShopWarehouseServiceTest.GameShopWarehouseService;
using System.Collections.Generic;

namespace GameShopWarehouseServiceTest
{
    [TestClass]
    public class WCFGameShopWarehouseServiceTests
    {        
        [TestMethod]
        public void GetItemByIdTest()
        {
            using (GameShopWarehouseClient client = new GameShopWarehouseClient())
            {
                Item item = client.GetItemById(1);
                Assert.IsNotNull(item);
                Assert.AreEqual("przedmiot", item.Name);
                Assert.AreEqual((Decimal)19.99, item.Price);
                Assert.AreEqual(0.23, item.TaxRate);
                Assert.AreEqual("pcs", item.Unit);
                Assert.AreEqual("game", item.Type);
                Assert.AreEqual(10, item.AvailableQuantity);
                Assert.AreEqual(15, item.LoyalityPoints);                
            }
        }

        [TestMethod]
        public void GetItemsWithNoQtyTest()
        {
            using (GameShopWarehouseClient client = new GameShopWarehouseClient())
            {
                Item[] items = client.GetItemsWithNoQty();
                Assert.AreEqual(1, items.Length);
            }
        }

        [TestMethod]
        public void GetItemsByTypeTest()
        {
            using (GameShopWarehouseClient client = new GameShopWarehouseClient())
            {
                Item[] items = client.GetItemsByType(ItemType.Console);
                Item[] items_1 = client.GetItemsByType(ItemType.GameBox);
                Item[] items_2 = client.GetItemsByType(ItemType.GameDigital);
                Assert.AreEqual(0, items.Length);
                Assert.AreEqual(3, items_1.Length);
                Assert.AreEqual(1, items_2.Length);
            }
        }

        [TestMethod]
        public void GetAllItemsTest()
        {
            using (GameShopWarehouseClient client = new GameShopWarehouseClient())
            {
                Item[] items = client.GetAllItems();
                Assert.AreEqual(12, items.Length);
            }
        }

        [TestMethod]
        public void RemoveAndInsertItemTest()
        {
            using (GameShopWarehouseClient client = new GameShopWarehouseClient())
            {
                Item item = client.GetItemById(0);
                Assert.IsTrue(client.RemoveItem(item));
                Assert.IsTrue(client.InsertNewItem(item));
            }
        }
    }
}
