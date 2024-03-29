﻿using System;
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
        private EmailMessagesDao emailDao;
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
            emailDao = new EmailMessagesDao();
        }
        public string SendRegisterEmail(MailAddress userAddress, string sessionID)
        {
            string createdLink = ApiElementsEnum.confirmLink + sessionID;
            EmailMessagesDto messageContent = emailDao.GetEmailByEmailName("register");
            return SendMessage(userAddress, messageContent, createdLink);
        }
        public string SendChangePasswordEmail(MailAddress userAddress, string sessionID)
        {
            string createdLink = ApiElementsEnum.changePassLink + sessionID;
            EmailMessagesDto messageContent = emailDao.GetEmailByEmailName("changePass");
            return SendMessage(userAddress, messageContent, createdLink);
        }
        public string SendInviteEmail(MailAddress userAddress, string sessionID)
        {
            string createdLink = ApiElementsEnum.inviteNewUserLink + sessionID;
            EmailMessagesDto messageContent = emailDao.GetEmailByEmailName("invite");
            return SendMessage(userAddress, messageContent, createdLink);
        }
        public string SendResetPassEmail(MailAddress userAddress)
        {
            EmailMessagesDto messageContent = emailDao.GetEmailByEmailName("resetPass");
            return SendMessage(userAddress, messageContent, null);
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
                return "Fail to send message!\n" + ex.Message;
            }
        }
    }
}
