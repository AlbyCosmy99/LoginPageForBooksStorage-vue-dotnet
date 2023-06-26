using loginPage_v1.myExceptions;
using loginPage_v1.PageContext;
using System.Linq;

namespace loginPage_v1.Services
{
    public class LoginsService
    {
        private readonly Ctx _ctx;
        public LoginsService(Ctx ctx)
        {
            _ctx = ctx;
        }

        public void existUser(string username, string password)
        {
            var user = _ctx.Users
                .Where(x => x.UserName == username && x.Password == password)
                .Any();

            if(!user)
            {
                throw new LoginFailedException("Credentials are not correct.");
            }
        }

    }
}