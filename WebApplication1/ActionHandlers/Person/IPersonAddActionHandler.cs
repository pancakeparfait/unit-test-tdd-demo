using WebApplication1.Models.Person;

namespace WebApplication1.ActionHandlers.Person
{
    public interface IPersonAddActionHandler
    {
        void Handle(AddPersonViewModel model);
    }
}