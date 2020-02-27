using System;
using DataAccess;
using DataTransfer;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class BookDaoTest
    {
        ShelfItBase database;
        BookDao bookDao;
        UserDao userDao;
        public BookDaoTest()
        {
            database = new ShelfItBase();
            bookDao = new BookDao();
            userDao = new UserDao();
        }
        [TestMethod]
        public void GetAllBooksForUserTest()
        {
            var user = userDao.GetDefaultUser();
            var books = bookDao.GetAllBooksForUser(user);
        }
    }
}
