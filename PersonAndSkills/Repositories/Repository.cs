using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonAndSkills.Contexts;
using PersonAndSkills.Model;

namespace PersonAndSkills.Repositories
{
    public class Repository : IRepository
    {
        private readonly Context context;

        public Repository(Context context)
        {
            this.context = context;
        }

        public Repository()
        {
            context = new Context();
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons.Include(person => person.Skills);
        }
    }
}
