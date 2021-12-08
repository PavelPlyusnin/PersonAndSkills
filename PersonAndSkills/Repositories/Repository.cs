using System.Collections.Generic;
using System.Linq;
//using System.Web.Http.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PersonAndSkills.Contexts;
using PersonAndSkills.Model;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

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
        /// <summary>
        /// вернуть все записи
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAll()
        {
            return context.Persons.Include(person => person.Skills);
        }
        /// <summary>
        /// вернуть запись с указанным personID
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public Person GetPersonById(long personId)
        {
            return context.Persons.Include(person => person.Skills)
                .FirstOrDefault(person => person.PersonId == personId);
        }
        /// <summary>
        /// добавить новую запись
        /// </summary>
        /// <param name="newPerson"></param>
        /// <returns></returns>

        public Person AddPerson(Person newPerson)
        {
            context.Persons.Add(newPerson);
            context.SaveChanges();
            return newPerson;
        }

        /// <summary>
        /// обновить сущкествующую запись
        /// </summary>
        /// <param name="person"></param>
        public void Update(Person person)
        {
            context.Persons.Update(person);
            context.SaveChanges();
        }
        /// <summary>
        /// удалить указанную запись
        /// </summary>
        /// <param name="personId"></param>
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
