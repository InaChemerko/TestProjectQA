using DataBase.DB.Context;
using DataBase.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.DBcommons
{
    public class UserDBworker
    {
        public async Task CreateNewUser(User user)
        {
            using var context = new MarketContext();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
