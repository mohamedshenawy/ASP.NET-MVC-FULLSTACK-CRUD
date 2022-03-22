using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewLayer.Filters;

namespace ViewLayer.Controllers
{
    
    public class HomeController : Controller
    {
        IUnitOfWork unitOfWork;
        IModelRepo<Student> StudentRepo;
        UserRepo UserRepo;
        

        public HomeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            StudentRepo = unitOfWork.GetRepo();
            UserRepo = unitOfWork.GetUserRepo();
        }

        // GET: Home
        [Authentication]
        public ActionResult Index()
        {
            //if (Session["user"] == null)
            //    return View("LogIn");


            var students = StudentRepo.Read();
            
            return View("Index" , students);
        }
        [Authentication]
        public ActionResult Create()
        {
            if (Session["user"] == null)
                return View("LogIn");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Student std)
        {
            if (ModelState.IsValid == false)
                return View("Create");


            StudentRepo.Create(std);
            unitOfWork.Save();
            return Index();
        }
        [Authentication]
        public ActionResult Update(int id)
        {
            if (Session["user"] == null)
                return View("LogIn");


            var std = StudentRepo.GetByID(id);
            return View( "Update" , std);
        }
        [HttpPost]
        public ActionResult Update(Student std)
        {
            if (ModelState.IsValid == false)
                return View("Update", std);

            StudentRepo.Update(std);
            unitOfWork.Save();
            return Index();
        }
        [Authentication]
        public ActionResult Delete(int id)
        {
            Student std = new Student { ID = id };
            StudentRepo.Delete(std);
            unitOfWork.Save();
            var students = StudentRepo.Read();
            return Index();
        }

        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost]
        public ActionResult LogIn(User user)
        {
            
            if (ModelState.IsValid == false)
                return PartialView("LogIn");


            bool check = UserRepo.LogInCheck(user.Name, user.Password);

            if (!check)
                return PartialView("LogIn");

            var students = StudentRepo.Read();
            Session["user"] = user;
            return View("Index" , students);
        }
    }
}