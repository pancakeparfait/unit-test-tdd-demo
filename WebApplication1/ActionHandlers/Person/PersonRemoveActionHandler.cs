using WebApplication1.Service.Resources.Person;

namespace WebApplication1.ActionHandlers.Person
{
    public class PersonRemoveActionHandler : IPersonRemoveActionHandler
    {
        private readonly IPersonResourceService _personResourceService;

        public PersonRemoveActionHandler(IPersonResourceService personResourceService)
        {
            _personResourceService = personResourceService;
        }

        public void Handle(int id)
        {
            _personResourceService.RemovePerson(id);
        }
    }
}