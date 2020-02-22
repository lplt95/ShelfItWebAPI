using System;
using System.Net;
using System.Text;
using DataTransfer;
using DataRepositories;
using System.Net.Mail;
using System.Collections.Generic;

namespace DataAccess
{
    public class EmailProvider
    {
        private const string email = "shelfitapp";
        private const string password = "RiFDP2TBnFpzxHw";
        private MailAddress serviceAddress = new MailAddress("shelfitapp@gmail.com", "ShelfIt Application");

        SmtpClient client; 
        public EmailProvider()
        {
            client = new SmtpClient()
            {
                EnableSsl = true,
                DeliveryFormat = SmtpDeliveryFormat.International,
                Credentials = new NetworkCredential(email, password),
                Host = "smtp.gmail.com",
                Port = 587
            };
        }
        public string SendRegisterEmail(UserDto user)
        {
            string createdLink = ApiElementsEnum.confirmLink + user.sessionID;
            EmailMessagesDto messageContent = EmailMessagesRepository.register;
            MailAddress userAddress = new MailAddress(user.email, user.login);
            return SendMessage(userAddress, messageContent, createdLink);
        }
        public string SendChangePasswordEmail(UserDto user)
        {
            string createdLink = ApiElementsEnum.changePassLink + user.sessionID;
            EmailMessagesDto messageContent = EmailMessagesRepository.changePass;
            MailAddress userAddress = new MailAddress(user.email, user.login);
            return SendMessage(userAddress, messageContent, createdLink);

        }
        private string SendMessage(MailAddress userAddress, EmailMessagesDto messageContent, string createdLink)
        {
            MailMessage message = new MailMessage(serviceAddress, userAddress)
            {
                IsBodyHtml = true,
                Priority = MailPriority.High,
                Subject = messageContent.subject
            };
            string messageBody = messageContent.body;
            foreach (string phrase in messageContent.phrasesToChange)
            {
                messageBody = messageBody.Replace(phrase, createdLink);
            }
            message.Body = messageBody;
            try
            {
                client.Send(message);
                return "Success!";
            }
            catch (Exception ex)
            {
                return "Fail \n" + ex.Message;
            }
        }
    }
}
