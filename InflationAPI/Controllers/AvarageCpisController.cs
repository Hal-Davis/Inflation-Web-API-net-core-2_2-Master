using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InflationAPI.Models;

namespace InflationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvarageCpisController : ControllerBase
    {
        private readonly infContext _context;

        public AvarageCpisController(infContext context)
        {
            _context = context;
        }

        // GET: api/AvarageCpis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvarageCpi>>> GetAvarageCpi()
        {
            return await _context.AvarageCpi.ToListAsync();
        }

        // GET: api/AvarageCpis/5
        [HttpGet("{StartYear}, {EndYear}, {WageOrPrice}")]
        public async Task<ActionResult<decimal>> GetCpiavg(int StartYear, int EndYear, decimal WageOrPrice)
        {
            var cpi1 = await _context.AvarageCpi.FindAsync(StartYear);

            var cpi2 = await _context.AvarageCpi.FindAsync(EndYear);


            if (cpi1 == null || cpi2 == null)
            {
                return NotFound();
            }

            var returnValue = Math.Round(WageOrPrice * ((decimal)cpi2.AvgCpi / (decimal)cpi1.AvgCpi), 2);

            return returnValue;
        }
        

        private bool AvarageCpiExists(int yearId)
        {
            return _context.AvarageCpi.Any(e => e.Year == yearId);
        }
    }
}
