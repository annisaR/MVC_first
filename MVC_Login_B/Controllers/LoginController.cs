using MVC_Login_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_Login_B.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext Mycontext = new ApplicationDbContext();

        // GET: Login
        public ActionResult Index()
        {
            var Index = Mycontext.Login.ToList();
            return View(Index);
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            var Detail = Mycontext.Login.ToList();
            return View(Detail);
        }
        //Get 
        public ActionResult masuk()
        {

            return View();
        }
        //Get 
        public ActionResult dashboard()
        {

            return View();
        }
        //get 
        public ActionResult regristrasi()
        {
            var list = Mycontext.Login.ToList();
            return View(list);

        }
     
        [HttpPost]
        public ActionResult masuk(ClassLogin login) // yang ijomuda itu nama clas 
        {
            var currentAccount = Mycontext.Login.FirstOrDefault(dta => dta.Email == login.Email);
            if(currentAccount != null)
            {
                var password = BCrypt.Net.BCrypt.Verify(login.Password, currentAccount.Password);
                if (password == true) 
                {
                    Session["id"] = login.id;
                    Session.Add("email", login.Email);
                    //retun view ("WELCOME")
                    return RedirectToAction("dashboard", "login");
                }
               
                
            }
            ViewBag.error = "Invalid";
            return View("Index");
        }
        // POST: Login/Create
        [HttpPost]
        public ActionResult regristrasi(ClassLogin login)
        {
            login.Password= BCrypt.Net.BCrypt.HashPassword(login.Password);
            Mycontext.Login.Add(login);
            Mycontext.SaveChanges();
            MailMessage sub = new MailMessage("annisarahma15@gmail.com", login.Email);
            sub.Subject = "[Password]" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            sub.Body = " hallo" + login.Email + "\nThis Is Your New Password: " + login.Password;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("annisarahma.xiirpl20@gmail.com", "annisarahmasaptia15091997");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(sub);
            ViewBag.Message = "Password Has Been Sent.Check your email to login";
            return RedirectToAction("Index", "login");
        }
       

        // GET: Login/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(ClassLogin login) // yang ijomuda itu nama clas 
        {
            try
            {
                // TODO: Add insert logic here
                var mySalt =BCrypt.Net.BCrypt.GenerateSalt();
                login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password,mySalt);
                Mycontext.Login.Add(login);
                Mycontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       


        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
