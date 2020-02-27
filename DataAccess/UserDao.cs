using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataAccess
{
    public class UserDao
    {
        ShelfItBase database;
        RepozytoriumDao repoDao;
        EmailProvider provider;
        public UserDao()
        {
            database = new ShelfItBase();
            repoDao = new RepozytoriumDao();
            provider = new EmailProvider();
        }
        public UserDto GetUserByUserID(int? userID, string sessionID)
        {
            var user = database.Uzytkownik.Single(u => u.id == userID);
            if (user.sessionID != sessionID) return null;
            return ConvertUserToDto(user);
        }
        public bool VerifySessionID(string sessionID, int userID)
        {
            var user = database.Uzytkownik.Single(u => u.id == userID);
            if (user.sessionID == sessionID) return true;
            else return false;
        }
        public UserDto LoginUser(string login, string password)
        {
            var user = database.Uzytkownik.Single(u => u.email == login && u.password == password);
            if (user == null) return null;
            user.sessionID = GenerateSessionID(user.login);
            database.SaveChanges();
            return ConvertUserToDto(user);
        }
        public bool LogoutUser(int? userID, string sessionID)
        {
            var user = database.Uzytkownik.Single(u => u.id == userID && u.sessionID == sessionID);
            if (user == null) return false;
            user.sessionID = null;
            database.SaveChanges();
            return true;
        }
        public bool RegisterUser(UserDto user)
        {
            if (database.Uzytkownik.Single(u => u.email == user.email || u.login == user.login) != null) return false;
            var uzytkownik = new Uzytkownik()
            {
                id = database.Uzytkownik.Max(x => x.id) + 1,
                login = user.login,
                email = user.email,
                IsConfirmed = false,
                password = user.password,
            };
            string session = GenerateSessionID(uzytkownik.login);
            var mailAddress = new MailAddress(uzytkownik.email, uzytkownik.login);
            var result = provider.SendRegisterEmail(mailAddress, session);
            if(result == "Success!")
            {
                var confirm = new Uzytkownik_Potwierdzenie()
                {
                    id = database.Uzytkownik_Potwierdzenie.Max(x => x.id) + 1,
                    generatedLinkHash = session,
                    uzytkownik_id = uzytkownik.id
                };
                database.Uzytkownik.Add(uzytkownik);
                database.Uzytkownik_Potwierdzenie.Add(confirm);
                database.SaveChanges();
                repoDao.AddDefaultRepoForUser(uzytkownik.id);
                return true;
            }
            return false;
        }
        public bool ConfirmRegistration(string id, out string message)
        {
            var userConf = database.Uzytkownik_Potwierdzenie.Single(x => x.generatedLinkHash == id);
            if (userConf == null)
            {
                message = "Cannot find predicted ID";
                return false;
            }
            var user = database.Uzytkownik.Single(x => x.id == userConf.uzytkownik_id);
            user.IsConfirmed = true;
            database.Uzytkownik_Potwierdzenie.Remove(userConf);
            database.SaveChanges();
            message = "Email is confirmed. You can login into app now.";
            return true;
        }
        public bool ChangePassword(ChangePass newPass, out string message)
        {
            var user = database.Uzytkownik.Single(x => x.id == newPass.userID && x.password == newPass.oldPassword);
            if (user == null)
            {
                message = "Wrong login or password!";
                return false;
            }
            string session = GenerateSessionID(user.login);
            var mailAddress = new MailAddress(user.email, user.login);
            var result = provider.SendChangePasswordEmail(mailAddress, session);
            if(result == "Success!")
            {
                user.password = newPass.newPassword;
                var confirm = new Uzytkownik_Potwierdzenie()
                {
                    id = database.Uzytkownik_Potwierdzenie.Max(x => x.id) + 1,
                    generatedLinkHash = session,
                    uzytkownik_id = user.id
                };
                database.Uzytkownik_Potwierdzenie.Add(confirm);
                database.SaveChanges();
                message = "Password was changed";
                return true;
            }
            message = "Ops! Something went wrong. Password didn't changed";
            return false;
        }
        /// <summary>
        /// ONLY FOR TEST!!!
        /// </summary>
        /// <returns></returns>
        public UserDto GetDefaultUser()
        {
            var user = database.Uzytkownik.Single(u => u.id == 1);
            var repo = database.Repozytorium.Where(r => r.uzytkownik_id == user.id).ToList();
            return new UserDto()
            {
                userID = user.id,
                email = user.email,
                login = user.login,
                repozytoria = ConvertRepoToDto(repo),
                IsConfirmed = user.IsConfirmed,
                sessionID = GenerateSessionID(user.login)
            };
        }
        #region PrivateHelpers
        private string GenerateSessionID(string login)
        {
            var date = DateTime.Today;
            int variable = date.Year + date.Month + date.Day + new Random().Next();
            string toHash = login + variable;
            MD5CryptoServiceProvider md5Crypto = new MD5CryptoServiceProvider();
            byte[] _data = md5Crypto.ComputeHash(Encoding.Default.GetBytes(toHash));
            StringBuilder _sBulider = new StringBuilder();
            for (int i = 0; i < _data.Length; i++)
            {
                _sBulider.Append(_data[i].ToString("x2"));
            }
            return _sBulider.ToString();
        }
        private UserDto ConvertUserToDto(Uzytkownik user)
        {
            return new UserDto()
            {
                userID = user.id,
                email = user.email,
                IsConfirmed = user.IsConfirmed,
                login = user.login,
                repozytoria = ConvertRepoToDto(user.Repozytorium.ToList()),
                sessionID = user.sessionID
            };
        }
        private List<RepozytoriumDto> ConvertRepoToDto(List<Repozytorium> repoList)
        {
            List<RepozytoriumDto> repList = new List<RepozytoriumDto>();
            foreach(var repo in repoList)
            {
                repList.Add(new RepozytoriumDto()
                {
                    repozytoriumID = repo.id,
                    nazwa = repo.nazwa, 
                    wlascicielID = repo.uzytkownik_id,
                    repoNumber = repo.numer_repoz, 
                    dfltInd = repo.domyslny_id
                });
            }
            return repList;
        }
        #endregion
    }
}
