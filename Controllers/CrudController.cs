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
                return NotFound();
            }

            if (burialmain.Squarenorthsouth != null)
                record.Squarenorthsouth = burialmain.Squarenorthsouth;
            if (burialmain.Headdirection != null)
                record.Headdirection = burialmain.Headdirection;
            if (burialmain.Sex != null)
                record.Sex = burialmain.Sex;
            if (burialmain.Northsouth != null)
                record.Northsouth = burialmain.Northsouth;
            if (burialmain.Depth != null)
                record.Depth = burialmain.Depth;
            if (burialmain.Eastwest != null)
                record.Eastwest = burialmain.Eastwest;
            if (burialmain.Adultsubadult != null)
                record.Adultsubadult = burialmain.Adultsubadult;
            if (burialmain.Facebundles != null)
                record.Facebundles = burialmain.Facebundles;
            if (burialmain.Southtohead != null)
                record.Southtohead = burialmain.Southtohead;
            if (burialmain.Preservation != null)
                record.Preservation = burialmain.Preservation;
            if (burialmain.Fieldbookpage != null)
                record.Fieldbookpage = burialmain.Fieldbookpage;
            if (burialmain.Squareeastwest != null)
                record.Squareeastwest = burialmain.Squareeastwest;
            if (burialmain.Goods != null)
                record.Goods = burialmain.Goods;
            if (burialmain.Text != null)
                record.Text = burialmain.Text;
            if (burialmain.Wrapping != null)
                record.Wrapping = burialmain.Wrapping;
            if (burialmain.Haircolor != null)
                record.Haircolor = burialmain.Haircolor;
            if (burialmain.Westtohead != null)
                record.Westtohead = burialmain.Westtofeet;
            if (burialmain.Samplescollected != null)
                record.Samplescollected = burialmain.Samplescollected;
            if (burialmain.Area != null)
                record.Area = burialmain.Area;
            if (burialmain.Burialid != null)
                record.Burialid = burialmain.Burialid;
            if (burialmain.Length != null)
                record.Length = burialmain.Length;
            if (burialmain.Burialnumber != null)
                record.Burialnumber = burialmain.Burialnumber;
            if (burialmain.Dataexpertinitials != null)
                record.Dataexpertinitials = burialmain.Dataexpertinitials;
            if (burialmain.Westtofeet != null)
                record.Westtofeet = burialmain.Westtofeet;
            if (burialmain.Ageatdeath != null)
                record.Ageatdeath = burialmain.Ageatdeath;
            if (burialmain.Southtofeet != null)
                record.Southtofeet = burialmain.Southtofeet;
            if (burialmain.Excavationrecorder != null)
                record.Excavationrecorder = burialmain.Excavationrecorder;
            if (burialmain.Photos != null)
                record.Photos = burialmain.Photos;
            if (burialmain.Hair != null)
                record.Hair = burialmain.Hair;
            if (burialmain.Burialmaterials != null)
                record.Burialmaterials = burialmain.Burialmaterials;
            if (burialmain.Fieldbookexcavationyear != null)
                record.Fieldbookexcavationyear = burialmain.Fieldbookexcavationyear;
            if (burialmain.Clusternumber != null)
                record.Clusternumber = burialmain.Clusternumber;
            if (burialmain.Shaftnumber != null)
                record.Shaftnumber = burialmain.Shaftnumber;


            //record.Squarenorthsouth = burialmain.Squarenorthsouth;
            //record.Headdirection = burialmain.Headdirection;
            //record.Sex = burialmain.Sex;
            //record.Northsouth = burialmain.Northsouth;    
            //record.Depth = burialmain.Depth;
            //record.Eastwest = burialmain.Eastwest;
            //record.Adultsubadult = burialmain.Adultsubadult;
            //record.Facebundles = burialmain.Facebundles;
            //record.Southtohead = burialmain.Southtohead;
            //record.Preservation = burialmain.Preservation;
            //record.Fieldbookpage = burialmain.Fieldbookpage;
            //record.Squareeastwest = burialmain.Squareeastwest;
            //record.Goods = burialmain.Goods;
            //record.Text = burialmain.Text;
            //record.Wrapping = burialmain.Wrapping;
            //record.Haircolor = burialmain.Haircolor;
            //record.Westtohead = burialmain.Westtofeet;
            //record.Samplescollected = burialmain.Samplescollected;
            //record.Area = burialmain.Area;
            //record.Burialid = burialmain.Burialid;
            //record.Length = burialmain.Length;
            //record.Burialnumber = burialmain.Burialnumber;
            //record.Dataexpertinitials = burialmain.Dataexpertinitials;
            //record.Westtofeet = burialmain.Westtofeet;
            //record.Ageatdeath = burialmain.Ageatdeath;
            //record.Southtofeet = burialmain.Southtofeet;
            //record.Excavationrecorder = burialmain.Excavationrecorder;
            //record.Photos = burialmain.Photos;
            //record.Hair = burialmain.Hair;
            //record.Burialmaterials = burialmain.Burialmaterials;
            //record.Fieldbookexcavationyear = burialmain.Fieldbookexcavationyear;
            //record.Clusternumber = burialmain.Clusternumber;
            //record.Shaftnumber = burialmain.Shaftnumber;


            Db.SaveChanges();

            var context = new
            {
                record.Id,
                record.Burialnumber
            };


            return new ObjectResult(record);
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

