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
    public class FilterController : Controller
    {

        private IntexContext Db { get; set; }

        public FilterController(IntexContext temp)
        {
            Db = temp;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var ages = await Db.Essentials.Select(x => x.Ageatdeath.ToLower()).Distinct().Where(x => x != "" && x != null).ToListAsync();

            var wrappings = await Db.Essentials.Select(x => x.Wrapping).Distinct().Where(x => x != "" && x != null).ToListAsync();

            var sexes = await Db.Essentials.Select(x => x.Sex).Distinct().Where(x => x != "" && x != null).ToListAsync();

            var hairColors = await Db.Essentials.Select(x => x.Haircolor).Distinct().Where(x => x != "" && x != null).ToListAsync();

            var areas = await Db.Essentials.Select(x => x.Area).Distinct().Where(x => x != "" && x != null).ToListAsync();

            var context = new
            {
                ages = ages.Select(s => s.ToUpper()).ToArray(),
                wrappings = wrappings,
                sex = sexes,
                hairColors = hairColors,
                areas = areas

            };

            return new OkObjectResult(context);
        }
    }
}

