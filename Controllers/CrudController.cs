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
        [HttpGet("{burialNum}/{area}/{eastWest}/{sqew}/{northSouth}/{sqns}")]
        public async Task<ActionResult> Get(string burialNum, string area, string eastWest, string sqew, string northSouth, string sqns)
        {

            var record = await Db.Burialmains.FirstOrDefaultAsync(
            x => x.Burialnumber == burialNum
            && x.Area == area
            && x.Eastwest == eastWest
            && x.Squareeastwest == sqew
            && x.Northsouth == northSouth
            && x.Squarenorthsouth == sqns);

            return new OkObjectResult(record);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Burialmain burialmain)
        {
            var greatestId = await Db.Burialmains.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            Int64 id = greatestId.Id + 1;
            burialmain.Id = id;
            burialmain.Dateofexcavation = null;
            Db.Burialmains.Add(burialmain);
            await Db.SaveChangesAsync();

            // Return the Id of the new Burialmain
            return new OkObjectResult(burialmain);
        }

        // PUT api/values/5
        [HttpPut("{burialNum}/{area}/{eastWest}/{sqew}/{northSouth}/{sqns}")]
        public async Task<ActionResult> Put(string burialNum, string area, string eastWest, string sqew, string northSouth, string sqns, Burialmain burialmain)
        {
            var record = await Db.Burialmains.FirstOrDefaultAsync(
            x => x.Burialnumber == burialNum
            && x.Area == area
            && x.Eastwest == eastWest
            && x.Squareeastwest == sqew
            && x.Northsouth == northSouth
            && x.Squarenorthsouth == sqns);

            if (record == null)
            {
                return BadRequest();
            }


            record.Squarenorthsouth = burialmain.Squarenorthsouth;
            record.Headdirection = burialmain.Headdirection;
            record.Sex = burialmain.Sex;
            record.Northsouth = burialmain.Northsouth;
            record.Depth = burialmain.Depth;
            record.Eastwest = burialmain.Eastwest;
            record.Adultsubadult = burialmain.Adultsubadult;
            record.Facebundles = burialmain.Facebundles;
            record.Southtohead = burialmain.Southtohead;
            record.Preservation = burialmain.Preservation;
            record.Fieldbookpage = burialmain.Fieldbookpage;
            record.Squareeastwest = burialmain.Squareeastwest;
            record.Goods = burialmain.Goods;
            record.Text = burialmain.Text;
            record.Wrapping = burialmain.Wrapping;
            record.Haircolor = burialmain.Haircolor;
            record.Westtohead = burialmain.Westtofeet;
            record.Samplescollected = burialmain.Samplescollected;
            record.Area = burialmain.Area;
            record.Burialid = burialmain.Burialid;
            record.Length = burialmain.Length;
            record.Burialnumber = burialmain.Burialnumber;
            record.Dataexpertinitials = burialmain.Dataexpertinitials;
            record.Westtofeet = burialmain.Westtofeet;
            record.Ageatdeath = burialmain.Ageatdeath;
            record.Southtofeet = burialmain.Southtofeet;
            record.Excavationrecorder = burialmain.Excavationrecorder;
            record.Photos = burialmain.Photos;
            record.Hair = burialmain.Hair;
            record.Burialmaterials = burialmain.Burialmaterials;
            record.Fieldbookexcavationyear = burialmain.Fieldbookexcavationyear;
            record.Clusternumber = burialmain.Clusternumber;
            record.Shaftnumber = burialmain.Shaftnumber;


            await Db.SaveChangesAsync();

            return Ok("Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{burialNum}/{area}/{eastWest}/{sqew}/{northSouth}/{sqns}")]
        public async Task<ActionResult> Delete(string burialNum, string area, string eastWest, string sqew, string northSouth, string sqns)
        {
            var record = await Db.Burialmains.FirstOrDefaultAsync(
            x => x.Burialnumber == burialNum
            && x.Area == area
            && x.Eastwest == eastWest
            && x.Squareeastwest == sqew
            && x.Northsouth == northSouth
            && x.Squarenorthsouth == sqns);

            if (record == null)
            {
                return NotFound();
            }

            Db.Burialmains.Remove(record);
            await Db.SaveChangesAsync();

            return Ok("removed" + " " + record.Id);

        }

        
    }
}

