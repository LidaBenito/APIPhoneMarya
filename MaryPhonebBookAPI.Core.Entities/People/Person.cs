using MaryPhonebBookAPI.Core.Entities.Phones;
using System.Collections.Generic;

namespace MaryPhonebBookAPI.Core.Entities.People
{
    public class Person
    {
        public  int  PersonId{ get; set; }
        public  string FirstName{ get; set; }
        public  string  LastName{ get; set; }
        public  string  Email{ get; set; }
        public  string Address{ get; set; }
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
