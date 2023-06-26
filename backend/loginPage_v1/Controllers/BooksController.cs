using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace loginPage_v1.Controllers
{
    public class BooksController : ApiController
    {
        [Route("books/{username}")]
        public HttpResponseMessage GetUserBook([FromUri] string username)
        {
            return Request.CreateResponse(HttpStatusCode.OK, username);
        }
    }
}
