
using MaryPhonebBookAPI.Core.Contracts.People;
using MaryPhonebBookAPI.Core.Entities.People;
using MaryPhonebBookAPI.Infra.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaryPhonebBookAPI.Infra.DAL.People
{
    public class PersonRespository : IPersonRepository
    {
        private readonly MaryaPhoneContext _context;

        public PersonRespository(MaryaPhoneContext Context)
        {
            _context = Context;
        }
        public Person Add(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
            return person;
        }

        public void Delete(int id)
        {
            _context.People.Remove(Get(id));

            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            return _context.People.Find(id);

        }

        public List<Person> GetAll()
        {

            return _context.People.ToList();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
