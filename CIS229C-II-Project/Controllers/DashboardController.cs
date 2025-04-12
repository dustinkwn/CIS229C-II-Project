using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS229C_II_Project.DataAccessLayer;

namespace CIS229C_II_Project.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            DataAccess data = new DataAccess();
            List<Models.DashboardModel> dashboardData = data.GetDashboardModels();
            return View(dashboardData);
        }
    }
}