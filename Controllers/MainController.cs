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
        public async Task<ActionResult> Get(int page = 1, int pageSize = 30, bool burialNum=false, string age = "", string wrapping = "", string sex = "", string hairColor = "", string area = "", bool depth=false, bool length=false)
        {
            Dictionary<string, string> haircolors = new Dictionary<string, string>()
            {
                {"B","Brown"},
                {"K","Black"},
                {"A","Brown-Red"},
                {"R","Red"},
                {"D","Blonde"},
                {"U","Unknown"},

            };

            Dictionary<string, string> sexes = new Dictionary<string, string>()
            {
                {"M","Male"},
                {"F","Female"},
                {"U", "Unknown"}

            };

            Dictionary<string, string> ages = new Dictionary<string, string>()
            {
                {"A","Adult"},
                {"C","Child"},
                {"I", "Infant"},
                {"IN", "Infant"},
                {"N", "Newborn"},
                {"U", "Unknown"}

            };

            Dictionary<string, string> wrappings = new Dictionary<string, string>()
            {
                {"W","Full remains"},
                {"H","Partial remains"},
                {"B", "Bones/Partial remains"},
                {"U", "Unknown"},
                {"S", "Unknown"}

            };


            var results = Db.Essentials.Count();
            var data = await Db.Essentials
                .Where(x => (string.IsNullOrEmpty(age) || x.Ageatdeath.Contains(age))
                && (string.IsNullOrEmpty(wrapping) || x.Wrapping.Contains(wrapping))
                && (string.IsNullOrEmpty(sex) || x.Sex.Contains(sex))
                && (string.IsNullOrEmpty(hairColor) || x.Haircolor.Contains(hairColor))
                && (string.IsNullOrEmpty(area) || x.Area.Contains(area))).ToListAsync();

            if (burialNum)
            {
                data = data.OrderByDescending(x => int.TryParse(x.Burialnumber, out int result) ? result : 0).ToList();
            }

            else if (depth)
            {
                data = data.OrderByDescending(x => x.Depth).ToList();
            }
            else if (length)
            {
                data = data.OrderByDescending(x => x.Length).ToList();
            }
            

            var dataFin = data.Skip((page - 1) * pageSize).Take(pageSize);

            foreach (Essential e in data)
            {
                if (e.Haircolor != null && haircolors.ContainsKey(e.Haircolor))
                {
                    e.Haircolor = haircolors[e.Haircolor];
                }
                if (e.Sex != null && sexes.ContainsKey(e.Sex))
                {
                    e.Sex = sexes[e.Sex];
                }
                if (e.Ageatdeath != null && ages.ContainsKey(e.Ageatdeath))
                {
                    e.Ageatdeath = ages[e.Ageatdeath];
                }
                if (e.Wrapping != null && wrappings.ContainsKey(e.Wrapping))
                {
                    e.Wrapping = wrappings[e.Wrapping];
                }

            }

            var context = new
            {
                count = data.Count(),
                page = page,
                pageSize = pageSize,
                nextPage = data.Count() > pageSize ? (page + 1).ToString() : "NaN",
                previousPage = page > 1 ? (page - 1).ToString() : "NaN",
                totalPages = (int)Math.Ceiling((double)data.Count() / pageSize),
                results = dataFin
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

