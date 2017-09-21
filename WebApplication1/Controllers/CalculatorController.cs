using System.Web.Mvc;
using WebApplication1.Models.Calculator;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculatorEngine _calculatorEngine;

        public CalculatorController(ICalculatorEngine calculatorEngine)
        {
            _calculatorEngine = calculatorEngine;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            model.Sum = _calculatorEngine
                .Add(model.FirstValue, model.SecondValue);

            return View(model);
        }
    }
}