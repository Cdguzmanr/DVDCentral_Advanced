using CG.DVDCentral.BL.Models;
using CG.DVDCentral.PL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CG.DVDCentral.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials. Your IP Address has beensaved --|=====> ")
        {

        }

        public LoginFailureException(string message) : base(message)
        {

        }

    }

    public class UserManager
    {
        // We need the hability to hash something (password). -- This is the only place on code where hash is used

        public static string GetHash(string password)
        {
            using (var hasher = SHA1.Create()) 
            {
                var hashbytes = Encoding.UTF8.GetBytes(password); // Takes the string and create a byte array
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes)); //  
            }
        }

        public static int DelteAll()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                return dc.SaveChanges();
            }
        }

        public static int Insert(User user, bool rollback = false)
        {
            // When to use Users o User (Plural or singular) in code?
            // Rule: when theres a dc. Almost alwasy needs Users (plural)


            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser entity = new tblUser();
                    entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.UserName = user.UserName;
                    entity.Password = GetHash(user.Password);

                    // IMPORTANT - BACK FILL THE ID 
                    user.Id = entity.Id;

                    dc.tblUsers.Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Login(User user) // Returns true if worked, otherwise false and exceptions 
        {
            // User is loged in if there is a user object in session
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserName == user.UserName);
                            if (tblUser != null)
                            {
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    // Login Successful
                                    user.Id = tblUser.Id;
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Could not login with those credentials. IP Address saved --|=====> ");
                                }
                            }
                            else
                            {
                                throw new LoginFailureException("UserName was not found.");
                            }
                        }

                    }
                    else
                    {
                        throw new LoginFailureException("UserName was not set.");
                    }
                }
                else
                {
                    throw new LoginFailureException("UserName was not set.");
                }
            }
            catch (LoginFailureException)
            {
                throw;
            }
            
            catch (Exception)
            {

                throw;
            }
        }


        public static void Seed() // Just to hardcode some users to test
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                if(!dc.tblUsers.Any())
                {
                    User user = new User 
                    { 
                        UserName = "kfrog",
                        FirstName = "Kermit",
                        LastName = "The frog",
                        Password = "misspiggy"
                    };
                    Insert(user);

                    user = new User
                    {
                        UserName = "bfoote",
                        FirstName = "Brian",
                        LastName = "Foote",
                        Password = "maple"
                    };
                    Insert(user);

                }
            }
        }

        // ---------------- Checkpoint 5 ------------------------------- //

        public static User LoadById(int id)
        {
            try
            {


                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser user = dc.tblUsers.FirstOrDefault(s => s.Id == id);
                    if (user != null)
                    {
                        return new User
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserName = user.UserName
                        };
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities()) //blocked scope
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();


                    //Get the row that we are trying to update
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == user.Id);

                    if (entity != null)
                    {
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        entity.UserName = user.UserName;

                        results = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                    if (rollback) transaction.Rollback();

                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public static List<User> Load(int? userId = null)
        {
            try
            {
                List<User> list = new List<User>(); //empty list
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    list = dc.tblUsers
                .Where(s => userId == null || s.Id == userId)
                .Select(s => new User
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    UserName = s.UserName
                })
                .ToList();

                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
