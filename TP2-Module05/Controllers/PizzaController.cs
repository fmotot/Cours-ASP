using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2_Module05.Models;
using TP2_Module05.Utils;

namespace TP2_Module05.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaVM pizzaVM = new PizzaVM() { Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id) };

            if (pizzaVM.Pizza != null)
            {
            return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM vm = new PizzaVM();
            vm.Pates = FakeDb.Instance.Pates;
            vm.Ingredients = FakeDb.Instance.Ingredients;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            try
            {
                // TODO: Add insert logic here
                vm.Pizza.Pate = FakeDb.Instance.Pates.FirstOrDefault(p => p.Id == vm.IdPate);
                vm.Pizza.Ingredients = FakeDb.Instance.Ingredients.Where(i => vm.IdIngredients.Contains(i.Id)).ToList();

                FakeDb.Instance.Pizzas.Add(vm.Pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
