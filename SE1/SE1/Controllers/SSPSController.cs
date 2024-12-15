using Microsoft.AspNetCore.Mvc;
using SE1.Data;
using SE1.Models;

namespace SE1.Controllers
{
    public class SSPSController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SSPSController(ApplicationDbContext db, IWebHostEnvironment webHost)
        {
            _db = db;
        }
        public IActionResult ShowImagesFromFolder()
        {
            //Get the Folder Path
            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
            //Get the File Path
            var imageFileNames = Directory.EnumerateFiles(imageFolder)
                                          .Select(fn => Path.GetFileName(fn));
            //Return all the Images to the View
            return View(imageFileNames);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult ViewHistory()
        {
            return View();
        }
        public IActionResult Userlist()
        {
            return View();
        }
        public IActionResult AddPrinter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPrinter(Printer2 printer2)
        {
            if (ModelState.IsValid)
            {
                _db.Printer2s.Add(printer2);
                _db.SaveChanges();
                return RedirectToAction("PrinterList");
            }
            return View();
        }
        public IActionResult PrinterList()
        {
            List<Printer2> objCategoryList = _db.Printer2s.ToList();
            
            return View(objCategoryList);
        }
        public IActionResult EditPrinter(int? id)
        {
            if (id == null || id < 0) return NotFound();

            Printer2? PrinterFromDb = _db.Printer2s.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (PrinterFromDb == null) return NotFound();

            return View(PrinterFromDb);
        }

        [HttpPost]
        public IActionResult EditPrinter(Printer2 printer)
        {
            //Printer printer = new Printer();
            if (ModelState.IsValid)
            {
                //printer.Name = input.Name;
                //printer.Location = input.Location;
                
                //if (input.Active == "active") printer.Active = true;
                //else printer.Active = false;

                _db.Printer2s.Update(printer);
                _db.SaveChanges();
                return RedirectToAction("PrinterList");
            }
            return View();
        }
        public IActionResult DeletePrinter(int? id)
        {
            if (id == null || id < 0) return NotFound();

            Printer2? PrinterFromDb = _db.Printer2s.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (PrinterFromDb == null) return NotFound();

            return View(PrinterFromDb);
        }

        [HttpPost, ActionName("DeletePrinter")]
        public IActionResult DeletePost(int? id)
        {
            Printer2? obj = _db.Printer2s.Find(id);

            if (obj == null) return NotFound();

            _db.Printer2s.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("PrinterList");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                foreach (User u in _db.Users)
                {
                    if (user.Email.ToString() == u.Email)
                    {
                        if (user.Password.ToString() == u.Password)
                        {
                            return RedirectToAction("Dashboard");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Password is incorrect!");
                            return View();
                        }
                    }
                }
                ModelState.AddModelError("Email", "User is not existed!");
                return View();

            }
            return View();
        }
    }
}
