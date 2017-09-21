using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Person;
using WebApplication1.Service.Resources.Person;

namespace WebApplication1.ActionHandlers.Person
{
    public class PersonIndexActionHandler : IPersonIndexActionHandler
    {
        private readonly IPersonResourceService _personResourceService;

        public PersonIndexActionHandler(IPersonResourceService personResourceService)
        {
            _personResourceService = personResourceService;
        }

        public IEnumerable<PersonListViewModel> Handle()
        {
            return _personResourceService
                .GetAll()
                .Select(x => new PersonListViewModel
                {
                    Id = x.Id,
                    GivenName = x.GivenName,
                    Surname = x.Surname
                })
                .OrderBy(x => x.Surname);
        }
    }
}