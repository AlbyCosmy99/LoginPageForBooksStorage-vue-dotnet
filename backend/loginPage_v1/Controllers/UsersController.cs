using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using loginPage_v1.PageContext;
using loginPage_v1.Services;

namespace loginPage_v1.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UsersService _usersService;
        public UsersController(UsersService usersService) {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("users/fullname/{username}")]
        public HttpResponseMessage GetUserFullName(string username)
        {
            var user = _usersService.GetUserFullname(username);
            
            if(user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"User with username {username} doesn't exists.");
            }

            return Request.CreateErrorResponse(HttpStatusCode.OK, "ok");


        }
    }
}
