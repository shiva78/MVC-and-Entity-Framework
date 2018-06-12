using Add_Update_Delete.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Add_Update_Delete.Controllers
{
    public class HomeController : Controller
    {
        EmployeeInfoContext db = new EmployeeInfoContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.employeeInfo.ToList());
        }

        public ActionResult AddNewEmployee()
        {
            return View(new EmployeeInfo());
        }

        [HttpPost, ActionName("AddNewEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "FName, LName, Department")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.employeeInfo.Add(employeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInfo);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.employeeInfo.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeInfo model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.employeeInfo.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            EmployeeInfo deleteEmployee = db.employeeInfo.Find(id);
            if (ModelState.IsValid)
            {
                db.employeeInfo.Remove(deleteEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deleteEmployee);
        }
    }
}