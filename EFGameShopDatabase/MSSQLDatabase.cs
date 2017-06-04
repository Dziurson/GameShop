using EFGameShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameShopDatabase
{
    public class MSSQLDatabase
    {
        private GameShopDatabase MSSQLdb;

        public MSSQLDatabase()
        {
            try
            {
                MSSQLdb = new GameShopDatabase();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Item[] GetAllItems()
        {
            return MSSQLdb.Items.ToList().Select(item => item.Map()).ToArray();
        }

    }
}
