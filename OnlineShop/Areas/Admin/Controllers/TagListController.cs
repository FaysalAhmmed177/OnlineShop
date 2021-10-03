using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagListController : Controller
    {
        public readonly ApplicationDbContext _db;
        public TagListController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.TagList.ToList());
        }

        //Get Create Action method
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagList tagList)
        {
            if (ModelState.IsValid)
            {
                _db.TagList.Add(tagList);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagList);
        }

        //Get Edit Action method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagList = _db.TagList.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            return View(tagList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TagList tagList)
        {
            if (ModelState.IsValid)
            {
                _db.TagList.Update(tagList);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagList);
        }

        // Get Details action method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var taglist = _db.TagList.Find(id);
            if (taglist == null)
            {
                return NotFound();
            }
            return View(taglist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(TagList tagList)
        {
            //if (ModelState.IsValid)
            //{
            //    _db.Update(productTypes);
            //    await _db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return RedirectToAction(nameof(Index));
        }
        //Get Delete Action
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tagList = _db.TagList.Find(id);
            if (tagList == null)
            {
                return NotFound();
            }
            return View(tagList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TagList tagList)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != tagList.Id)
            {
                return NotFound();
            }
            var taglist = _db.TagList.Find(id);
            if (taglist == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Remove(taglist);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taglist);
        }
    }
}
