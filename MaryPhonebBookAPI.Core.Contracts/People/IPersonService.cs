using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Core.Entities.Phones;
using System.Collections.Generic;

namespace MaryPhonebBookAPI.Core.Contracts.People
{
    public interface IPersonService
    {
        List<Person> GetAllPerson();
        Person GetPerson(int personId);
        void AddPerson(Person person);
        void AddPersonsPhone(int personId, Phone phone);
        void UpdatePerson(int personId);
        void updatePersonsPhone(int phoneId);
        void DeletePerson(int personId);
        void DeletePersonsPhone(int phoneId);
        List<Phone> GetPersonsPhoneList(int personId);

    }
}
