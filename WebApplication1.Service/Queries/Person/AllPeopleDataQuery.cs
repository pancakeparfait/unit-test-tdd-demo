using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Data.Entities;

namespace WebApplication1.Service.Queries.Person
{
    public class AllPeopleDataQuery : IAllPeopleDataQuery
    {
        private readonly IDataSource _dataSource;

        public AllPeopleDataQuery(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<PersonEntity> Execute()
        {
            return _dataSource.Persons;
        }
    }
}