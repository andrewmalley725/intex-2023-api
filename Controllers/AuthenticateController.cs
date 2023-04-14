using System.Collections.Generic;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using intex_2023_api.Models; // replace with your actual namespace for the model class
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace intex_2023_api.Controllers
{
    [Route("api/[controller]")]

    public class AuthenticateController : Controller
    {
        private void SendEmail(string email, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "jon.stauffer@live.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "verification code";

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.outlook.com", 587, false);
                client.Authenticate("jon.stauffer@live.com", "number20");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        private IntexContext Db { get; set; }
        public string pepper = "buffalo";
        public AuthenticateController(IntexContext temp)
        {
            Db = temp;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Login login)
        {
            var user = await Db.Users.FirstOrDefaultAsync(x => x.Email == login.email);

            if (user == null)
            {
                return BadRequest("Invalid Email!");
            }

            SHA256 sha256 = SHA256.Create();
            string pw = login.password;
            pw = pw + pepper;
            byte[] inputBytes = Encoding.UTF8.GetBytes(pw);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            // Convert the byte array to a hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            string hashString = sb.ToString();
            string code = "buffalo";
            string body = "Your code is: ";
            

            if (hashString == user.Hash)
            {
                body = body + code;
                SendEmail(user.Email, body);
                return Ok(new { message = "Authenticated!", firstname = user.Firstname, email = user.Email, role = user.Role, code = code });
            }

            else
            {
                return BadRequest("Invalid Password!");
            }
        }


    }
}
