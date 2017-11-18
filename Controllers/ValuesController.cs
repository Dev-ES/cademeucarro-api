using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cademeucarro_api.Controllers
{
    [Route("values")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Dev-ES", "PicPay" };
        }
    }
}
