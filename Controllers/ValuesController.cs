using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CademeucarroApi.Controllers
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
