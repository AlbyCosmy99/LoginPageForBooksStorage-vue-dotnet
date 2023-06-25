using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using loginPage_v1.PageContext;

namespace loginPage_v1.Controllers
{
    public class UsersController : ApiController
    {
        public UsersController() {
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetMessage()
        {
            var ctx = new Ctx();
            var users = ctx.Users.Count();
            return Request.CreateResponse(HttpStatusCode.OK, "tutto ok");
        }
    }
}
