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
            return View(service.GetActiveBarrels());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Radius,Height,Weight,ConstructionMaterial,Contents,CurrentLocation")] Barrel barrel)
        {
            barrel.DateCreated = DateTime.Now;
            barrel.hidden = false;
            if (ModelState.IsValid)
            {
                service.AddBarrel(barrel);
                return RedirectToAction("Index");
            }
            return View(barrel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barrel barrel = service.GetBarrelById(id);
            barrel.hidden = true;
            service.SaveEdits(barrel);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Barrel barrel)
        {
            if (ModelState.IsValid)
            {
                service.SaveEdits(barrel);
                return RedirectToAction("Index");
            }
            return View(barrel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            double volume = service.Volume(barrel);
            string duration = service.Duration(barrel);
            BarrelWrapper wrapper = new BarrelWrapper(barrel, volume, duration);
            return View(wrapper);
        }
        public ActionResult Archived()
        {
            return View(service.GetArchivedBarrels());
        }

        public ActionResult Unarchive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrel barrel = service.GetBarrelById((int)id);
            if (barrel == null)
            {
                return HttpNotFound();
            }
            return View(barrel);
        }

        [HttpPost, ActionName("Unarchive")]
        [ValidateAntiForgeryToken]
        public ActionResult ArchiveConfirmed(int id)
        {
            Barrel barrel = service.GetBarrelById(id);
            barrel.hidden = false;
            service.SaveEdits(barrel);
            return RedirectToAction("Archived");
        }

        public ActionResult InfoPage()
        {
            return View();
        }
    }
}
