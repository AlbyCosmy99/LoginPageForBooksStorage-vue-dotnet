using loginPage_v1.Models;
using loginPage_v1.PageContext;
using System.Linq;

namespace loginPage_v1.Services
{
    public class UsersService
    {
        private readonly Ctx _ctx;
        public UsersService(Ctx ctx) 
        {
            _ctx = ctx;
        }

        public User GetUserFullname(string username)
        {
            return _ctx.Users
                .Where(x => x.UserName.ToUpper() == username.ToUpper())
                .FirstOrDefault();
        }
    }
}