using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public List<Message> Messages { get; set; }
        public ChatController()
        {
            Messages = new List<Message>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Messages);
        }

        [HttpPost]
        public IActionResult Index(Message message)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Invalid Message";

                return View(Messages);
            }
               
            Messages.Add(message);

            return View(Messages);
        }
    }
}
