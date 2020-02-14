using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.Repositories
{
    public class UserRepository
    {
        public List<UserDto> userzy;
        private Crypto crypto;
        public UserRepository()
        {
            crypto = new Crypto();
            userzy = new List<UserDto>();
            CreateList();
        }
        public void CreateList()
        {
            userzy.Add(new UserDto()
            {
                userID = 1,
                login = "admin@gmail.com",
                password = crypto.GetHash("admin1234")
            });
            userzy.Add(new UserDto()
            {
                userID = 2,
                login = "user",
                password = crypto.GetHash("123456")
                
            });
            userzy.Add(new UserDto()
            {
                userID = 3,
                login = "paulaa94",
                password = crypto.GetHash("b88bi3s")
            });
        }
        public bool CheckPassword(string userName, string password)
        {
            string userPassword = userzy.Find(x => x.login == userName).password;
            return userPassword == password ? true : false;
        }
    }
}
