﻿using System;
using System.Linq;
using Domain.Infra;

namespace Domain.Users
{
    class UsersRepository
    {
        public void Add(User user)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public User GetByEmail(string email)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(x => x.Email == email);
            }
        }
    }
}
