namespace Forum.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class TopicController : Controller
    {
        private readonly ForumDbContext context;
        public TopicController(ForumDbContext db)
        {
            this.context = db;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var topicToView = context
                .Topics
                .Include(t => t.Author)
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (topicToView == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(topicToView);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Topic topic)
        {
            if (ModelState.IsValid)
            {
                topic.CreatedDate = DateTime.Now;
                topic.LastUpdatedDate = DateTime.Now;

                var userId = context
                    .Users
                    .Where(u => u.UserName == User.Identity.Name)
                    .FirstOrDefault()
                    .Id;

                topic.AuthorId = userId;

                this.context.Topics.Add(topic);
                this.context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(topic);
        }
    }
}