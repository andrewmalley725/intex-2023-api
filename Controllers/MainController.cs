using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intex_2023_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace intex_2023_api.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {

        private IntexContext Db { get; set; }

        public MainController(IntexContext temp)
        {
            Db = temp;
        }


        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(int page = 1, int pageSize = 15, string sex = "", string burialDepth = "", string age = "", string headDirection = "", string burialId = "", string hairColor = "")
        {

            var results = await Db.Burialmains
                .Where(x => x.Sex.Contains(sex)
                && x.Depth.Contains(burialDepth)
                && x.Ageatdeath.Contains(age)
                && x.Headdirection.Contains(headDirection)
                && x.Haircolor.Contains(hairColor))
                .ToListAsync();

            var data = results.Select(x => new { x.Burialnumber, x.Area, x.Id }).Skip((page - 1) * pageSize).Take(pageSize);

            var context = new
            {
                reults = results.Count(),
                page = page,
                pageSize = pageSize,
                nextPage = results.Count() > pageSize ? (page + 1).ToString() : "NaN",
                previousPage = page > 1 ? (page - 1).ToString() : "NaN",
                totalPages = results.Count() / pageSize,
                results = data
            };


            return new OkObjectResult(context);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

