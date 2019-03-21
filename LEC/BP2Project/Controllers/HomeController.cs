using BP2Project.Models;
using BP2Project.Models.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace BP2Project.Controllers
{
    public class HomeController : Controller
    {
        static object locker = new object();
        public CustomPrincipal AuthUser
        {
            get
            {
                if (System.Web.HttpContext.Current.User != null)
                {
                    return System.Web.HttpContext.Current.User as CustomPrincipal;
                }
                else
                {
                    return null;
                }
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string username, string password, string email, string firstname, string lastname)
        {
            lock(locker)
            { 
                try
                {
                    TempData["regError"] = "";
                    if (username.ToLower() == "admin")
                        throw new Exception("Username cannot be admin");
                    if (!DataAccess.DbAccess.Users.ToList().Exists(x => x.Username == username))
                    {
                        DataAccess.DbAccess.Users.Add(new Models.User()
                        {
                            Username = username,
                            Password = password,
                            Email = email,
                            FirstName = firstname,
                            LastName = lastname,
                        });
                        DataAccess.DbAccess.SaveChanges();
                        CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                        serializeModel.Username = username;
                        serializeModel.Password = password;
                        serializeModel.Role = "User";
                        JavaScriptSerializer serializer = new JavaScriptSerializer();

                        string userData = serializer.Serialize(serializeModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                            username,
                            DateTime.Now,
                            DateTime.Now.AddMinutes(15),
                            false,
                            userData);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        System.Web.HttpContext.Current.Response.Cookies.Add(faCookie);
                        return RedirectToAction("Index", "User");
                    }
                    else
                        throw new Exception("Username already exists.");
                }
                catch(Exception e)
                {
                    TempData["regError"] = e.Message;
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            lock (locker)
            {
                try
                {
                    TempData["LoginError"] = "";
                    if (DataAccess.DbAccess.Users.ToList().Exists(x => x.Username == username && x.Password == password))
                    {
                        if (username == "admin")
                        {
                            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                            serializeModel.Username = username;
                            serializeModel.Password = password;
                            serializeModel.Role = "Admin";
                            JavaScriptSerializer serializer = new JavaScriptSerializer();

                            string userData = serializer.Serialize(serializeModel);
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                1,
                                username,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(15),
                                false,
                                userData);

                            string encTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            System.Web.HttpContext.Current.Response.Cookies.Add(faCookie);
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                            serializeModel.Username = username;
                            serializeModel.Password = password;
                            serializeModel.Role = "User";
                            JavaScriptSerializer serializer = new JavaScriptSerializer();

                            string userData = serializer.Serialize(serializeModel);
                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                1,
                                username,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(15),
                                false,
                                userData);

                            string encTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            System.Web.HttpContext.Current.Response.Cookies.Add(faCookie);
                            TempData["LoginError"] = "Username / password incorrect.";
                            return RedirectToAction("Index", "User");
                        }

                    }
                    else
                        throw new Exception("Username doesn't exist.");
                }
                catch (Exception e)
                {
                    TempData["LoginError"] = e.Message;
                    return View();
                }
            }
        }

        public ActionResult Schedule()
        {

            List<Schedule> schedules = DataAccess.DbAccess.Schedules.ToList();
            
            return View(schedules);
        }

        public ActionResult Standings()
        {
            try
            {
                List<Standing> standings = DataAccess.DbAccess.Standings.ToList();
                standings = standings.OrderBy(x => x.Rank).ToList();
                return View(standings);
            }
            catch(Exception e)
            {
                TempData["errorMSG"] = e.Message;
                return View("Error");
            }
        }
        public ActionResult Tickets()
        {
            return View();
        }

        public ActionResult Media()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}