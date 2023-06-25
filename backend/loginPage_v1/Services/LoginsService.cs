using loginPage_v1.myExceptions;
using loginPage_v1.PageContext;
using System.Linq;

namespace loginPage_v1.Services
{
    public interface ILoginsService
    {
        void existUser(string username, string password);
    }
    public class LoginsService : ILoginsService
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

            if(user == null)
            {
                throw new LoginFailedException("Credentials are not correct.");
            }
        }

    }
}