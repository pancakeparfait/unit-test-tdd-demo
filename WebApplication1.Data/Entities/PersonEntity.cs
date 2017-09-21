using System;

namespace WebApplication1.Data.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}