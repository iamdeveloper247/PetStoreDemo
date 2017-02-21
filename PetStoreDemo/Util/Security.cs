using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetStoreDemo.Models;

namespace PetStoreDemo.Util
{
    public class Security
    {
        public static bool login(string username, string password)
        {
            PetStoreDemoContext db = new PetStoreDemoContext();
            return db.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}