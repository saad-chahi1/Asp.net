using PROJET_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJET_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {
            Model1 db = new Model1();

            return View(db.activites.ToList());
        }
        public ActionResult Laureats()
        {
            Model1 db = new Model1();
            var filiereList = db.filieres.ToList();
            ViewBag.FiliereList = new SelectList(filiereList, "id", "nom");
            ViewBag.Lauret = db.laureats.ToList();
            return View();

          

        }
        public ActionResult AddLaureats_page()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Laureat(laureat laureat)
        {
            try
            {
                Model1 db = new Model1();
                db.laureats.Add(laureat);
                db.SaveChanges();
                return View();

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



        }

        public ActionResult delete_laureat(int id)
        {
            Model1 db = new Model1();
            laureat l = db.laureats.Find(id);

            db.laureats.Remove(l);
            db.SaveChanges();
            return RedirectToAction("Laureats");

        }
        [HttpPost]
        public ActionResult Add_event(string titre, string description , DateTime event_date)
        {
            Console.WriteLine(titre + " " + description);
            Activite v = new Activite();

            v.titre = titre;
            v.description = description;
            v.state = "disable";
            v.date = event_date;
            v.piece_joint = "hhhh";
            
            Model1 db = new Model1();
            db.activites.Add(v);
            db.SaveChanges();
            return RedirectToAction("Events");
        }

        public ActionResult delete_event(int id)
        {
                Model1 db = new Model1();
                Activite v = db.activites.Find(id);
                db.activites.Remove(v);
                db.SaveChanges();
                return RedirectToAction("Events");

        }
        
        public ActionResult show_event(int id)
        {
            Model1 db = new Model1();
            Activite etu = db.activites.Find(id);
            db.activites.Find(id).state = "enable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Events");

        }
        
        public ActionResult hide_event(int id)
        {
            Model1 db = new Model1();
            Activite etu = db.activites.Find(id);
            db.activites.Find(id).state = "disable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Events");

        }

        public ActionResult add_event_page()
        {
            return View();
        }
    }
}