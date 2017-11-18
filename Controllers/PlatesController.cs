using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cademeucarro_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cademeucarro_api.Controllers
{
    [Route("plates")]
    public class PlatesController : Controller
    {
        private CadeMeuCarroDataContext _context;

        public PlatesController(CadeMeuCarroDataContext context)
        {
            _context = context;
        }

        [HttpGet, Route("search")]
        public async Task<ActionResult> SearchPlate([FromQuery]string plate = "")
        {
            var searchResult = await _context.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Plate == plate);

            if (searchResult == null)
            {
                return Ok(new { stolen = false });
            }

            return Ok(
                new
                {
                    stolen = searchResult.IsStolen,
                    stolenOn = searchResult.StolenOn
                });
        }

        [HttpPost, Route("add")]
        public async Task<ActionResult> NewCar([FromBody] Car car)
        {
            try
            {
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest(new { sucess = false });
            }

            return Ok(new { sucess = true });
        }
    }
}
