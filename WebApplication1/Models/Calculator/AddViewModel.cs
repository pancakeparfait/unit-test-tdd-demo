using System.ComponentModel;

namespace WebApplication1.Models.Calculator
{
    public class AddViewModel
    {
        [DisplayName("First Value")]
        public decimal FirstValue { get; set; }

        [DisplayName("Second Value")]
        public decimal SecondValue { get; set; }

        [DisplayName("Sum")]
        public decimal Sum { get; set; }
    }
}