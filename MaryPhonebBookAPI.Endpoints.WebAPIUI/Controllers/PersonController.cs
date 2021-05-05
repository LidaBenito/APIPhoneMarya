using MaryPhonebBookAPI.Core.Contracts.People;
using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Endpoints.WebAPIUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaryPhonebBookAPI.Endpoints.WebAPIUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        // GET: api/<PersonController>
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public List<PersonViewModel> Get()
        {
            var person = _personService.GetAllPerson();
            List<PersonViewModel> peopleList = new List<PersonViewModel>();

            foreach (var item in person)
            {
                peopleList.Add(new PersonViewModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Address = item.Address
                });

            };
            return peopleList;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id:Int}")]
        public ActionResult<Person> Get([FromRoute] int id)
        {
            var result = _personService.GetPerson(id);
            if (result == null || result?.PersonId < 1)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            else
            {
                if (person == null)
                    return NotFound();
                else
                {
                    _personService.AddPerson(person);
                    return CreatedAtAction(nameof(Get), new { id = person.PersonId }, person);
                }
            }
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id:Int}")]
        public ActionResult Put(int id, [FromBody] Person  person)
        {
            if (id <= 0)
                return NotFound();
            else
            {
                _personService.UpdatePerson(id);
                return NoContent();
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id:Int}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();
            else
            {
                _personService.DeletePerson(id);
                return NoContent();
            }
        }
    }
}
