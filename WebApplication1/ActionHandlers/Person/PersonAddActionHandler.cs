using WebApplication1.Models.Person;
using WebApplication1.Service.InfoObjects.Person;
using WebApplication1.Service.Resources.Person;

namespace WebApplication1.ActionHandlers.Person
{
    public class PersonAddActionHandler : IPersonAddActionHandler
    {
        private readonly IPersonResourceService _personResourceService;

        public PersonAddActionHandler(IPersonResourceService personResourceService)
        {
            _personResourceService = personResourceService;
        }

        public void Handle(AddPersonViewModel model)
        {
            _personResourceService
                .AddPerson(new AddPersonInfo
                {
                    GivenName = model.GivenName,
                    Surname = model.Surname
                });
        }
    }
}