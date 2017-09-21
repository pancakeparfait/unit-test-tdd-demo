using System.Collections.Generic;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public interface IDataSource
    {
        ICollection<PersonEntity> Persons { get; set; }
        void SaveChanges();
    }
}