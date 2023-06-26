using AutoMapper;
using loginPage_v1.App_Start;
using loginPage_v1.Dto.UserDto;
using loginPage_v1.Dto.UsersBookDto;
using loginPage_v1.Models;
using loginPage_v1.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace loginPage_v1.Controllers
{
    public class BooksController : ApiController
    {
        private readonly UsersBooksService _usersBooksService;
        private readonly IMapper _mapper;
        private readonly AutomapperConfig _automapperConfig;
        public BooksController(UsersBooksService usersBooksService, AutomapperConfig automapperConfig)
        {
            _usersBooksService = usersBooksService;
            _automapperConfig = automapperConfig;
            _mapper = _automapperConfig.GetMapper();
        }

        [Route("books/{username}")]
        public HttpResponseMessage GetUserBook([FromUri] string username)
        {
            var userBooks = _usersBooksService.GetUserBooks(username);
            var userBooksDto = new List<FullUsersBookDto>();

            var bookId = 1;

            foreach(var userBook in userBooks)
            {
                var userBookDto = _mapper.Map<FullUsersBookDto>(userBook);
                userBookDto.BookId = bookId++;
                userBooksDto.Add(userBookDto);

            }

            return Request.CreateResponse(HttpStatusCode.OK, userBooksDto);
        }
    }
}
