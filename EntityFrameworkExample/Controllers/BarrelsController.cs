using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using EntityFrameworkExample.Service;

namespace EntityFrameworkExample.Controllers
{
    public class BarrelsController : Controller
    {
        private BarrelService service = new BarrelService();

        public ActionResult Index()
        {
            return View(service.GetAllBarrels());
        }

        public ActionResult Create()
        {
            return View();
        }
      

       
    }
}
