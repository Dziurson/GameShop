using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameShopDatabase
{
    public class UserConnection : IDisposable
    {
        private GameShopDatabase MSSQLdb;
        private static readonly ILog log = LogManager.GetLogger(typeof(WarehouseConnection));

        public UserConnection()
        {
            try
            {
                MSSQLdb = new GameShopDatabase();
            }
            catch (Exception e)
            {
                log.Fatal(e.Message);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
