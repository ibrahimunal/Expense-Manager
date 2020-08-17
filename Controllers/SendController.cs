using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Models;
using System.Net.Mail;

namespace Forms.Controllers
{
    public class SendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Email em)
        {
            string to = em.To;
            string subject = em.Subject;
            string body = em.Body;

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.From = new MailAddress("ibrahmm.unal@gmail.com");
            mailMessage.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("ibrahmm.unal@gmail.com", "Java1283");
            smtp.Send(mailMessage);
            ViewBag.message = "Mail has been sent to" +mailMessage.To+"!!!";

            return View();
        }
    }
}
