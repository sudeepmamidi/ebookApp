using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Models;
using Microsoft.EntityFrameworkCore;
using BooksApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace BooksApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly BooksDbContext _db;

        public BookController(BooksDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.BooksTable.ToList();
            return View(displaydata);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Books nec)
        {
            if(ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(nec);
            }
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var getbookdetails = await _db.BooksTable.FindAsync(id);
                return View(getbookdetails);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Books books)
        {
            if (ModelState.IsValid)
            {
                _db.Update(books);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View(books);
            }
        }

        public async Task<ActionResult> details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var getbookdetails = await _db.BooksTable.FindAsync(id);
                return View(getbookdetails);
            }
        }

        public async Task<ActionResult> delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var getbookdetails = await _db.BooksTable.FindAsync(id);
                return View(getbookdetails);
            }
        }

        [HttpPost]
        public async Task<ActionResult> delete(int id)
        {
            
                var getbookdetails = await _db.BooksTable.FindAsync(id);
                _db.BooksTable.Remove(getbookdetails);
            await _db.SaveChangesAsync();

                return RedirectToAction("Index");
        }


    }
}
