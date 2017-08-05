using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GomelRectorCouncilWebApi.Models;
using GomelRectorCouncilWebApi.Data;

namespace GomelRectorCouncilWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UniversitiesController : Controller
    {
        private readonly CouncilDbContext _context;
        public UniversitiesController(CouncilDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<University> Get()
        {
            return _context.Universities.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int UniversityId)
        {
            University university = _context.Universities.FirstOrDefault(x => x.UniversityId == UniversityId);
            if (university == null)
                return NotFound();
            return new ObjectResult(university);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]University university)
        {
            if (university == null)
            {
                return BadRequest();
            }

            _context.Universities.Add(university);
            _context.SaveChanges();
            return Ok(university);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]University university)
        {
            if (university == null)
            {
                return BadRequest();
            }
            if (!_context.Universities.Any(x => x.UniversityId == university.UniversityId))
            {
                return NotFound();
            }

            _context.Update(university);
            _context.SaveChanges();
            return Ok(university);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int universityId)
        {
            University university = _context.Universities.FirstOrDefault(x => x.UniversityId == universityId);
            if (university == null)
            {
                return NotFound();
            }
            _context.Universities.Remove(university);
            _context.SaveChanges();
            return Ok(university);
        }
    }
}
