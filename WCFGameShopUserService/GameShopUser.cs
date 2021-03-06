﻿using EFGameShopDatabase;
using EFGameShopDatabase.Extensions;
using EFGameShopDatabase.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFGameShopUserService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
    public class GameShopUser : IGameShopUser
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GameShopUser));

        public GameShopUser()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public User GetUserByCredentials(string login, string password)
        {
            using (UserConnection db = new UserConnection())
            {
                log.Info(String.Concat("User with login: ", login, " requested").WithDate());
                return db.GetUserByCredentials(login, password);
            }
        }

        public User GetUserById(int id)
        {
            using (UserConnection db = new UserConnection())
            {
                log.Info(String.Concat("User with id: ", id, " requested").WithDate());
                return db.GetUserById(id);
            }
        }

        public IEnumerable<User> GetUsersByCity(string city)
        {
            using (UserConnection db = new UserConnection())
            {
                log.Info(String.Concat("Users with city: ", city, " requested").WithDate());
                return db.GetUsersByCity(city);
            }
        }

        public IEnumerable<User> GetUsersByPostalCode(string postalcode)
        {
            using (UserConnection db = new UserConnection())
            {
                log.Info(String.Concat("Users with postal code: ", postalcode, " requested").WithDate());
                return db.GetUsersByPostalCode(postalcode);
            }
        }

        public bool InsertNewUser(User user)
        {
            log.Info("User insertion requested".WithDate());
            using (UserConnection db = new UserConnection())
            {
                return db.InsertNewUser(user);
            }
        }

        public bool InsertNewUsers(IEnumerable<User> users)
        {
            log.Info("Users insertion requested".WithDate());
            using (UserConnection db = new UserConnection())
            {
                return db.InsertNewUsers(users);
            }
        }
    }
}
