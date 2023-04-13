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
    public class InfoController : Controller
    {

        private IntexContext Db { get; set; }

        public InfoController(IntexContext temp)
        {
            Db = temp;
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/values/5
        [HttpGet("{burialNum}/{area}/{eastWest}/{sqew}/{northSouth}/{sqns}")]
        public async Task<ActionResult> Get(string burialNum, string area, string eastWest, string sqew, string northSouth, string sqns)
        {
            var grave = await Db.MainData.SingleOrDefaultAsync(x => x.Burialnumber == burialNum
            && x.Area == area
            && x.Eastwest == eastWest
            && x.Squareeastwest == sqew
            && x.Northsouth == northSouth
            && x.Squarenorthsouth == sqns);

            var context = new
            {
                result = grave
            };

            return new OkObjectResult(context);
        }

        // POST api/values
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

