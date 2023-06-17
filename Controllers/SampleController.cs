using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using practiceAuthentication.Models;
using practiceAuthentication.Request;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Security.Policy;

namespace practiceAuthentication.Controllers
{
    public class SampleController : Controller
    {
        // GET: SampleController
        public readonly TransactionDContext? _context;
        public SampleController(TransactionDContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //string[] str_ouput = { "Jose", "Vargas", "Evasco" };
            //ViewBag.str_output = str_ouput;

            ViewBag.practices = await _context.Practices
                .ToListAsync();
            return View();
        }

        public IActionResult Try()
        {
            var wExp = _context
                .WorkExperiences
                .ToList();

            return Ok(wExp);
        }

        // GET: SampleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SampleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleController/Create
        [HttpPost]
        public ActionResult Create(PracticeRequest request)
        {


            if(_context.Practices.Where(p => p.Email == request.Email).Count() > 0)
            {
                TempData["error"] = "Email exist";
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
               Practice practice = new Practice()
               {
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Email = request.Email,
                    DateToday = DateTime.Now,
               };

                    _context.Practices.Add(practice);
                    _context.SaveChanges();
            }
            TempData["success"] = "Success Add";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AI()
        {
            return View();
        }


        public IActionResult Edit(int? id)
        {
            var practice = _context.Practices.Where(p => p.ID == id).FirstOrDefault();
            if(practice == null)
            {
                return NotFound();
            }
            return Ok(practice);
        }

        // POST: SampleController/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, PracticeRequest request)
        {
            var practice = _context.Practices.FirstOrDefault(p => p.ID == id);

            if (practice == null)
            {
                return NotFound();
            }

            practice.Firstname = request.Firstname;
            practice.Lastname = request.Lastname;
            practice.Email = request.Email;
            _context.SaveChanges();

            TempData["success"] = "Edit Success";
            return RedirectToAction(nameof(Index));
        }

        // GET: SampleController/Delete/5
        public ActionResult Delete(int id)
        {
            var practice = _context.Practices.FirstOrDefault(p => p.ID == id);

            if(practice == null)
            {
                return NotFound();
            }
            _context.Practices.Remove(practice);
            _context.SaveChanges();
            TempData["success"] = "Success Delete Data";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Pokemon()
        {
            return View();
        }
        public IActionResult Cat()
        {
            return View();
        }
        public IActionResult CoinDesk()
        {
            return View();
        }
        public IActionResult Gender()
        {
            return View();
        }

    }
}
