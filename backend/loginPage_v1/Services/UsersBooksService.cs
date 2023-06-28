using loginPage_v1.Models;
using loginPage_v1.PageContext;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace loginPage_v1.Services
{
    public class UsersBooksService
    {
        private readonly Ctx _ctx;
        public UsersBooksService(Ctx ctx)
        {
            _ctx = ctx;
        }

        public List<UsersBook> GetUserBooks(string username)
        {
            return _ctx.Users
                .Where(x => x.UserName == username)
                .Join(_ctx.UsersBooks,
                users => users.Id,
                uBooks => uBooks.User.Id,
                (users, uBooks) => uBooks)
                .OrderByDescending(x => x.FinishingDate)
                .ToList();
        }

        public UsersBook GetUserBookById(string username, int id)
        {
            return GetUserBooks(username)
                .Where(x => x.BookId == id)
                .First();
        }

        public void DeleteBook(string username, int id)
        {
            var book = GetUserBookById(username, id);
            _ctx.UsersBooks.Remove(book);

            _ctx.SaveChanges();
        }

        public UsersBook UpdateBook(string username, int id, string title, string author, string language, int?  publicationYear, int? pages,
            string genre, DateTime? finishingDate, string price, string personalRating, string notes)
        {
            var book = GetUserBookById(username, id);

            if (title != null)
            {
                book.Title = title;
            }

            if (author != null)
            {
                book.Author = author;
            }

            if (language != null)
            {
                book.BookLanguage = language;
            }

            if(book.PublicationYear != null)
            {
                book.PublicationYear = book.PublicationYear.Value;
            }

            if(publicationYear != null)
            {
                book.PublicationYear = publicationYear.Value;
            }

            if (genre != null)
            {
                book.Genre = genre;
            }
            {
                
            }

            if (pages != null)
            {
                book.Pages = pages.Value;
            }

            if (finishingDate != null)
            {
                book.FinishingDate = finishingDate.Value;
            }

            if (price != null)
            {
                book.Price = price;
            }

            if (personalRating != null)
            {
                book.PersonalRating = personalRating;
            }

            if(notes != null)
            {
                book.Notes = notes;
            }

            _ctx.SaveChanges();

            return book;
        }
    }
}