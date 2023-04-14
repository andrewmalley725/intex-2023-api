using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using intex_2023_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [HttpGet("{id}")]
        public async Task<Burialmain> Get(Int64 id)
        {
            var data = await Db.Burialmains.FirstOrDefaultAsync(x => x.Id == id);
            return data;
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
        public async Task<ActionResult> Put(string burialNum, string area, string eastWest, string sqew, string northSouth, string sqns, [FromBody]Burialmain burialmain)
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

            if (burialmain.Squarenorthsouth != null && burialmain.Squarenorthsouth != "")
                record.Squarenorthsouth = burialmain.Squarenorthsouth;
            if (burialmain.Headdirection != null && burialmain.Headdirection != "")
                record.Headdirection = burialmain.Headdirection;
            if (burialmain.Sex != null && burialmain.Sex != "")
                record.Sex = burialmain.Sex;
            if (burialmain.Northsouth != null && burialmain.Northsouth != "")
                record.Northsouth = burialmain.Northsouth;
            if (burialmain.Depth != null && burialmain.Depth != "")
                record.Depth = burialmain.Depth;
            if (burialmain.Eastwest != null && burialmain.Eastwest != "")
                record.Eastwest = burialmain.Eastwest;
            if (burialmain.Adultsubadult != null && burialmain.Adultsubadult != "")
                record.Adultsubadult = burialmain.Adultsubadult;
            if (burialmain.Facebundles != null && burialmain.Facebundles != "")
                record.Facebundles = burialmain.Facebundles;
            if (burialmain.Southtohead != null && burialmain.Southtohead != "")
                record.Southtohead = burialmain.Southtohead;
            if (burialmain.Preservation != null && burialmain.Preservation != "")
                record.Preservation = burialmain.Preservation;
            if (burialmain.Fieldbookpage != null && burialmain.Fieldbookpage != "")
                record.Fieldbookpage = burialmain.Fieldbookpage;
            if (burialmain.Squareeastwest != null && burialmain.Squareeastwest != "")
                record.Squareeastwest = burialmain.Squareeastwest;
            if (burialmain.Goods != null && burialmain.Goods != "")
                record.Goods = burialmain.Goods;
            if (burialmain.Text != null && burialmain.Text != "")
                record.Text = burialmain.Text;
            if (burialmain.Wrapping != null && burialmain.Wrapping != "")
                record.Wrapping = burialmain.Wrapping;
            if (burialmain.Haircolor != null && burialmain.Haircolor != "")
                record.Haircolor = burialmain.Haircolor;
            if (burialmain.Westtohead != null && burialmain.Westtofeet != "")
                record.Westtohead = burialmain.Westtofeet;
            if (burialmain.Samplescollected != null && burialmain.Samplescollected != "")
                record.Samplescollected = burialmain.Samplescollected;
            if (burialmain.Area != null && burialmain.Area != "")
                record.Area = burialmain.Area;
            if (burialmain.Burialid != null)
                record.Burialid = burialmain.Burialid;
            if (burialmain.Length != null && burialmain.Length != "")
                record.Length = burialmain.Length;
            if (burialmain.Burialnumber != null && burialmain.Squarenorthsouth != "")
                record.Burialnumber = burialmain.Burialnumber;
            if (burialmain.Dataexpertinitials != null && burialmain.Dataexpertinitials != "")
                record.Dataexpertinitials = burialmain.Dataexpertinitials;
            if (burialmain.Westtofeet != null && burialmain.Westtofeet != "")
                record.Westtofeet = burialmain.Westtofeet;
            if (burialmain.Ageatdeath != null && burialmain.Ageatdeath != "")
                record.Ageatdeath = burialmain.Ageatdeath;
            if (burialmain.Southtofeet != null && burialmain.Southtofeet != "")
                record.Southtofeet = burialmain.Southtofeet;
            if (burialmain.Excavationrecorder != null && burialmain.Excavationrecorder != "")
                record.Excavationrecorder = burialmain.Excavationrecorder;
            if (burialmain.Photos != null && burialmain.Photos != "")
                record.Photos = burialmain.Photos;
            if (burialmain.Hair != null && burialmain.Hair != "")
                record.Hair = burialmain.Hair;
            if (burialmain.Burialmaterials != null && burialmain.Burialmaterials != "")
                record.Burialmaterials = burialmain.Burialmaterials;
            if (burialmain.Fieldbookexcavationyear != null && burialmain.Fieldbookexcavationyear != "")
                record.Fieldbookexcavationyear = burialmain.Fieldbookexcavationyear;
            if (burialmain.Clusternumber != null && burialmain.Clusternumber != "")
                record.Clusternumber = burialmain.Clusternumber;
            if (burialmain.Shaftnumber != null && burialmain.Shaftnumber != "")
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

