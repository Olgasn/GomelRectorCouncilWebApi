using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<University> Get()
        {
            return _context.Universities.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
