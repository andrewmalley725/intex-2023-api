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


        //GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get(int page = 1, int pageSize = 30, string age = "", string wrapping = "", string sex = "", string hairColor = "", string area = "")
        {
            var results = Db.Essentials.Count();
            var data = await Db.Essentials
                .Where(x => (string.IsNullOrEmpty(age) || x.Ageatdeath.Contains(age))
                && (string.IsNullOrEmpty(wrapping) || x.Wrapping.Contains(wrapping))
                && (string.IsNullOrEmpty(sex) || x.Sex.Contains(sex))
                && (string.IsNullOrEmpty(hairColor) || x.Haircolor.Contains(hairColor))
                && (string.IsNullOrEmpty(area) || x.Area.Contains(area)))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            var context = new
            {
                reults = results,
                page = page,
                pageSize = pageSize,
                nextPage = results > pageSize ? (page + 1).ToString() : "NaN",
                previousPage = page > 1 ? (page - 1).ToString() : "NaN",
                totalPages = (int)Math.Ceiling((double)results / pageSize),
                results = data
            };


            return new OkObjectResult(context);
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

