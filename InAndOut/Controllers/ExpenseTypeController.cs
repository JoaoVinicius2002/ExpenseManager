using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenseTypes = _db.ExpenseTypes;
            return View(expenseTypes);
        }
        //Get Create
        public IActionResult Create()
        {

            return View();
        }
        //POST Create
        [HttpPost]
        public IActionResult Create(ExpenseType entity)
        {
            if(entity != null)
            {
                _db.ExpenseTypes.Add(entity);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var model = _db.ExpenseTypes.Find(id);
            return View(model);
        }
        //POST Create
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            if (id != null)
            {
                var expenseType = _db.ExpenseTypes.Find(id);
                _db.ExpenseTypes.Remove(expenseType);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var model = _db.ExpenseTypes.Find(id);
            return View(model);
        }
        //POST Create
        [HttpPost]
        public IActionResult UpdatePost(ExpenseType entity)
        {
            if (entity != null)
            {
                _db.ExpenseTypes.Update(entity);
                var model = _db.ExpenseTypes.Find(entity);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
