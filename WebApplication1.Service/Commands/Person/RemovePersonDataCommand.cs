using System;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Service.Commands.Person
{
    public class RemovePersonDataCommand : IRemovePersonDataCommand
    {
        private readonly IDataSource _dataSource;

        public RemovePersonDataCommand(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Execute(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            var person = _dataSource.Persons.SingleOrDefault(x => x.Id == id);
            if (person == null) throw new ApplicationException($"Unable to find Person with Id '{id}'.");

            _dataSource.Persons.Remove(person);
        }
    }
}