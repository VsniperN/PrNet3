using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHeroCreator.Contexts;
using WebHeroCreator.Models;

namespace WebHeroCreator.Controllers
{
    public class HomeController : Controller
    {
        private readonly HeroBuilderContext _context;

        public HomeController(HeroBuilderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var heroes = _context.Heroes
                .ToList();
            return View(heroes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clans = _context.Clans.Select(c => c.Name).ToList();
            ViewBag.PowerAttributes = _context.powerAttributes.Select(pa => pa.Attribute).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HeroModel hero)
        {
            if (ModelState.IsValid)
            {
                _context.Heroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Clans = _context.Clans.Select(c => c.Name).ToList();
            ViewBag.PowerAttributes = _context.powerAttributes.Select(pa => pa.Attribute).ToList();
            return View(hero);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hero = _context.Heroes.FirstOrDefault(h => h.HeroId == id);
            if (hero == null)
            {
                return NotFound();
            }

            ViewBag.Clans = _context.Clans.Select(c => c.Name).ToList();
            ViewBag.PowerAttributes = _context.powerAttributes.Select(pa => pa.Attribute).ToList();
            return View(hero);
        }

        [HttpPost]
        public IActionResult Edit(HeroModel hero)
        {
            if (ModelState.IsValid)
            {
                _context.Heroes.Update(hero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Clans = _context.Clans.Select(c => c.Name).ToList();
            ViewBag.PowerAttributes = _context.powerAttributes.Select(pa => pa.Attribute).ToList();
            return View(hero);
        }


        public IActionResult Delete(int id)
        {
            var hero = _context.Heroes.FirstOrDefault(h => h.HeroId == id);
            if (hero == null)
                return NotFound();

            _context.Heroes.Remove(hero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
