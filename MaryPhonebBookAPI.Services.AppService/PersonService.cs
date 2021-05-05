using MaryPhonebBookAPI.Core.Contracts.People;
using MaryPhonebBookAPI.Core.Contracts.Phones;
using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Core.Entities.Phones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaryPhonebBookAPI.Services.AppService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPhoneRespository _phoneRespository;

        public PersonService(IPersonRepository personRepository,IPhoneRespository phoneRespository)
        {
            _personRepository = personRepository;
            _phoneRespository = phoneRespository;
        }

        public void AddPerson(Person person)
        {
            _personRepository.Add(person);
        }

        public void AddPersonsPhone(int personId, Phone phone)
        {
            var person = _personRepository.Get(personId);
            person.Phones.Add(phone);
            _personRepository.SaveChange();
        }

        public void DeletePerson(int personId)
        {
            var phones = _phoneRespository.GetPersonPhoneList(personId);
            if (!phones.Any())
            {
                _personRepository.Delete(personId);
            }
        }

        public void DeletePersonsPhone(int phoneId)
        {
            _phoneRespository.Delete(phoneId);
        }

        public List<Person> GetAllPerson()
        {
            return _personRepository.GetAll();
        }

        public Person GetPerson(int personId)
        {
            return _personRepository.Get(personId);
        }

        public List<Phone> GetPersonsPhoneList(int personId)
        {
            return _phoneRespository.GetPersonPhoneList(personId);
        }

        public void UpdatePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void updatePersonsPhone(int phoneId)
        {
            throw new NotImplementedException();
        }
    }
}
