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
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            ViewData["nbrEvents"] = db.activites.Count();
            ViewData["nbrImages"] = db.galleries.Count();
            ViewData["nbrLauriat"] = db.laureats.Count();
            return View();
        }

        public ActionResult Events()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();

            return View(db.activites.ToList());
        }
        public ActionResult actualite()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();

            return View(db.actualites.ToList());
        }
        [HttpPost]
        public ActionResult Add_actualite(string titre, string description, DateTime event_date, HttpPostedFileBase path)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite v = new actualite();
            v.titre = titre;
            v.description = description;
            v.state = "disable";
            event_date = event_date.Date;        
            v.date = event_date;        
            int last_id;
            if (db.actualites.OrderByDescending(u => u.id).FirstOrDefault() == null)
            {
                last_id = 1;
            }
            else
            {
                last_id = db.actualites.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            }
            string url_pdf = Server.MapPath("~/images");
            path.SaveAs(url_pdf + "/ActualitePDF" + last_id + ".pdf");
            v.piece_joint = "../../images/ActualitePDF" + last_id + ".pdf";

            db.actualites.Add(v);
            db.SaveChanges();                                              
            return RedirectToAction("actualite");
        }

        [HttpPost]
        public ActionResult Add_event(string titre, string description , DateTime event_date ,HttpPostedFileBase path)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    Console.WriteLine(titre + " " + description + " image : " + path.FileName);
                    Activite v = new Activite();
                    gallerie g = new gallerie();

                    v.titre = titre;
                    v.description = description;
                    v.state = "disable";
                    event_date = event_date.Date;
                    v.date = event_date;
                    int last_id;
                    if (db.activites.OrderByDescending(u => u.id).FirstOrDefault() == null)
                    {
                        last_id = 1;
                    }
                    else
                    {
                        last_id = db.activites.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
                    }
                    string url_image = Server.MapPath("~/images");
                    path.SaveAs(url_image + "/ActivitieImage" + last_id + ".png");
                    v.piece_joint = "../../images/ActivitieImage" + last_id + ".png";


                    db.activites.Add(v);
                    db.SaveChanges();

                    db.galleries.Add(new gallerie()
                    {
                        path = v.piece_joint,
                        date = v.date,
                        type = "image",
                        id_activite = last_id
                    });
                    db.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.", ex);
                }
            }
            return RedirectToAction("Events");
        }

        [HttpPost]
        public ActionResult modifier_event(int id ,string titre, string description, DateTime event_date, HttpPostedFileBase path)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            Activite v = db.activites.Find(id);
            v.titre = titre;
            v.description = description;
            if (event_date!= null)
            {
                v.date = event_date;
            }
            if(path != null) {
                string url_image = Server.MapPath("~/images");
                path.SaveAs(url_image + "/ActivitieImage" + id + ".png");
                v.piece_joint = "../../images/ActivitieImage" + id + ".png";
            }

            db.Entry(v).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Events");
        }
        [HttpPost]
        public ActionResult modifier_actualite(int id, string titre, string description, DateTime event_date, HttpPostedFileBase path)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite v = db.actualites.Find(id);
            v.titre = titre;
            v.description = description;
            if (event_date != null)
            {
                v.date = event_date;
            }
            if (path != null)
            {
                string url_pdf = Server.MapPath("~/images");
                path.SaveAs(url_pdf + "/ActualitePDF" + id + ".pdf");
                v.piece_joint = "../../images/ActualitePDF" + id + ".pdf";
            }

            db.Entry(v).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("actualite");
        }

        public ActionResult delete_event(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
                Activite v = db.activites.Find(id);
                db.activites.Remove(v);
                db.SaveChanges();
                return RedirectToAction("Events");

        }
        
        public ActionResult show_event(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            Activite etu = db.activites.Find(id);
            db.activites.Find(id).state = "enable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Events");

        }
        
        public ActionResult hide_event(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            Activite etu = db.activites.Find(id);
            db.activites.Find(id).state = "disable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Events");

        }
        public ActionResult modifier_actualite_page(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite etu = db.actualites.Find(id);
            ViewData["modifie"] = etu;
            return View();

        }
        public ActionResult modifier_event_page(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            Activite etu = db.activites.Find(id);
            ViewData["modifie"] = etu;
            return View();

        }
        public ActionResult add_event_page()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            return View();
        }
        public ActionResult delete_actualite(int id)
        {

            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite v = db.actualites.Find(id);
            db.actualites.Remove(v);
            db.SaveChanges();
            return RedirectToAction("actualite");

        }

        public ActionResult show_actualite(int id)
        {

            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite etu = db.actualites.Find(id);
            db.actualites.Find(id).state = "enable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("actualite");

        }

        public ActionResult hide_actualite(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            actualite etu = db.actualites.Find(id);
            db.actualites.Find(id).state = "disable";
            db.Entry(etu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("actualite");

        }
        public ActionResult add_actualite_page()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            return View();
        }
        public ActionResult add_gallerie_page()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            var ActivitieList = db.activites.ToList();
            ViewBag.ActivitieList = new SelectList(ActivitieList, "id", "titre");
            return View();
        }
        public ActionResult Laureats()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            var filiereList = db.filieres.ToList();
            ViewBag.FiliereList = new SelectList(filiereList, "id", "nom");
            ViewBag.Lauret = db.laureats.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add_Laureat(laureat laureat)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            try
            {
                Model1 db = new Model1();
                laureat.state = "admin";
                laureat.password = "12345678";
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
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            laureat l = db.laureats.Find(id);

            db.laureats.Remove(l);
            db.SaveChanges();
            return RedirectToAction("Laureats");

        }
        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Session["Admin"] = null;
            
            return Redirect("/Evenement/page_home");

        }
        [HttpPost]
        public ActionResult Add_gal(string titr, int titre, DateTime event_date, HttpPostedFileBase path)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            gallerie g = new gallerie();
            int last_id;
            if (db.galleries.OrderByDescending(u => u.id).FirstOrDefault() == null)
            {
                last_id = 1;
            }
            else
            {
                last_id = db.galleries.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            }
            if (titr.Equals("image"))
            {
                string url_image = Server.MapPath("~/images");
                path.SaveAs(url_image + "/gallerieImage" + last_id + ".png");
                g.path = "../../images/gallerieImage" + last_id + ".png";
            }
            else
            {
                string url_image = Server.MapPath("~/images");
                path.SaveAs(url_image + "/gallerieVideo" + last_id + ".mp4");
                g.path = "../../images/gallerieVideo" + last_id + ".mp4";
            }
            
            g.date = event_date;
            g.type = titr;
            g.id_activite = titre;

            db.galleries.Add(g);
            db.SaveChanges();

            return RedirectToAction("gallerieList");
        }
        public ActionResult gallerieList()
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            List<Activite> teachers = db.activites.ToList();
            ViewData["listgallerie"] = teachers;
            return View();
        }
        public ActionResult gallerieListImages(int id)
        {
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            Session["id_gallerie"] = id ;
            List<gallerie> teachers = db.galleries.Where(u=>u.id_activite == id).ToList();
            ViewData["listgallerie"] = teachers;
            return View();
        }
        public ActionResult delet_gallerie(int id)
        {
            
            if (Session["Admin"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Model1 db = new Model1();
            gallerie v = db.galleries.Find(id);
            db.galleries.Remove(v);
            db.SaveChanges();
            return RedirectToAction("gallerieListImages/"+ (int)Session["id_gallerie"]);

        }
        
    }
}