using PagedList;
using PROJET_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJET_1.Controllers
{
    public class EvenementController : Controller
    {
        // GET: Evenement

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult lastArticle()
        {
            Model1 db = new Model1();
            var model = db.activites.Where(u => u.state.Equals("enable")).OrderByDescending(e => e.id).ToList();
            return PartialView("~/Views/Shared/_EvenementLayoutPage.cshtml", model);
        }

        public ActionResult events_img()
        {
            Model1 db = new Model1();
            ViewData["activitie"] = GetActivities();
            lastArticle();
            return View();
        }
        
        public ActionResult gallerie(int id)
        {
            Model1 db = new Model1();
            ViewData["id"] = id;
            ViewData["titre"] = db.activites.Find(id).titre;
            ViewData["gallerie"] = GetGallerie();
            lastArticle();
            return View();
        }
        public ActionResult page_home(string sortOrder, string CurrentSort, int? page)
        {
            Model1 db = new Model1();
            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Activite> actt = db.activites.Where(e => e.state.Equals("enable")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);
            IPagedList<actualite> actualite = db.actualites.Where(e => e.state.Equals("enable")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);

            List<Activite> act = db.activites.Where(e => e.state.Equals("enable")).ToList();
            ViewData["actualite"] = actualite;
            ViewData["newactivite"] = act;
            ViewData["nbrEvents"] = db.activites.Count();
            ViewData["nbrImages"] = db.galleries.Count();
            ViewData["nbrLauriat"] = db.laureats.Count();

            ViewData["nbrLauriatGi"] = db.laureats.Where(u => u.filiere1.nom.Equals("gi")).Count()*15;
            ViewData["nbrLauriatGind"] = db.laureats.Where(u => u.filiere1.nom.Equals("gind")).Count() * 15 ;
            ViewData["nbrLauriatGtr"] = db.laureats.Where(u => u.filiere1.nom.Equals("gtr")).Count() * 15; 
            ViewData["nbrLauriatGpmc"] = db.laureats.Where(u => u.filiere1.nom.Equals("gpmc")).Count() * 15;
            lastArticle();
            return View(actt);
        }

        public ActionResult activitie(int id)
        {
    
            Model1 db = new Model1();
            ViewData["date"] = db.activites.Find(id).date.ToString("dd/MM/yyyy");
            ViewData["img"] = db.activites.Find(id).piece_joint;
            ViewData["desc"] = db.activites.Find(id).description;
            //ViewData["resp"] = db.Responsables.Find(db.activites.Find(id).responsable).nom;
            ViewData["titre"] = db.activites.Find(id).titre;
            ViewData["activitie"] = GetActivities();
            ViewData["gallerie"] = GetGallerie();
            lastArticle();
            return View();
        }
        public ActionResult actualite(int id)
        {

            Model1 db = new Model1();
            ViewData["date"] = db.actualites.Find(id).date.ToString("dd/MM/yyyy");
            ViewData["img"] = db.actualites.Find(id).piece_joint;
            ViewData["desc"] = db.actualites.Find(id).description;
            //ViewData["resp"] = db.Responsables.Find(db.activites.Find(id).responsable).nom;
            ViewData["titre"] = db.actualites.Find(id).titre;
            ViewData["activitie"] = GetActivities();
            lastArticle();
            return View();
        }


        private List<Activite> GetActivities()
        {
            Model1 db = new Model1();
            List<Activite> teachers = db.activites.Where(u => u.state.Equals("enable")).ToList();
            return teachers;
        }
        private List<gallerie> GetGallerie()
        {
            Model1 db = new Model1();
            List<gallerie> teachers = db.galleries.ToList();
            return teachers;
        }
        public ActionResult Login()
        {
            if (!string.IsNullOrEmpty((string)Session["Admin"]))
            {
                return Redirect("/HOME/index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string mp)
        {

            Model1 db = new Model1();
            var x = db.admins.ToList();

            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(mp))
            {
                return RedirectToAction("Login");
            }
            foreach (admin ad in x)
            {
                if (ad.username == username && ad.mdp == mp)
                {
                    Session["Admin"] = username;
                    ViewBag.MySession = Session["Admin"];
                    return Redirect("/HOME/index");
                }
            }
            ViewBag.MyMsg = "mot de pass ou l'email est pas correct";
            return View();

        }
        public ActionResult Laureat(string sortOrder, string CurrentSort, int? page)
        {
            Model1 db = new Model1();
            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "gi" : sortOrder;
            IPagedList<laureat> employees = null;
            switch (sortOrder)
            {
                case "gi":
                        employees = db.laureats.Where(e => e.filiere1.nom.Equals("gi")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);
                   
                    break;
                case "gtr":
                   
                        employees = db.laureats.Where(e => e.filiere1.nom.Equals("gtr")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);
                   
                    break;
                case "gind":
                   
                        employees = db.laureats.Where(e => e.filiere1.nom.Equals("gind")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);

                    break;
                case "gpmc":

                        employees = db.laureats.Where(e => e.filiere1.nom.Equals("gpmc")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);

                    break;
                case "Default":
                    employees = db.laureats.Where(e => e.filiere1.nom.Equals("gi")).OrderByDescending(m => m.id).ToPagedList(pageIndex, pageSize);
                    break;
            }
            
            return View(employees);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

    }
}