using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmailWebApi.Models;
using SendEmailWebApi.Services;

namespace SendEmailWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task< IActionResult> SendEmail(EmailDto request)
        {
            try
            {
               await _emailService.SendEmail(request);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }
        }

    }
}