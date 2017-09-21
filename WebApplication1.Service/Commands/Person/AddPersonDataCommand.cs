using System;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Service.Commands.Person
{
    public class AddPersonDataCommand : IAddPersonDataCommand
    {
        private readonly IDataSource _dataSource;

        public AddPersonDataCommand(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public void Execute(string givenName, string surname)
        {
            if (string.IsNullOrEmpty(givenName)) throw new ArgumentNullException(nameof(givenName));
            if (string.IsNullOrEmpty(surname)) throw new ArgumentNullException(nameof(surname));

            var now = DateTime.Now;
            _dataSource.Persons.Add(new PersonEntity
            {
                GivenName = givenName,
                Surname = surname,
                CreatedOn = now,
                UpdatedOn = now
            });
        }
    }
}