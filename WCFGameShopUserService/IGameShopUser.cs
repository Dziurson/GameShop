using EFGameShopDatabase.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFGameShopUserService
{
    [ServiceContract]
    public interface IGameShopUser
    {
        [OperationContract]
        User GetUserById(int id);

        [OperationContract]
        User GetUserByCredentials(string login, string password);

        [OperationContract]
        IEnumerable<User> GetUsersByCity(string city);

        [OperationContract]
        IEnumerable<User> GetUsersByPostalCode(string postalcode);

        [OperationContract]
        bool InsertNewUser(User user);

        [OperationContract]
        bool InsertNewUsers(IEnumerable<User> users);
    }
}
