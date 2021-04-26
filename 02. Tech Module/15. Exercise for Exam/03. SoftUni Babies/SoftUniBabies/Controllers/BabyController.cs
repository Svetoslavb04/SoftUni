namespace SoftUniBabies.Controllers
{
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class BabyController : Controller
    {
        private readonly BabyDbContext context;

        public BabyController(BabyDbContext dbContext)
        {
            this.context = dbContext;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var allBabies = context.Babies.ToList();
            return View(allBabies);
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(Baby baby)
        {
            if (baby.Id == null || baby.Name == null || baby.Gender == null || baby.Birthday == null) 
            {
                return RedirectToAction("Index");
            }
            var BabyToCreate = new Baby
            {
                Id = baby.Id,
                Name = baby.Name,
                Gender = baby.Gender,
                Birthday = baby.Birthday
            };
            context.Babies.Add(BabyToCreate);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var CatToEdit = context.Babies.Find(id);
            if (CatToEdit == null)
            {
                return RedirectToAction("Index");
            }
            return View(CatToEdit);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(Baby baby)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var CatToEdit = context.Babies.Find(baby.Id);
            CatToEdit.Id = baby.Id;
            CatToEdit.Name = baby.Name;
            CatToEdit.Gender = baby.Gender;
            CatToEdit.Birthday = baby.Birthday;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var CatToEdit = context.Babies.Find(id);
            if (CatToEdit == null)
            {
                return RedirectToAction("Index");
            }
            return View(CatToEdit);
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public IActionResult Delete(Baby baby)
        {
            var CatToDelete = new Baby
            {
                Id = baby.Id,
                Name = baby.Name,
                Gender = baby.Gender,
                Birthday = baby.Birthday
            };
            context.Babies.Remove(CatToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
