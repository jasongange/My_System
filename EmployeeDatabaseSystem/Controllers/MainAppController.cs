﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDatabaseSystem.Controllers
{
    public class MainAppController : Controller
    {
        // GET: MainApp
        public ActionResult Index()
        {
            return View();
        }
    }
}