using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer
{
    public class ApiElementsEnum
    {
        #region FilmController
        public const string GetAllFilms = "ShelfIt/Film";
        private const string GetFilmUrl = "ShelfIt/Film/";
        public string GetFilm(int id)
        {
            return GetFilmUrl + id;
        }
        public string GetFilm(string name)
        {
            return GetFilmUrl + name;
        }
        #endregion
        #region BookController
        public const string GetAllBooks = "ShelfIt/Book";
        private const string GetBookUrl = "ShelfIt/Book/";
        private const string GetBooksByAuthorUrl = "ShelfIt/Book/Author/";
        public string GetBook(int id)
        {
            return GetBookUrl + id;
        }
        public string GetBook(string name)
        {
            return GetBookUrl + name;
        }
        public string GetBooksByAuthor(int id)
        {
            return GetBooksByAuthorUrl + id;
        }
        #endregion
        #region UserController
        public const string confirmLink = "http://localhost:61061/ShelfIt/User/Confirm?id=";
        public const string changePassLink = "http://localhost:61061/ShelfIt/User/ChangePassword?id=";
        #endregion
    }
}
