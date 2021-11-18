using System.Collections.Generic;
using System.Linq;
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

        public Person GetPersonById(long personId)
        {
            return context.Persons.Include(person => person.Skills)
                .FirstOrDefault(person => person.PersonId == personId);
        }

        public Person AddPerson(Person newPerson)
        {
            context.Persons.Add(newPerson);
            context.SaveChanges();
            return newPerson;
        }

        public void Update(Person person)
        {
            context.Persons.Update(person);
            context.SaveChanges();
        }

        public void DeletePerson(long personId)
        {
            Person person = context.Persons.SingleOrDefault(value => value.PersonId.Equals(personId));

            if (person != null)
            {
                context.Entry(person).Collection(value => value.Skills).Load();
                context.Persons.Remove(person);
            }

            context.SaveChanges();
        }


    }
}
