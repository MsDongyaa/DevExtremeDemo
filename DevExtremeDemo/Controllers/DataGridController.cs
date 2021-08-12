using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtremeDemo.Controllers
{
    public class DataGridController : Controller
    {
        // GET: DataGridController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CRUDOperations()
        {
            return View();
        }
    }
}
