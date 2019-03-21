using BP2Project.Models;
using BP2Project.Models.Security;
using BP2Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BP2Project.Controllers
{
    public class AdminController : Controller
    {
        static object locker = new object();
        // GET: Admin
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
        [Authorize]
        public ActionResult Index()
        {
            if (AuthUser == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [Authorize]
        public ActionResult Tickets()
        {
            TicketViewModel ticketView = new TicketViewModel();
            foreach (var mtch in DataAccess.DbAccess.Matches.ToList())
            {
                ticketView.matches.Add(string.Format("{0}: {1}", mtch.MatchID, mtch.MatchName));
            }
            return View(ticketView);
        }

        [HttpPost]
        public ActionResult Tickets(string match, int row, int seat, int price)
        {
            try
            {
                string matchName = match.Split(':')[1].Trim();
                int result = DataAccess.DbAccess.Database.SqlQuery<int>(string.Format("SELECT [dbo].[FreeSeatFunction]({0},{1},'{2}')", row, seat, matchName)).FirstOrDefault();
                if (result == 0)
                {
                    Ticket t = new Ticket() { Seat = seat, Row = row, Price = price, MatchName = matchName, Location = "Berlin" };
                    User u = DataAccess.DbAccess.Users.ToList().Find(x => x.Username == AuthUser.Username && x.Password == AuthUser.Password);
                    Match m = DataAccess.DbAccess.Matches.ToList().Find(x => x.MatchName == matchName);
                    MatchTicket mt = new MatchTicket()
                    {
                        Match = m,
                        User = u,
                        Ticket = t,
                        TicketID = t.TicketID,
                        MatchID = m.MatchID,
                        UserID = u.UserID,
                        MatchTicketID = DataAccess.DbAccess.MatchTickets.ToList().Count + 1
                    };
                    DataAccess.DbAccess.MatchTickets.Add(mt);
                    DataAccess.DbAccess.SaveChanges();
                }
                else
                {
                    TicketViewModel ticketView = new TicketViewModel();
                    foreach (var mtch in DataAccess.DbAccess.Matches.ToList())
                    {
                        ticketView.matches.Add(string.Format("{0}: {1}", mtch.MatchID, mtch.MatchName));
                    }
                    ticketView.errorMSG = "Row / Seat already taken.";
                    return View(ticketView);
                }
                return RedirectToAction("UserProfile", "Admin");
            }
            catch
            {
                TicketViewModel ticketView = new TicketViewModel();
                foreach (var mtch in DataAccess.DbAccess.Matches.ToList())
                {
                    ticketView.matches.Add(string.Format("{0}: {1}", mtch.MatchID, mtch.MatchName));
                }
                ticketView.errorMSG = "Unknown error occured.";
                return View(ticketView);
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            lock (locker)
            {
                string[] myCookies = Request.Cookies.AllKeys;
                foreach (string cookie in myCookies)
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult Schedule()
        {
            List<Schedule> schedules = DataAccess.DbAccess.Schedules.ToList();

            return View(schedules);
        }
        [Authorize]
        public ActionResult Standings()
        {
            try
            {
                List<Standing> standings = DataAccess.DbAccess.Standings.ToList();
                standings = standings.OrderBy(x => x.Rank).ToList();
                return View(standings);
            }
            catch (Exception e)
            {
                TempData["errorMSG"] = e.Message;
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult UserProfile()
        {
            User user = DataAccess.DbAccess.Users.ToList().Find(x => x.Username == AuthUser.Username && x.Password == AuthUser.Password);
            UserViewModel uvm = new UserViewModel();
            uvm.user = user;
            if (user != null)
                return View(uvm);
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public ActionResult UserProfile(string username, string password, string email, string firstname, string lastname)
        {
            lock (locker)
            {
                try
                {
                    User u = DataAccess.DbAccess.Users.ToList().Find(x => x.Username == AuthUser.Username);

                    UserViewModel uvm = new UserViewModel();
                    uvm.user = u;
                    if (username == u.Username)
                    {
                        u.Username = username;
                        u.Password = password;
                        u.FirstName = firstname;
                        u.LastName = lastname;
                        u.Email = email;
                        DataAccess.DbAccess.SaveChanges();
                        DataAccess.RefreshDB();
                        return View(uvm);
                    }
                    else
                    {
                        if (!DataAccess.DbAccess.Users.ToList().Exists(x => x.Username == username))
                        {
                            u.Username = username;
                            u.Password = password;
                            u.FirstName = firstname;
                            u.LastName = lastname;
                            u.Email = email;
                            DataAccess.DbAccess.SaveChanges();
                            DataAccess.RefreshDB();
                            return View(uvm);
                        }
                        else
                        {
                            uvm.errorMSG = "Username taken.";
                        }
                        return View(uvm);
                    }
                }
                catch
                {
                    UserViewModel uvm = new UserViewModel();
                    uvm.user = DataAccess.DbAccess.Users.ToList().Find(x => x.Username == AuthUser.Username);
                    uvm.errorMSG = "Unknown error occured";
                    return View(uvm);
                }
            }
        }

        public ActionResult ChangeStandings()
        {
            StandingsViewModel svm = new StandingsViewModel();
            foreach (var node in DataAccess.DbAccess.Teams.ToList())
            {
                svm.teams.Add(node.TeamName);
            }
            svm.errorMSG = "";
            return View(svm);
        }

        [HttpPost]
        public ActionResult ChangeStandings(string team, int wins, int loses)
        {
            lock(locker)
            {
                try
                {
                    Team t = DataAccess.DbAccess.Standings.ToList().Find(x => x.Team.TeamName == team).Team;
                    //t.Standing.Wins = wins;
                    //t.Standing.Loses = loses;
                    DataAccess.DbAccess.UpdateStandings(t.TeamID, wins, loses);
                    DataAccess.DbAccess.SaveChanges();
                    DataAccess.RefreshDB();
                    return RedirectToAction("Standings", "Admin");
                }
                catch
                {
                    StandingsViewModel svm = new StandingsViewModel();
                    foreach(var node in DataAccess.DbAccess.Teams.ToList())
                    {
                        svm.teams.Add(node.TeamName);
                    }
                    svm.errorMSG = "Unknown error occured";
                    return View(svm);
                }
            }
        }
    }
}