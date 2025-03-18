using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GivenAPIs.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GivenAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TimeSlotController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult List()
        {
            return Ok(DataGeneration.TimeSlots
                .Select(t => new {t.Id, t.StartTime, t.EndTime})
                .ToList());
        }
        
    }
}

