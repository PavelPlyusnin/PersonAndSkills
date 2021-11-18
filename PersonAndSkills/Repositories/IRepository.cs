using System.Collections.Generic;
using PersonAndSkills.Model;

namespace PersonAndSkills.Repositories
{
    public interface IRepository
    {
        Person AddPerson(Person person);
        Person GetPersonById(long personId);
        IEnumerable<Person> GetAll();
        void Update(Person person);
        void DeletePerson(long personId);
    }
}