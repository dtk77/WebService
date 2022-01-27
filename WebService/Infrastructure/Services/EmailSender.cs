using System;
using System.Threading;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using WebService.ApplicationCore.Interfaces;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace WebService.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        private readonly IConfiguration _settings;

        public EmailSender(ILogger<EmailSender> logger, IConfiguration settings)
        {
            _logger = logger;
            _settings = settings;
        }

        /// <summary>
        /// Sends an email asynchronously using SMTP
        /// </summary>
        /// <param name="toEmailAddress"></param>
        /// <param name="subject"></param>
        /// <param name="bodyHtml"></param>
        /// <param name="bodyText"></param>
        /// <param name="retryCount"></param>
        /// <param name="toName"></param>
        public async Task<bool> Send(string toName, string toEmailAddress, string subject, string bodyHtml, string bodyText, int retryCount = 2)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings["MailKit:MailKitFromName"], _settings["MailKit:MailKitFromAddress"]));
            message.To.Add(new MailboxAddress(toName, toEmailAddress));
            message.Subject = subject;
            message.Body = new BodyBuilder
            {
                TextBody = bodyText
            }.ToMessageBody();

            for (var count = 1; count <= retryCount; count++)
            {
                try
                {
                    using var client = new SmtpClient();
                    //client.LocalDomain = _settings["MailKit:MailKitLocalDomain"];
                    SecureSocketOptions secureSocketOptions;

                    if (!Enum.TryParse(_settings["MailKit:MailKitSecureSocketOption"],
                                                                out secureSocketOptions))
                    {
                        secureSocketOptions = SecureSocketOptions.Auto;
                    }
                    
                    int port = Convert.ToInt32(_settings["MailKit:MailKitPort"]);
                    await client.ConnectAsync(_settings["MailKit:MailKitHost"],
                                          port, secureSocketOptions).ConfigureAwait(false);
                    client.Authenticate(_settings["MailKit:MailKitUsername"],
                                        _settings["MailKit:MailKitPassword"]);
                    await client.SendAsync(message).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                    // return true;
                }
                catch (Exception exception)
                {
                    _logger.LogError(0, exception, "MailKit.Send failed attempt {0}", count);
                    if (retryCount >= 0)
                    {
                        return false;
                    }
                    await Task.Delay(count * 1000);
                }
            }
            return true;
        }
    }
}

