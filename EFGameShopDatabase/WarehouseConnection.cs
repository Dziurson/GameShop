using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using EFGameShopDatabase.Extensions;
using EFGameShopDatabase.Enums;

namespace EFGameShopDatabase
{
    public class WarehouseConnection : IDisposable
    {
        #region local_fields

        private GameShopDatabase MSSQLdb;
        private static readonly ILog log = LogManager.GetLogger(typeof(WarehouseConnection));

        #endregion

        #region constructors

        public WarehouseConnection()
        {            
            try
            {
                MSSQLdb = new GameShopDatabase();
            }
            catch(Exception e)
            {
                log.Fatal(e.Message);                
            }
        }

        #endregion

        #region private_methods

        private bool Commit()
        {
            try
            {
                log.Info("Saving changes to database - started".WithDate());
                MSSQLdb.SaveChanges();
                log.Info("Saving changes to database - completed".WithDate());
                return true;
            }
            catch (Exception e)
            {
                log.Error("Saving changes to database - failed".WithDate());
                return false;
            }
        }

        #endregion

        #region public_methods

        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                log.Info("Database Items extraction started".WithDate());
                IEnumerable<Item> result = MSSQLdb.Items.ToList().Select(item => item.Map());
                log.Info("Database Items extraction completed".WithDate());
                return result;
            }
            catch
            {
                log.Error("Database Items extraction failed".WithDate());
                return null;
            }            
        }
        public IEnumerable<Item> GetItemByType(ItemType itemtype)
        {
            string typestr = itemtype.Map();
            try
            {          
                log.Info(String.Concat("Database Items with type: ", typestr, " extraction started").WithDate());
                IEnumerable<Item> result = MSSQLdb.Items.Where(item => item.Type == typestr).ToList().Select(item => item.Map());
                log.Info(String.Concat("Database Items with type: ", typestr, " extraction completed").WithDate());
                return result;
            }
            catch
            {
                log.Error(String.Concat("Database Items with type: ", typestr, " extraction failed").WithDate());
                return null;
            }
        } 
        public Item GetItemById(int id)
        {
            try
            {
                log.Info(String.Concat("Database Item with id: ", id, " extraction started").WithDate());
                Item result = MSSQLdb.Items.Where(item => item.ItemId == id).ToList().Select(item => item.Map()).FirstOrDefault();
                log.Info(String.Concat("Database Item with type: ", id, " extraction completed").WithDate());
                return result;
            }
            catch
            {
                log.Error(String.Concat("Database Item with type: ", id, " extraction failed").WithDate());
                return null;
            }
        }
        public IEnumerable<Item> GetItemsWithNoQty()
        {
            try
            {
                log.Info("Database Items with 0 quantity extraction started".WithDate());
                IEnumerable<Item> result = MSSQLdb.Items.Where(item => item.AvailableQuantity == 0).ToList().Select(item => item.Map());
                log.Info("Database Items with 0 quantity extraction completed".WithDate());
                return result;
            }
            catch
            {
                log.Error("Database Items with 0 quantity extraction failed".WithDate());
                return null;
            }
        }
        public bool InsertNewItem(Item item)
        {
            MSSQLdb.Items.Add(item.ReverseMap());
            return Commit();
        }
        public bool InsertNewItems(IEnumerable<Item> items)
        {
            foreach(Item item in items)
            {
                MSSQLdb.Items.Add(item.ReverseMap());
            }
            return Commit();
        }

        public bool UpdateItem(Item item)
        {
            var res = GetItemById(item.ItemId);
            res = item;
            log.Info(String.Concat("Database Item with id: ", item.ItemId, " has been changed").WithDate());
            return Commit();
        }

        public bool DeleteItem(int id)
        {
            Item item = GetItemById(id);
            if (item != null)
            { 
                MSSQLdb.Items.Remove(item.ReverseMap());
                log.Info(String.Concat("Database Item with id: ", id, " has been deleted").WithDate());
            }
            return Commit();
        }

        public void Dispose()
        {
            MSSQLdb.Dispose();
        }

        #endregion       
    }
}
