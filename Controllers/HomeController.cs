using System;
using System.Linq;
using System.Web.Mvc;
using TestProject.Models;
using TestTask.Data;
using System.Data.Entity;
using TestProject.Utils; 

namespace TestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            // Test
            //throw new Exception("Test exception for logging.");

            try
            {
                var myEntities = _db.MyEntities.ToList();
                return View(myEntities);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View(new MyEntity());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MyEntity myEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.MyEntities.Add(myEntity);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                ModelState.AddModelError("", "An error occurred while creating the entity.");
            }
            return View(myEntity);
        }

        public ActionResult Edit(int id)
        {
            try
            {
                MyEntity myEntity = _db.MyEntities.Find(id);
                if (myEntity == null)
                {
                    return HttpNotFound();
                }
                return View(myEntity);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyEntity myEntity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(myEntity).State = EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                ModelState.AddModelError("", "An error occurred while updating the entity.");
            }
            return View(myEntity);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                MyEntity myEntity = _db.MyEntities.Find(id);
                if (myEntity == null)
                {
                    return HttpNotFound();
                }
                return View(myEntity);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MyEntity myEntity = _db.MyEntities.Find(id);
                if (myEntity != null)
                {
                    _db.MyEntities.Remove(myEntity);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            try
            {
                ViewBag.Message = "Description page.";
                return View();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

        public ActionResult Contact()
        {
            try
            {
                ViewBag.Message = "Contact page.";
                return View();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return View("Error");
            }
        }

    }
}
