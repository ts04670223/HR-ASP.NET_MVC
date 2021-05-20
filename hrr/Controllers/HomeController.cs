using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hrr.Models;

namespace hrr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dBmanager = new DBmanager();
            List<BasicInformation> basicInformations = dBmanager.GetCards();
            ViewBag.cards = basicInformations;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;


            return View();
        }
        public ActionResult CreateCard()
        {
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            return View();
        }
        [HttpPost]
        public ActionResult CreateCard(BasicInformation basicInformation)
        {
            DBmanager dBmanager = new DBmanager();
            try
            {
                dBmanager.NewCard(basicInformation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("CreateEducation");
        }
        public ActionResult EditCard(int id)
        {
            DBmanager dBmanager = new DBmanager();
            BasicInformation basicInformation = dBmanager.GetByID(id);
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            return View(basicInformation);
        }
        [HttpPost]
        public ActionResult EditCard(BasicInformation basicInformation)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.UpdateCard(basicInformation);
            return RedirectToAction("Index");
        }
        public ActionResult EditEducations(int id)
        {
            DBmanager dBmanager = new DBmanager();
            Educations education = dBmanager.GetByEdu(id);
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducations(Educations education)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.UpdateEducations(education);
            return RedirectToAction("EditExperiences");
        }
        public ActionResult EditExperiences(int id)
        {
            DBmanager dBmanager = new DBmanager();
            Experiences experience = dBmanager.GetByExp(id);
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            return View(experience);
        }
        [HttpPost]
        public ActionResult EditExperiences(Experiences experience)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.UpdateExperiences(experience);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCard(int id)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.DeleteCardById(id);
            return RedirectToAction("Index");
        }
        public ActionResult CreateEducation()
        {
            DBmanager dBmanager = new DBmanager();
            BasicInformation basicInformation = dBmanager.GetBasicInformationID();
            return View(basicInformation);
        }
        [HttpPost]
        public ActionResult CreateEducation(Educations BasicInformation)
        {
            DBmanager dB = new DBmanager();
            dB.CreateEducation(BasicInformation);
            return RedirectToAction("CreateExperience");
        }
        public ActionResult CreateExperience()
        {
            DBmanager dBmanager = new DBmanager();
            BasicInformation basicInformation = dBmanager.GetBasicInformationID();
            return View(basicInformation);
        }
        [HttpPost]
        public ActionResult CreateExperience(Experiences basicInformation)
        {
            DBmanager dBmanager = new DBmanager();
            dBmanager.CreateExperience(basicInformation);
            return RedirectToAction("Index");
        }
        
        public ActionResult Detail(int id)
        {
            DBmanager dBmanager = new DBmanager();
            BasicInformation basicInformation = dBmanager.GetByID(id);
            DBmanager manager = new DBmanager();
            Educations education = manager.GetByEdu(id);
            ViewBag.education = education;
            DBmanager S = new DBmanager();
            List<Supervisors> Supervisors = S.GetSupervisors();
            ViewBag.supervisor = Supervisors;
            DBmanager dB = new DBmanager();
            List<Departments> departments = dB.GetDepartments();
            ViewBag.department = departments;
            return View(basicInformation);
        }
        public ActionResult DetailEdu(int id)
        {
            DBmanager manager = new DBmanager();
            Educations education = manager.GetByEdu(id);
            return View(education);
        }
        public ActionResult DetailExp(int id)
        {
            DBmanager manager = new DBmanager();
            Experiences experience = manager.GetByExp(id);
            return View(experience);
        }
    }
}