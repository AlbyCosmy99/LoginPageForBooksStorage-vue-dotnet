using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using loginPage_v1.App_Start;
using loginPage_v1.Dto.UserDto;
using loginPage_v1.Dto.UsersBookDto;
using loginPage_v1.Models;
using loginPage_v1.Services;

namespace loginPage_v1.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UsersService _usersService;
        private readonly IMapper _mapper;
        private readonly AutomapperConfig _automapperConfig;
        public UsersController(UsersService usersService, AutomapperConfig automapperConfig)
        {
            _usersService = usersService;
            _automapperConfig = automapperConfig;
            _mapper = _automapperConfig.GetMapper();
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
            return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<UserFullnameDto>(user));


        }
    }
}
