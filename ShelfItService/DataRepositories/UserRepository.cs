using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace ShelfItService.DataRepositories
{
    public class UserRepository
    {
        public static List<UserDto> userzy = new List<UserDto>()
        {
        new UserDto()
            {
                userID = 1,
                login = "admin",
                password = "admin",//new Crypto().GetHash("admin"),
                repozytoria = new List<RepozytoriumDto>
                {
                    new RepozytoriumDto { repozytoriumID = 1, wlascicielID = 1, nazwa = "Default", repoNumber = 1, dfltInd = 'Y'},
                    new RepozytoriumDto { repozytoriumID = 2, wlascicielID = 1, nazwa = "Repo testowe", repoNumber = 2, dfltInd = 'N'}
                }
            },
            new UserDto()
            {
                userID = 2,
                login = "user",
                password = new Crypto().GetHash("123456"),
                repozytoria = new List<RepozytoriumDto>
                {
                    new RepozytoriumDto { repozytoriumID = 3, wlascicielID = 1, nazwa = "Default", repoNumber = 1, dfltInd = 'Y'},
                }

            },
            new UserDto()
            {
                userID = 3,
                login = "paulaa94",
                password = new Crypto().GetHash("b88bi3s"),
                repozytoria = new List<RepozytoriumDto>
                {
                    new RepozytoriumDto { repozytoriumID = 4, wlascicielID = 1, nazwa = "Default", repoNumber = 1, dfltInd = 'Y'},
                }
            }
        };
        public bool CheckPassword(string userName, string password)
        {
            string userPassword = userzy.Find(x => x.login == userName).password;
            return userPassword == password ? true : false;
        }
    }
}
