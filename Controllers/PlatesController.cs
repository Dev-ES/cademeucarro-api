using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using cademeucarro_api.Models;
using cademeucarro_api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            var sinespSearch = await SinespSearch(plate);
            
            var searchResult = await _context.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Plate == plate);

            if (searchResult != null)
            {
                sinespSearch.IsStolen = searchResult.IsStolen;
                sinespSearch.StolenOn = searchResult.StolenOn;
            }

            return Ok(sinespSearch);
        }

        private async Task<SearchResult> SinespSearch(string plate) 
        {
            const string sinespUrl = "http://18.231.13.29:3000/api/plate";
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync($"{sinespUrl}/{plate}");
                var data = JsonConvert.DeserializeObject<SearchResult>(result);
                return data;
            }
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
