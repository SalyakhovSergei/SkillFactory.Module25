﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApp8
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

        public void SelectAllUsers()
        {
            using (var db = new AppContext())
            {
                List<User> allUsers = db.Users.ToList();
            }
        }

        public void SelectUserById(int id)
        {
            using (var db = new AppContext())
            {
                List<User> userById = db.Users.Where(o => o.Id == id).ToList();
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