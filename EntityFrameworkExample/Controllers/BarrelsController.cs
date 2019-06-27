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
        private CubeService cubeService = new CubeService();

        public ActionResult Index()
        {
            BarrelAndCubeWrapper barrelsAndCubes = new BarrelAndCubeWrapper(service.GetActiveBarrels(), cubeService.GetActiveCubes());
            return View(barrelsAndCubes);
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

        public ActionResult CubeCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CubeCreate([Bind(Include = "Id,SideLength,Weight,ConstructionMaterial,Contents,CurrentLocation")] Cube cube)
        {
            cube.DateCreated = DateTime.Now;
            cube.hidden = false;
            if (ModelState.IsValid)
            {
                cubeService.AddCube(cube);
                return RedirectToAction("Index");
            }
            return View(cube);
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

        public ActionResult CubeDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = cubeService.GetCubeById((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        [HttpPost, ActionName("CubeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CubeDeleteConfirmed(int id)
        {
            Cube cube = cubeService.GetCubeById(id);
            cube.hidden = true;
            cubeService.SaveEdits(cube);
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

        public ActionResult CubeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = cubeService.GetCubeById((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CubeEdit(Cube cube)
        {
            if (ModelState.IsValid)
            {
                cubeService.SaveEdits(cube);
                return RedirectToAction("Index");
            }
            return View(cube);
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

        public ActionResult CubeDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = cubeService.GetCubeById((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            double volume = cubeService.Volume(cube);
            string duration = cubeService.Duration(cube);
            CubeWrapper wrapper = new CubeWrapper(cube, volume, duration);
            return View(wrapper);
        }

        public ActionResult Archived()
        {
            BarrelAndCubeWrapper barrelsAndCubes = new BarrelAndCubeWrapper(service.GetArchivedBarrels(), cubeService.GetArchivedCubes());
            return View(barrelsAndCubes);
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

        public ActionResult CubeUnarchive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cube cube = cubeService.GetCubeById((int)id);
            if (cube == null)
            {
                return HttpNotFound();
            }
            return View(cube);
        }

        [HttpPost, ActionName("CubeUnarchive")]
        [ValidateAntiForgeryToken]
        public ActionResult CubeArchiveConfirmed(int id)
        {
            Cube cube = cubeService.GetCubeById(id);
            cube.hidden = false;
            cubeService.SaveEdits(cube);
            return RedirectToAction("Archived");
        }

        public ActionResult InfoPage()
        {
            return View();
        }
    }
}
