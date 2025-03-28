using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Dal;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        Studal SDal = new Studal();
        [HttpGet]
        public ActionResult Index()
        {
             var stud=SDal.GetAllStudents();
            return View(stud);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); // Redirect if ID is missing
            }

            Registration registration = SDal.GetStudentById(id.Value); // Use id.Value safely
            if (registration == null)
            {
                return HttpNotFound(); // Handle case where student is not found
            }

            return View(registration);
        }

        [HttpPost]
        public ActionResult Update(Registration registration)
        {
            if (ModelState.IsValid)
            {
                SDal.UpdateStudent(registration);
                return RedirectToAction("Update");
            }
            return View(registration);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Registration registration = SDal.GetStudentById(id);
            return View(registration);
        }

       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SDal.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                SDal.AddStudents(registration);
                return RedirectToAction("Index");
            }
            return View(registration);
        }
        
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}