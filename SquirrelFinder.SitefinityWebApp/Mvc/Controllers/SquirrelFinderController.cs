using SquirrelFinder.Acorn.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquirrelFinder.Acorn.Mvc.Controllers
{
    public class SquirrelFinderController : Controller
    {
        public ActionResult Index()
        {
            var model = new SquirrelFinderModel();
            model.LogEntries = SquirrelFinder.Acorn.SquirrelFinderTraceListener.LogEntries;
            return View("SquirrelData", model);
        }
    }
}