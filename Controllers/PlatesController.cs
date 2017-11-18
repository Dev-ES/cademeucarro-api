using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cademeucarro_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace cademeucarro_api.Controllers
{
    [Route("api/plates")]
    public class PlatesController : Controller
    {
        private CadeMeuCarroDataContext _context;

        public PlatesController(CadeMeuCarroDataContext context)
        {
            _context = context;
        }
        
        // GET api/values
        [HttpGet, Route("search/{plate?}")]
        public ActionResult SearchPlate(string plate = "")
        {
            var searchResult = _context.Cars.Where(x => x.Plate == plate).OrderByDescending(x => x.Id).LastOrDefault();
            if (searchResult == null) {
                return Ok(new { stolen = "undefined"});
            }
            return Ok(new { stolen = searchResult.IsStolen, stolenOn = searchResult.StolenOn });
        }

        [HttpPost, Route("add")]
        public async Task<ActionResult> NewCar([FromBody] Car car) {
            try {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
            } catch
            {
                return BadRequest(new { sucess = true });
            }
            
            return Ok(new { sucess = true });
        }
    }
}
