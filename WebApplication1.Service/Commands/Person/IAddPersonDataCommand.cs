namespace WebApplication1.Service.Commands.Person
{
    public interface IAddPersonDataCommand
    {
        void Execute(string givenName, string surname);
    }
}