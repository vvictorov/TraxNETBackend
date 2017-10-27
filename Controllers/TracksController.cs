using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraxNETBackend.Models;

namespace TraxNETBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Tracks")]
    public class TracksController : Controller
    {
        private readonly TraxContext DbContext;

        public TracksController(TraxContext context)
        {
            DbContext = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public IEnumerable<Tracks> GetTracks()
        {
            return DbContext.Tracks.ToList();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}", Name = "GetTrack")]
        public IActionResult GetById(long id)
        {
            Tracks track = DbContext.Tracks.FirstOrDefault(t => t.Id == id);
            if(track == null)
            {
                return NotFound();
            }
            return new JsonResult(track);
        }
        
        // POST: api/Tracks
        [HttpPost]
        public void Post([FromBody]Tracks track)
        {

        }
        
        // PUT: api/Tracks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
