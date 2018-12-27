using System;
using System.Net.Http;
using System.Threading.Tasks;
using CademeucarroApi.Models;
using CademeucarroApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CademeucarroApi.Controllers
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
            plate = plate.ToUpperInvariant();
            var sinespSearch = await SinespSearch(plate);

            var searchResult = await GetCarByPlate(plate);

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

        private async Task<Car> GetCarByPlate(string plate)
        {
            if (string.IsNullOrEmpty(plate))
            {
                return null;
            }

            var searchResult = await _context.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Plate.ToUpperInvariant() == plate);

            return searchResult;
        }

        [HttpPost, Route("add")]
        public async Task<ActionResult> NewCar([FromBody] Car car)
        {
            try
            {
                car.Plate = car.Plate.ToUpperInvariant();
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return BadRequest(new { sucess = false });
            }

            return Ok(new { sucess = true });
        }

        [HttpPost, Route("track")]
        public async Task<ActionResult> TrackCar([FromBody]TrackCarRequest trackRequest)
        {
            var car = await GetCarByPlate(trackRequest.Plate.ToUpperInvariant());
            var track = new TrackCar
            {
                CarId = car?.Id,
                Plate = trackRequest.Plate,
                Lat = trackRequest.Lat,
                Long = trackRequest.Long,
                CameraId = trackRequest.Camera,
                TrackedAt = DateTime.UtcNow
            };
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return Ok(track.Id);
        }
    }
}
