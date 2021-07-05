using PROJET_1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace PROJET_1.Controllers
{
    public class BDEController : Controller
    {
        Model1 db = new Model1();
        
        public ActionResult Index()
        {
            if (Session["bde_id"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string name , string password)
        { 
            var x = db.BDEs.ToList();

            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }
            foreach (var ad in x)
            {
                if (ad.email == name && ad.password == password)
                {
                    Session["name"] = name;
                    Session["bde_id"] = ad.id;
                    ViewBag.MySession = Session["name"];
                    return View("Index");
                }
            }
            ViewBag.MyMsg = "mot de pass ou l'email est pas correct";
            return View();
        }

        public ActionResult About()
        {
            if(Session["bde_id"]!= null)
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }
            return RedirectToAction("Login");

        }

        public ActionResult Contact()
        {
            if (Session["bde_id"] != null)
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
            return RedirectToAction("Login");

        }
   

        public ActionResult Events()
        {
            if(Session["bde_id"] != null)
            {
                int i = (int)Session["bde_id"];
                var x = db.activites.Where(p => p.BDE == i).ToList();
                return View(x);
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Add_event(string titre, string description , DateTime event_date, HttpPostedFileBase path)
        {
            if (Session["bde_id"] != null)
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Activite v = new Activite();
                        //image
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

                        v.titre = titre;
                        v.description = description;
                        v.state = "disable";
                        v.date = event_date;
                        v.BDE = (int)Session["bde_id"];
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
                        return RedirectToAction("Events");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.", ex);
                    }
                }
            }

            return RedirectToAction("Login");
        }

    
        
        public ActionResult add_event_page()
        {
            if (Session["bde_id"] != null)
            {
                return View();
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["name"] == null)
            {
                return Redirect("/Evenement/page_home");
            }
            Session["name"] = null;
            return Redirect("/Evenement/page_home");

        }
    }
}