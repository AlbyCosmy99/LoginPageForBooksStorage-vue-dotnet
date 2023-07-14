using AutoMapper;
using loginPage_v1.App_Start;
using loginPage_v1.Dto.UsersBookDto;
using loginPage_v1.Services;
using System;
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
        [HttpGet]
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

        [Route("books/{username}/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteBook(string username, int id)
        {
            try
            {
                _usersBooksService.DeleteBook(username, id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book could't be deleted.");
            }         
        }

        public class BookRequest
        {
            public string Title { get; set; } = null; 
            public string Author { get; set; } = null;
            public string BookLanguage { get; set; } = null;
            public int? PublicationYear { get; set; } = null;
            public int? Pages { get; set; } = null;
            public string Genre { get; set; } = null;
            public string FinishingDate { get; set; } = null;
            public string Price { get; set; } = null;
            public string PersonalRating { get; set; } = null;
            public string Notes { get; set; } = null;
        }

        [Route("books/{username}/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateBook(string username, int id, BookRequest book)
        {
            if(book == null || string.IsNullOrEmpty(book.Title))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Book must be given in the body of the request. Title cannot be an empty string.");
            }

            try
            {
                var newBook = _usersBooksService.UpdateBook(username, id, book.Title, book.Author, book.BookLanguage, book.PublicationYear,
                    book.Pages, book.Genre, book.FinishingDate, book.Price,
                    book.PersonalRating, book.Notes);

                return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<FullUsersBookDto>(newBook));
            }
            catch(Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, username + "'s " + "book with id "+ id + " could't be found.");
            }
        }
    }
}
