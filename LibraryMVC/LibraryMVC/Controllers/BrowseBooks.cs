using LibraryMVC.Data;
using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class BrowseBooks : Controller
    {
        private ApplicationDbContext _db;

        public BrowseBooks(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var user = _db.User;
            ApplicationUsers thisUser = user.Where(query => query.Email == currentUserName).SingleOrDefault();
            var bookList = _db.Books.Where(query => query.UserId == thisUser.Id);
            IEnumerable<Books> objList = bookList;
            return View(objList);
        }
    }
}
