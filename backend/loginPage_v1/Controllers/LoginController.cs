using loginPage_v1.myExceptions;
using loginPage_v1.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace loginPage_v1.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
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
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username and password must be given.");
            }

            try
            {
                _loginsService.existUser(loginInfo.Username, loginInfo.Password);
            }
            catch(LoginFailedException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Login()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "acsvc");
        }
    }
}
