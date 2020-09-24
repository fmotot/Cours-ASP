using BO.Utils;
using BO;
using System.Linq;
using System.Web.Mvc;
using TP2_Module05.Models;

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
            //Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id);

            if (pizzaVM.Pizza != null)
            {
                return View(pizzaVM);
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
            vm.Pates = FakeDb.Instance.Pates.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM vm)
        {
            try
            {

                if (ModelState.IsValid) // && ValidateVM(vm))
                {
                    vm.Pizza.Pate = FakeDb.Instance.Pates.FirstOrDefault(p => p.Id == vm.IdPate);
                    vm.Pizza.Ingredients = FakeDb.Instance.Ingredients.Where(i => vm.IdIngredients.Contains(i.Id)).ToList();
                    vm.Pizza.Id = FakeDb.Instance.Pizzas.Count == 0 ? 1 : FakeDb.Instance.Pizzas.Max(x => x.Id) + 1;

                    FakeDb.Instance.Pizzas.Add(vm.Pizza);
                    this.HttpContext.Response.StatusCode = 201;
                }
                else
                {
                    vm.Pates = FakeDb.Instance.Pates.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
                    vm.Ingredients = FakeDb.Instance.Ingredients.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
                    
                    this.HttpContext.Response.StatusCode = 418;
                    return View(vm);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaVM vm = new PizzaVM() { Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id) };
            vm.Pates = FakeDb.Instance.Pates.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
            vm.Ingredients = FakeDb.Instance.Ingredients.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PizzaVM vm)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid) // && ValidateVM(vm))
                {
                    Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                    pizza.Pate = FakeDb.Instance.Pates.FirstOrDefault(p => p.Id == vm.IdPate);
                    pizza.Ingredients = FakeDb.Instance.Ingredients.Where(i => vm.IdIngredients.Contains(i.Id)).ToList();
                    pizza.Nom = vm.Pizza.Nom;
                }
                else
                {
                    vm.Pates = FakeDb.Instance.Pates.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
                    vm.Ingredients = FakeDb.Instance.Ingredients.Select(p => new SelectListItem { Text = p.Nom, Value = p.Id.ToString() }).ToList();
                    return View(vm);
                }

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
            PizzaVM vm = new PizzaVM() { Pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id) };
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Pizza pizza = FakeDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                FakeDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool IngredientsValidator(PizzaVM vm)
        {
            var idIngredients = vm.IdIngredients;
            bool isValid = true;

            // pour chaque pizza
            foreach (var item in FakeDb.Instance.Pizzas)
            {
                // tester si le contenu de liste des ingrédients est strictement égale
                if (idIngredients.SequenceEqual(item.Ingredients.Select(x => x.Id)))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
    }
}
