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

namespace intex_2023_api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public string pepper = "buffalo";
        private IntexContext Db { get; set; }

        public UserController(IntexContext temp)
        {
            Db = temp;
        }

        //get api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Db.Users.Select(x => new User { Firstname = x.Firstname, Lastname = x.Lastname, Email = x.Email, Role = x.Role }).Take(30).ToList();
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> Get(string email)
        {
            var user = await Db.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            
            SHA256 sha256 = SHA256.Create();
            string pw = user.Hash;
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

            var newUser = new User
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Hash = hashString,
                Role = user.Role
            };

            Db.Users.Add(newUser);
            await Db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { email = user.Email }, user);
        }
        [HttpPut("{email}")]
        public async Task<IActionResult> Put(string email, [FromBody] User updatedUser)
        {
            var user = await Db.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(updatedUser.Email))
            {
                user.Email = updatedUser.Email;
            }

            if (!string.IsNullOrWhiteSpace(updatedUser.Firstname))
            {
                user.Firstname = updatedUser.Firstname;
            }

            if (!string.IsNullOrWhiteSpace(updatedUser.Lastname))
            {
                user.Lastname = updatedUser.Lastname;
            }

            Db.Entry(user).State = EntityState.Modified;
            await Db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            var user = await Db.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            Db.Users.Remove(user);
            await Db.SaveChangesAsync();

            return NoContent();
        }

    }
}

