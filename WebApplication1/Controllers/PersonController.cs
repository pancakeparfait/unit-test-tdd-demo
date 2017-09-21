using System.Web.Mvc;
using WebApplication1.ActionHandlers.Person;
using WebApplication1.Models.Person;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        #region [Dependencies]

        private readonly IPersonAddActionHandler _personAddActionHandler;
        private readonly IPersonIndexActionHandler _personIndexActionHandler;
        private readonly IPersonRemoveActionHandler _personRemoveActionHandler;

        #endregion [Dependencies]

        #region [Ctors]

        public PersonController(
            IPersonAddActionHandler personAddActionHandler,
            IPersonIndexActionHandler personIndexActionHandler,
            IPersonRemoveActionHandler personRemoveActionHandler)
        {
            _personAddActionHandler = personAddActionHandler;
            _personIndexActionHandler = personIndexActionHandler;
            _personRemoveActionHandler = personRemoveActionHandler;
        }

        #endregion [Ctors]

        public ActionResult Index()
        {
            var model = _personIndexActionHandler.Handle();

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddPersonViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _personAddActionHandler.Handle(model);

            return RedirectToAction("Index");
        }
        
        public ActionResult Remove(int id)
        {
            _personRemoveActionHandler.Handle(id);

            return RedirectToAction("Index");
        }
    }
}