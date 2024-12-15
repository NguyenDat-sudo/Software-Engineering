using Microsoft.AspNetCore.Mvc;
using SE1.Models;
using SE1.Models.dto;
using SE1.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SE1.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;
        public StudentController(ApplicationDbContext db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
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
        public IActionResult Dashboard()
        {
            List<Request> request = _db.Requests.ToList();
            request.Reverse();
            return View(request);
        }

        public IActionResult Setting_ChangeMoney()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Setting_ChangeMoney(int amount)
        {

            return View();
        }

        public IActionResult Setting_ChangePassword()
        {
            return View();
        }

        public IActionResult Setting_Profile()
        {
            return View();
        }

        public IActionResult ViewHistory3()
        {
            return View();
        }

        public IActionResult ViewHistory2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewHistory2([FromForm] ViewHistoryDTO dto)
        {
            return View();
        }

        public IActionResult ViewHistory1()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }
        public IActionResult Print7()
        {
            return View();
        }
        public IActionResult Print6()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Print5()
        {
            return View();
        }
        public IActionResult Print4(Print3DTO dto)
        {
            Console.WriteLine(dto.ToString());
            
            return View();
        }

        [HttpPost]
        public IActionResult Print4()
        {
            Request request = new Request();
            request.Date = DateTime.Now;
            request.Document_name = TempData["fileNameToDB"].ToString();
            request.Paper = 20;
            request.Deliver_date = DateTime.Now;

            _db.Requests.Add(request);
            _db.SaveChanges();

            return RedirectToAction("Print7");
        }

        [HttpGet]
        public IActionResult Print3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Print3(print3 input)
        {
            TempData["date"] = DateTime.Now.ToString();
            TempData["pageRange"] = input.pageRange;
            TempData["pageRangeToDB"] = input.pageRange;
            TempData["type"] = input.numberOfCopies + " copies/ " + input.orientation + "/ " +
                input.paperSize + "/ " + input.printedSides + "/ " + input.color;

            return RedirectToAction("Print4");
        }

        [HttpGet]
        public IActionResult Print2()
        {
            PrinterInput input = new PrinterInput();
            input.printer = "printer";
            input.Printers = _db.Printer2s.Select(x => new SelectListItem { Value = x.Name, Text = x.Name }).ToList();

            return View(input);
        }

        [HttpPost]
        public IActionResult Print2(PrinterInput input)
        {
            //string _printer = "HP Color LaserJet Pro";
            //if (input.printer == "1") _printer = "HP Color LaserJet Pro";
            //if (input.printer == "2") _printer = "rother MFC - J23188WCB";
            //if (input.printer == "3") _printer = "HP DeskJet 2440";

            TempData["printer"] = input.printer;
            return RedirectToAction("Print3");
        }

        public IActionResult Print()
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
                        if(user.Password.ToString() == u.Password)
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

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string UploadFolder = Path.Combine(_webHost.WebRootPath, "uploads");

            if (!Directory.Exists(UploadFolder))
            {
                Directory.CreateDirectory(UploadFolder);
            }

            string fileName = Path.GetFileName(file.FileName);
            string fileSavePath = Path.Combine(UploadFolder, fileName);
            
            string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"550px\" height=\"550px\">";
            embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "</object>";

            TempData["fileName"] = fileName;
            TempData["fileNameToDB"] = fileName;
            TempData["file"] = string.Format(embed, "/Documents/" + fileName);

            using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            ViewBag.Message = fileName + " Upload successfully";

            return RedirectToAction("Print2");
        }
    }
}
