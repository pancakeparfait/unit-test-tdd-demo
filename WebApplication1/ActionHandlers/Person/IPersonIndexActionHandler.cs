using System.Collections.Generic;
using WebApplication1.Models.Person;

namespace WebApplication1.ActionHandlers.Person
{
    public interface IPersonIndexActionHandler
    {
        IEnumerable<PersonListViewModel> Handle();
    }
}