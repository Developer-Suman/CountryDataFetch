using CountryDataFetch.Data;
using CountryDataFetch.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CountryDataFetch.Controllers
{
    public class CountryController1 : Controller
    {
        private AppDbContext _context;

        public CountryController1(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Country> countries = _context.countries;
            return View(countries);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //This is used to prevent cross sql attck
        public IActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.countries.Add(country);
                _context.SaveChanges();
                TempData["success"] = "Created Data Suceesfully";
                return RedirectToAction("Index");
            }
            return View(country);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var country = _context.countries.Find(id);
            if(country == null)
            {
                return NotFound();
            }
            
            return View(country);
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _context.countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //This is used to prevent cross sql attck
        public IActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                _context.countries.Update(country);
                _context.SaveChanges();
                TempData["success"] = "Updated Data Suceesfully";
                return RedirectToAction("Index");
            }
            return View(country);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var country = _context.countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //This is used to prevent cross sql attck
        public IActionResult DeleteData(int? id)
        {
            var country = _context.countries.Find(id);
            if(country == null)
            {
                return NotFound();
            }
            _context.countries.Remove(country);
            _context.SaveChanges();
            TempData["success"] = "Deleted Data Suceesfully";
            return RedirectToAction("Index");
        }



    }
}
