using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SkillFactory.Module25.Models;

namespace SkillFactory.Module25.Repositories
{
    public class UserRepository
    {
        public void AddUser(string name, string email)
        {
            using (var db = new AppContext())
            {
                db.Users.Add(new User() { Name = name, Email = email });

                db.SaveChanges();
            }
        }

        public List<User> SelectAllUsers()
        {
            using (var db = new AppContext())
            {
                List<User> allUsers = db.Users.ToList();
                return allUsers;
            }
        }

        public User SelectUserById(int id)
        {
            using (var db = new AppContext())
            {
               User userById = db.Users.Where(o => o.Id == id).FirstOrDefault();
                return userById;
            }
        }

        public void UpdateUserName(int id, string newName)
        {
            using (var db = new AppContext())
            {
                User userToUpdate = db.Users.FirstOrDefault(o => o.Id == id);
                
                if (userToUpdate != null)
                {
                    userToUpdate.Name = newName;
                }

                db.SaveChanges();
            }
        }
}
}