using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using TP1_Module06.Data;
using TP1_Module06.Models;

namespace TP1_Module06.Controllers
{
    public class SamouraisController : Controller
    {
        private TP1_Module06Context db = new TP1_Module06Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.Include(a => a.Arme).Include(a => a.ArtMartials).ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Include(s => s.ArtMartials).FirstOrDefault(s => s.Id == id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraisViewModel vm = new SamouraisViewModel
            {
                Armes = db.Armes.Where(a => !db.Samourais.Select(s => s.Arme).Contains(a)).Select(a => new SelectListItem() { Text = a.Nom + " " + a.Degats, Value = a.Id.ToString() }).ToList(),
                ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList()
            };
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraisViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Samourai s = vm.Samourai;
                s.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.IdArme);
                s.ArtMartials = db.ArtMartials.Where(a => vm.IdArtMartials.Contains(a.Id)).ToList();
                db.Samourais.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.Armes = getArmesSelectListItems(vm.Samourai.Id);
            vm.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Include(s => s.ArtMartials).FirstOrDefault(s => s.Id == id);
            if (samourai == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> ArmesListItems = getArmesSelectListItems(samourai.Id);
            SamouraisViewModel vm = new SamouraisViewModel
            {
                Samourai = samourai,
                Armes = ArmesListItems,
                ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList()
            };

            if (samourai.Arme != null)
            {
                vm.IdArme = samourai.Arme.Id;
            }
            if (samourai.ArtMartials != null && samourai.ArtMartials.Count() > 0)
            {
                vm.IdArtMartials = samourai.ArtMartials.Select(a => a.Id).ToList();
            }

            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraisViewModel vm)
        {
            Samourai samourai = db.Samourais.Include(s => s.Arme).Include(s => s.ArtMartials).SingleOrDefault(s => s.Id == vm.Samourai.Id);
            if (ModelState.IsValid)
            {

                samourai.Force = vm.Samourai.Force;
                samourai.Nom = vm.Samourai.Nom;
                samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.IdArme);
                samourai.ArtMartials = db.ArtMartials.Where(a => vm.IdArtMartials.Contains(a.Id)).ToList();
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            vm.Armes = getArmesSelectListItems(samourai.Id);
            vm.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();

            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private List<SelectListItem> getArmesSelectListItems(int? samouraiId)
        {
            return db.Armes.Where(a => !db.Samourais.Where(s => s.Id != samouraiId).Select(s => s.Arme).Contains(a)).Select(a => new SelectListItem() { Text = a.Nom + " " + a.Degats, Value = a.Id.ToString() }).ToList();
        }
    }
}
