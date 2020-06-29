using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppExampleMighty.Models;

namespace WebAppExampleMighty.Controllers
{
    public class PersonController : Controller
    {
        public DaoPerson Dao { get; }

        public PersonController(DaoPerson dao)
        {
            Dao = dao;
        }
        public ActionResult Index()
        {
            return View(Dao.All());
        }

        public ActionResult Details(int id)
        {
            var person = GetPerson(id);
            return View(person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dao.Insert(person);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var person = GetPerson(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dao.Update(person);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var person = GetPerson(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (id == 0)
                {
                    return RedirectToAction("Index");
                }
                Dao.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public Person GetPerson(int id) => Dao.Single(id);
    }
}
