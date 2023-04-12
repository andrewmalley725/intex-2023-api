using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intex_2023_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace intex_2023_api.Controllers
{
    [Route("api/[controller]")]
    public class CrudController : Controller
    {

        private IntexContext Db { get; set; }

        public CrudController(IntexContext temp)
        {
            Db = temp;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Burialmain burialmain)
        {
            //Todo newItem = new Todo
            //{
            //    Id = burialmain.Id,
            //    User = await Db.Burialmains.FirstOrDefaultAsync(x => x.Id == burialmain.Id),
            //    userId = burialmain.Id,
            //    description = burialmain.description

            //};

            Db.Burialmains.Add(burialmain);
            await Db.SaveChangesAsync();

            var data = Db.Burialmains.FirstOrDefaultAsync(x => x.Id == burialmain.Id);

            return new OkObjectResult(data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Burialmain burialmain)
        {
            if (id != burialmain.Id)
            {
                return BadRequest();
            }

            Db.Entry(burialmain).State = EntityState.Modified;

            try
            {
                await Db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurialmainExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var burialmain = await Db.Burialmains.FindAsync(id);

            if (burialmain == null)
            {
                return NotFound();
            }

            Db.Burialmains.Remove(burialmain);
            await Db.SaveChangesAsync();

            return NoContent();

        }

        private bool BurialmainExists(int id)
        {
            return Db.Burialmains.Any(e => e.Id == id);
        }
    }
}

