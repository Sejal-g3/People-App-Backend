using SimplePeopleApi.Data;
using SimplePeopleApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimplePeopleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPeople()
        {
            return Ok(await _context.People.ToListAsync());
        }

        [HttpGet]
        [Route(("{id}"))]
        public async Task<ActionResult<List<Person>>> GetPerson(int id)
        {
            return Ok(await _context.People.ToListAsync());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            var dbPerson = await _context.People.FindAsync(person.Id);
            if (dbPerson == null)
                return BadRequest("Person not found.");

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;
            dbPerson.PhoneNumber = person.PhoneNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var dbPerson = await _context.People.FindAsync(id);
            if (dbPerson == null)
                return BadRequest("Person not found.");

            _context.People.Remove(dbPerson);
            await _context.SaveChangesAsync();

            return Ok(await _context.People.ToListAsync());
        }
    }
}
