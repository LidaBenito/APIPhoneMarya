using MaryPhonebBookAPI.Core.Entities.Phones;
using System.Collections.Generic;

namespace MaryPhonebBookAPI.Core.Contracts.Phones
{
    public interface IPhoneRespository
    {
        Phone Get(int Id);
        void Delete(int Id);
        Phone Add(Phone phone);
        List<Phone> GetPersonPhoneList(int Id);
    }
}
