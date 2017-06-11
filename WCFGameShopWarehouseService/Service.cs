using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFGameShopWarehouseService
{   
    public class Service
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:80/Temporary_Listen_Addresses/GameShopWarehouseService");
            ServiceHost selfHost = new ServiceHost(typeof(GameShopWarehouse), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IGameShopWarehouse), new WSHttpBinding(), "GameShopWarehouseServiceEndpoint");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true
                };
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("GameShopWarehouseService is working. Press any key to stop service.");
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception of type CommunicationException occured: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}
