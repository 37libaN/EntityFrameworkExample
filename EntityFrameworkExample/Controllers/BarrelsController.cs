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
        private BarrelService service;
        public BarrelsController()
        {
            service = new BarrelService();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = service.GetStudentById((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            Barrel barrel = service.Barrel.Find(id);
            service.Barrels.Remove(barrel);
            return RedirectToAction("Index");
        }
    }
}
