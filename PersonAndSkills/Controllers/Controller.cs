using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonAndSkills.Contexts;
using PersonAndSkills.Model;
using PersonAndSkills.Repositories;

namespace PersonAndSkills.Controllers
{
    [ApiController]
    [Route("api/Person")]
    public class Controller : ControllerBase
    {
        private Repository repository;

        public Controller(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet("GetPersons")]
        public IEnumerable<Person> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("GetPersonById")]
        public Person Get(long personId)
        {
            return repository.GetPersonById(personId);

        }
        [HttpPost("AddPerson")]
        public Person AddPerson(Person person)
        {
            return repository.AddPerson(person);

        }
        [HttpPut("UpdatePerson")]
        public void Update(Person person)
        {
            repository.Update(person);

        }
        [HttpDelete("Delete")]
        public void Delete(long personId)
        {
            repository.DeletePerson(personId);

        }
    }
}
