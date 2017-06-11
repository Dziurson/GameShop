using EFGameShopDatabase.Extensions;
using EFGameShopDatabase.Models;
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
        private static readonly ILog log = LogManager.GetLogger(typeof(UserConnection));

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

        public void Dispose()
        {
            MSSQLdb.Dispose();
        }

        public User GetUserById(int id)
        {
            try
            {
                log.Info(String.Concat("Database User with id: ", id, " extraction started").WithDate());
                User result = MSSQLdb.Users.Where(user => user.UserId == id).ToList().Select(user => user.Map()).FirstOrDefault();
                log.Info(String.Concat("Database User with id: ", id, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database User with id: ", id, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }            
        }

        public User GetUserByCredentials(string login, string password)
        {
            try
            {
                log.Info(String.Concat("Database User with login: ", login, " extraction started").WithDate());
                User result = MSSQLdb.Users.Where(user => user.Login == login && user.Password == password).ToList().Select(user => user.Map()).FirstOrDefault();
                log.Info(String.Concat("Database Users with login: ", login, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database User with login: ", login, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<User> GetUsersByCity(string city)
        {
            try
            {
                log.Info(String.Concat("Database Users with city: ", city, " extraction started").WithDate());
                IEnumerable<User> result = MSSQLdb.Users.Where(user => user.City == city).ToList().Select(user => user.Map());
                log.Info(String.Concat("Database Users with cty: ", city, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database User with city: ", city, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }
        }

        public IEnumerable<User> GetUsersByPostalCode(string postalcode)
        {
            try
            {
                log.Info(String.Concat("Database Users with postal code: ", postalcode, " extraction started").WithDate());
                IEnumerable<User> result = MSSQLdb.Users.Where(user => user.PostalCode == postalcode).ToList().Select(user => user.Map());
                log.Info(String.Concat("Database Users with postal code: ", postalcode, " extraction completed").WithDate());
                return result;
            }
            catch (Exception e)
            {
                log.Error(String.Concat("Database User with postal code: ", postalcode, " extraction failed").WithDate());
                log.Error(e.Message);
                return null;
            }
        }          
        
        public bool InsertNewUser(User user)
        {
            try
            {
                MSSQLdb.Users.Add(user.ReverseMap());
                return Commit();
            }
            catch(Exception e)
            {
                log.Error(e.Message);
                return false;
            }
        }

        public bool InsertNewUsers(IEnumerable<User> users)
        {
            MSSQLdb.Users.AddRange(users.Select(user => user.ReverseMap()));
            return Commit();
        }

        public bool RemoveUser(User user)
        {
            log.Info(String.Concat("Database User with id: ", user.UserId, " removing started").WithDate());
            if (GetUserById(user.UserId) != null)
            {
                try
                {
                    MSSQLdb.Users.Remove(MSSQLdb.Users.Where(u => u.UserId == user.UserId).FirstOrDefault());
                }
                catch (Exception e)
                {
                    log.Error(e.Message);
                    return false;
                }
                bool result = Commit();
                if(result == true)
                {
                    log.Info(String.Concat("Database User with id: ", user.UserId, " removing completed").WithDate());
                    return result;
                }
                else
                    log.Info(String.Concat("Database User with id: ", user.UserId, " removing failed").WithDate());
            }
            log.Info(String.Concat("Database User with id: ", user.UserId, " does not exist").WithDate());
            return false;
        }
    }
}
