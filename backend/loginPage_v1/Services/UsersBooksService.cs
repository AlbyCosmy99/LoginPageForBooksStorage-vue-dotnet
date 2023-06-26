using loginPage_v1.Models;
using loginPage_v1.PageContext;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace loginPage_v1.Services
{
    public class UsersBooksService
    {
        private readonly Ctx _ctx;
        public UsersBooksService(Ctx ctx)
        {
            _ctx = ctx;
        }

        public List<UsersBook> GetUserBooks(string username)
        {
            return _ctx.Users
                .Where(x => x.UserName == username)
                .Join(_ctx.UsersBooks,
                users => users.Id,
                uBooks => uBooks.User.Id,
                (users, uBooks) => uBooks)
                .OrderByDescending(x => x.FinishingDate)
                .ToList();
        }
    }
}