using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransfer;
using System.Threading.Tasks;

namespace DataAccess
{
    class EmailMessagesDao
    {
        ShelfItBase database;
        public EmailMessagesDao()
        {
            database = new ShelfItBase();
        }
        public EmailMessagesDto GetEmailByEmailName(string emailName)
        {
            if (String.IsNullOrWhiteSpace(emailName)) return null;
            var email = database.EmailMessages.Single(x => x.mailName == emailName);
            return ConvertToDto(email);
        }
        private EmailMessagesDto ConvertToDto(EmailMessages mail)
        {
            List<string> phrases = new List<string>();
            foreach(var phrase in mail.PhrasesToChange)
            {
                phrases.Add(phrase.phraseToChange);
            }
            return new EmailMessagesDto()
            {
                emailName = mail.mailName,
                subject = mail.subject,
                body = mail.body,
                phrasesToChange = phrases
            };
        }
    }
}
