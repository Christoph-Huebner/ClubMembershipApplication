using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Data
{
    public class LoginUser : ILogin
    {
        public User Login(string eMailAddress, string password)
        {
            User? user = null;
            using (var dbContext = new ClubMembershipDbContext())
            {
                user = dbContext.User.FirstOrDefault(u => u.EMailAdress.Trim().ToLower() == eMailAddress.Trim().ToLower() && u.Password.Equals(password));
            }
            return user;
        }
    }
}
