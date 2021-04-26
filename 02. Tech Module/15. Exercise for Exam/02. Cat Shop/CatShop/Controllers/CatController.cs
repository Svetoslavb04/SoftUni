namespace CatShop.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CatShop.Models;
    using System.Linq;
    using CatShop.Data;

    public class CatController : Controller
    {
        private readonly CatDbContext context;

        public CatController(CatDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            var allCats = context.Cats.ToList();
            return View(allCats);
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create(Cat cat)
        {
            if (cat.Id == null || cat.Name == null || cat.Nickname == null || cat.Price == null)
            {
                return RedirectToAction("Index");
            }
            var Cat = new Cat
            {
                Id = cat.Id,
                Name = cat.Name,
                Nickname = cat.Nickname,
                Price = cat.Price
            };
            context.Cats.Add(Cat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var CatToEdit = context.Cats.Find(id);
            if (CatToEdit == null)
            {
                return RedirectToAction("Index");
            }
            return View(CatToEdit);
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int id, Cat catModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var CatToEdit = context.Cats.Find(catModel.Id);
            CatToEdit.Id = catModel.Id;
            CatToEdit.Name = catModel.Name;
            CatToEdit.Nickname = catModel.Nickname;
            CatToEdit.Price = catModel.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var CatToDelete = context.Cats.Find(id);
            if (CatToDelete == null)
            {
                return RedirectToAction("Index");
            }
            return View(CatToDelete);
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id, Cat catModel)
        {
            var CatToDelete = new Cat
            {
                Id = catModel.Id,
                Name = catModel.Name,
                Nickname = catModel.Nickname,
                Price = catModel.Price
            };

            context.Remove(CatToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
