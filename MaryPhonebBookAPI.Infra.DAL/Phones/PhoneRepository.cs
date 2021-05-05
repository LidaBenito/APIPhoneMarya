using MaryPhonebBookAPI.Core.Contracts.Phones;
using MaryPhonebBookAPI.Core.Entities.Phones;
using MaryPhonebBookAPI.Infra.DAL.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MaryPhonebBookAPI.Infra.DAL.Phones
{
    public class PhoneRepository : IPhoneRespository
    {
        private readonly MaryaPhoneContext _context;

        public PhoneRepository(MaryaPhoneContext Context)
        {
            _context = Context;
        }
        public Phone Add(Phone phone)
        {
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return phone;
        }

        public void Delete(int Id)
        {
            _context.Phones.Remove(Get(Id));
            _context.SaveChanges();
        }

        public Phone Get(int Id)
        {
            return _context.Phones.Find(Id);
        }

        public List<Phone> GetPersonPhoneList(int Id)
        {
            var person = _context.People.Where(c => c.PersonId == Id).Include(c => c.Phones).FirstOrDefault();
            return person.Phones;
        }
    }
}
