using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Person
{
    public class AddPersonViewModel
    {
        [DisplayName("Given Name")]
        [Required]
        public string GivenName { get; set; }

        [DisplayName("Surname")]
        [Required]
        public string Surname { get; set; }
    }
}