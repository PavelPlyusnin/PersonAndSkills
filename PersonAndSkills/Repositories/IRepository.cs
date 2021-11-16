using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonAndSkills.Model;

namespace PersonAndSkills.Repositories
{
    interface IRepository
    {
        IEnumerable<Person> GetAll();
    }
}
