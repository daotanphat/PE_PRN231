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
    public class ScheduleController : Controller
    {
        // GET: /<controller>/
        
        [HttpGet]
        [Route("{date?}")]
        public IActionResult List(DateTime date)
        {
            return Ok(
                DataGeneration.Schedules.Where(s => s.StartDate <= date && s.EndDate >= date)
                .Select(s => new {s.Id, s.MovieId, s.RoomId, s.TimeSlotId, s.StartDate, s.EndDate, s.Note})
                .ToList());
        }

    }
}

