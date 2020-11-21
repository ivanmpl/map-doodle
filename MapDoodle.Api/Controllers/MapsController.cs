using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapDoodle.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapDoodle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly MapContext _context;
        public MapsController(MapContext context)
        {
            _context = context;
        }

        // GET: api/Maps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Map>>> GetMaps()
        {
            return await _context.Maps.ToListAsync();
        }

        // GET: api/Maps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Map>> GetMap(long id)
        {
            var map = await _context.Maps.FindAsync(id);

            if (map == null)
            {
                return NotFound();
            }

            return map;
        }

        // POST: api/Maps
        [HttpPost]
        public async Task<ActionResult<Map>> PostMap(Map map)
        {
            _context.Maps.Add(map);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMap), new { id = map.Id }, map);
        }
    }
}