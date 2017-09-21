using System.Collections.Generic;
using WebApplication1.Service.InfoObjects.Person;

namespace WebApplication1.Service.Resources.Person
{
    public interface IPersonResourceService
    {
        IEnumerable<PersonListInfo> GetAll();
        void AddPerson(AddPersonInfo model);
        void RemovePerson(int id);
    }
}