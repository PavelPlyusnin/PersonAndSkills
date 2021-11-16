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

    
    }
}
