using System.Collections.Generic;
using WebApplication1.Data.Entities;

namespace WebApplication1.Service.Queries.Person
{
    public interface IAllPeopleDataQuery
    {
        IEnumerable<PersonEntity> Execute();
    }
}