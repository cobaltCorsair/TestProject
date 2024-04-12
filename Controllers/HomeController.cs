using System;
using System.Linq;
using System.Web.Mvc;
using TestProject.Models;
using TestTask.Data;
using System.Data.Entity;
using TestProject.Filters;

namespace TestProject.Controllers
{
    [HandleExceptions] // Применяем фильтр ко всему контроллеру
    // Управление основными страницами приложения
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        // Внедрение зависимостей для доступа к контексту базы данных
        public HomeController()
        {
            _db = new ApplicationDbContext();
        }
        
        // Показывает список сущностей
        public ActionResult Index()
        {
            // Тестовая ошибка для проверки работоспособности лога
            //throw new Exception("Test exception");

            var myEntities = _db.MyEntities.ToList();
            return View(myEntities);
        }

        // Отображение формы для создания сущности
        public ActionResult Create()
        {
            return View(new MyEntity());
        }

        // Обработка создания сущности
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MyEntity myEntity)
        {
            if (ModelState.IsValid)
            {
                _db.MyEntities.Add(myEntity);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myEntity);
        }

        // Подготовка к редактированию сущности
        public ActionResult Edit(int id)
        {
            var myEntity = _db.MyEntities.Find(id);
            if (myEntity == null)
            {
                return HttpNotFound();
            }
            return View(myEntity);
        }

        // Обновление сущности после редактирования
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyEntity myEntity)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(myEntity).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myEntity);
        }

        // Удаление сущности
        public ActionResult Delete(int id)
        {
            var myEntity = _db.MyEntities.Find(id);
            if (myEntity == null)
            {
                return HttpNotFound();
            }
            return View(myEntity);
        }

        // Подтверждение удаления сущности
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var myEntity = _db.MyEntities.Find(id);
            if (myEntity != null)
            {
                _db.MyEntities.Remove(myEntity);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Информационная страница
        public ActionResult About()
        {
            return View();
        }

        // Контактная информация
        public ActionResult Contact()
        {
            return View();
        }

        // Очистка ресурсов
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
