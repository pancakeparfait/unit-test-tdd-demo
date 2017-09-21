using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data
{
    public class DataSource : IDataSource
    {
        private int _nextId = 1;

        public DataSource()
        {
            Persons = new List<PersonEntity>
            {
                new PersonEntity { Surname = "Gyaltshen", GivenName = "Vicky" },
                new PersonEntity { Surname = "Rich", GivenName = "Marcus" },
                new PersonEntity { Surname = "Ruggless", GivenName = "Norma" }
            };

            var now = DateTime.Now;
            Persons
                .ToList()
                .ForEach(x =>
                {
                    x.Id = GetNextId();
                    x.CreatedOn = now;
                    x.UpdatedOn = now;
                });
        }

        private int GetNextId()
        {
            return _nextId++;
        }

        public ICollection<PersonEntity> Persons { get; set; }

        public void SaveChanges()
        {
            Persons
                .Where(x => x.Id == 0)
                .ToList()
                .ForEach(x => x.Id = GetNextId());
        }
    }
}