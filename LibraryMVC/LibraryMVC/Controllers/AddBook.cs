using LibraryMVC.Data;
using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Controllers
{
    public class AddBook : Controller
    {

        private readonly ApplicationDbContext _db;
        public AddBook(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(Books book)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.Name;
                var user = _db.User;
                ApplicationUsers thisUser = user.Where(query => query.Email == currentUserName).SingleOrDefault();
                book.UserId = thisUser.Id;
                _db.Books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index", "BrowseBooks");
            }
            else
            {
                return View();
            }
        }
    }
}
