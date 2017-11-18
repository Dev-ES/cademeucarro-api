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
        [HttpGet, Route("search")]
        public ActionResult SearchPlate()
        {
            return Ok(new {
                stolen = false
            });
        }
    }
}
