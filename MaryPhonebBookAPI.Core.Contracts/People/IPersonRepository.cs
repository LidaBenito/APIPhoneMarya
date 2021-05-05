using MaryPhonebBookAPI.Core.Entities.People;
using System.Collections.Generic;

namespace MaryPhonebBookAPI.Core.Contracts.People
{
    public interface IPersonRepository
    {
        Person Get(int id);
        List<Person> GetAll();
        Person Add(Person person);
        void Delete(int id);
        void SaveChange();
            
    }
}
