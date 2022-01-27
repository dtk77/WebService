using Microsoft.AspNetCore.Mvc;
using WebService.ApplicationCore.Entity;
using WebService.ApplicationCore.Interfaces;
using static WebService.Infrastructure.Services.Helper;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IAsyncRepository<MailSendingReportToDb> _dbRepository;
        private readonly IEmailSender _emailSender;
        public MailsController(IAsyncRepository<MailSendingReportToDb> dbRepository, IEmailSender emailSender)
        {
            _dbRepository = dbRepository;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MailSendingReportToDb>>> GetReport()
        {
            var response = await _dbRepository.GetAsync();
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RequestToSendMail requestToSendMail)
        {
            var recipients = requestToSendMail.Recipients.ToList();
            var notValidMailsAdressCollection = CheckValidMailAdress(recipients);
            if (notValidMailsAdressCollection.Any())
                return BadRequest($"Not valid email adress: {notValidMailsAdressCollection}");

            string statusSending = "Failed";
            foreach (var recipient in recipients)
            {
                bool resultSending =
                   await _emailSender.Send("", recipient, requestToSendMail.Subject, "", requestToSendMail.Body);

                if (resultSending == true) statusSending = "OK";

                var dto = new MailSendingReportToDb
                {
                    Id = requestToSendMail.Id,
                    Date = DateTime.Now,
                    Result = statusSending,
                    Subject = requestToSendMail.Subject,
                    Body = requestToSendMail.Body,
                    Recipient = recipient
                };
                await _dbRepository.AddAsync(dto);
            }

           return Ok();
        }

    }

}





