using MaryPhonebBookAPI.Core.Contracts.People;
using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Core.Entities.Phones;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaryPhonebBookAPI.Endpoints.WebAPIUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PhoneController(IPersonService personService)
        {
            _personService = personService;
        }
     
        // GET api/<PhoneController>/5
        [HttpGet("{personId}/Phone")]
        public ActionResult<Person> Get(int id)
        {
            var result = _personService.GetPersonsPhoneList(id);
            if (result == null)
                return NotFound();
            else
                return Ok(result);
            
        }

        // POST api/<PhoneController>
        [HttpPost("{personId}/Phone")]
        public ActionResult Post([FromBody] int personId, [FromBody] Phone phone)
        {
            if (!ModelState.IsValid)

                return BadRequest();

            else
            {
                if (phone == null)

                    return NotFound();

                else
                {
                    _personService.AddPersonsPhone(personId, phone);
                    string Uri = string.Format($"api/{0}/Phone", personId);
                    return Created(Uri, phone);
                }
            }
        }

        // PUT api/<PhoneController>/5
        [HttpPut("Phone{id:Int}")]
        public ActionResult Put([FromBody]  int id, [FromBody] Phone  phone)
        {
            if (id <=0 )
            
                return NotFound();
            
            else
            {
                _personService.UpdatePerson(id);
                return NoContent();
            }
        }

        // DELETE api/<PhoneController>/5
        [HttpDelete("Phone{id:Int}")]
        public ActionResult Delete([FromBody]int id)
        {
            if (id <=0)
            
                return NotFound();
            
            else
            {
                _personService.DeletePersonsPhone(id);
                return NoContent();
            }
        }
    }
}
