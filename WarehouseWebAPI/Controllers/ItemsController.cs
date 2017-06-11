using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFGameShopDatabase;
using EFGameShopDatabase.Models;

namespace WarehouseWebAPI.Controllers
{
    public class ItemsController : ApiController
    {
        // GET: api/Items
        public IEnumerable<Item> Get()
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                return db.GetAllItems();
            }              
        }

        // GET: api/Items/5
        public Item Get(int id)
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                return db.GetItemById(id);
            }
        }

        // POST: api/Items
        public void Post(Item item)
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                db.InsertNewItem(item);
            }

        }

        // PUT: api/Items/5
        public void Put(int id, Item item)
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                if (db.GetItemById(id) != null)
                    db.UpdateItem(item);
                else
                    db.InsertNewItem(item);
            }
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
            using (WarehouseConnection db = new WarehouseConnection())
            {
                db.DeleteItem(id);
            }
        }
    }
}
