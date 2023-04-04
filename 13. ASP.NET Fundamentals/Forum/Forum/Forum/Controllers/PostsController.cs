using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum.Data;
using Forum.Data.Models;
using Forum.Models;
using Forum.Services;

namespace Forum.Controllers
{
    public class PostsController : Controller
    {
        private PostService postService;

        public PostsController(PostService _postService)
        {
            postService = _postService;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
              return View(await postService.AllAsync());
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        public async Task<IActionResult> Create(PostDto post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            await postService.Add(post);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            
            return View(await postService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostDto post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            try
            {
                await postService.Edit(post);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }


            return View(await postService.GetById((int)id));
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PostDto post)
        {
            try
            {
                await postService.Delete(post);

            }
            catch (Exception)
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
