using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace WeatherApplication.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response SendEmail(string to, string subject, string body)
        {
            var nameForm = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var messege = new MimeMessage();

            messege.From.Add(new MailboxAddress(nameForm, from));
            messege.To.Add(new MailboxAddress(to, to));
            messege.Subject = subject;

            var bodybuilder = new BodyBuilder
            {
                HtmlBody = body,
            };

            messege.Body = bodybuilder.ToMessageBody();

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, int.Parse(port), false);
                    client.Authenticate(from, password);
                    client.Send(messege);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Messesge = ex.ToString()
                };
            }

            return new Response
            {
                IsSuccess = true
            };
        }
    }
}
