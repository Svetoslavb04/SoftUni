using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeisterMask.Data;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new TeisterTaskDbContext())
            {
                var alltasks = db.Tasks.ToList();
                return View(alltasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status))
            {
                return RedirectToAction("Index");
            }
            Task task = new Task
            {
                Title = title,
                Status = status
            };
            using (var db = new TeisterTaskDbContext())
            {
                db.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterTaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }

        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new TeisterTaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(f => f.Id == task.Id);
                taskToEdit.Title = task.Title;
                taskToEdit.Status = task.Status;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterTaskDbContext())
            {
                Task bookToDelete = db.Tasks.FirstOrDefault(b => b.Id == id);
                if (bookToDelete == null)
                {
                    RedirectToAction("Index");
                }
                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            using (var db = new TeisterTaskDbContext())
            {
                Task taskToDelete = db.Tasks.Find(task.Id);
                if (taskToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Tasks.Remove(taskToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}