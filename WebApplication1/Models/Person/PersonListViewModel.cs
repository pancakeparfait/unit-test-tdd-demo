using System.ComponentModel;

namespace WebApplication1.Models.Person
{
    public class PersonListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Given Name")]
        public string GivenName { get; set; }

        [DisplayName("Surname")]
        public string Surname { get; set; }
    }
}