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
    public class MSSQLDatabase
    {
        private GameShopDatabase MSSQLdb;
        private static readonly ILog log = LogManager.GetLogger(typeof(MSSQLDatabase));

        public MSSQLDatabase()
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

        public IEnumerable<Item> GetAllItems()
        {
            try
            {
                IEnumerable<Item> result = MSSQLdb.Items.ToList().Select(item => item.Map());
                log.Info(DateTime.Now + "Database Items extraction completed.");
                return result;
            }
            catch
            {
                log.Error("Database Items extraction failed.");
                return null;
            }            
        }

        public IEnumerable<Item> GetItemByType(ItemType itemtype)
        {            
            try
            {
                string typestr = itemtype.Map();
                IEnumerable<Item> result = MSSQLdb.Items.Where(item => item.Type == typestr).ToList().Select(item => item.Map());
                log.Info(DateTime.Now + "Database Items extraction completed.");
                return result;
            }
            catch
            {
                log.Error("Database Items extraction failed.");
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

        private bool Commit()
        {
            try
            {
                MSSQLdb.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                
                return false;
            }
        }

    }
}
