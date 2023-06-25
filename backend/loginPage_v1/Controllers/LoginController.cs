using loginPage_v1.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
using System.Web.UI;

namespace loginPage_v1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {
        private readonly LoginsService _loginsService;

        public LoginController(LoginsService loginsService)
        {
            _loginsService = loginsService;
        }
        public class LoginInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Login(LoginInfo loginInfo)
        {
            if (loginInfo == null || string.IsNullOrEmpty(loginInfo.Username) || string.IsNullOrEmpty(loginInfo.Password))
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Credentials are fully or partially null.");
            }

            _loginsService.existUser(loginInfo.Username, loginInfo.Password);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Login()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
