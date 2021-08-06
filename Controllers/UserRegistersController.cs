using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Courses.Models;
using Courses.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Courses.Controllers
{
    public class UserRegistersController : Controller
    {
        private readonly AppDBContext _context;

        public UserRegistersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: UserRegisters
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserRegisters.ToListAsync());
        }

        // GET: UserRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegister == null)
            {
                return NotFound();
            }

            return View(userRegister);
        }

        // GET: UserRegisters/Create
        public IActionResult Create()
        {
            List<SelectListItem> studyTypeList = (from product in _context.StudyLevels
                                                 select new SelectListItem()
                                                 {
                                                     Text = product.Name,
                                                     Value = product.Id.ToString(),
                                                 }).ToList();

            List<SelectListItem> courseTypeList = (from product in _context.CourseTypes
                                                  select new SelectListItem()
                                                  {
                                                      Text = product.Name,
                                                      Value = product.Id.ToString(),
                                                  }).ToList();

            studyTypeList.Insert(0, new SelectListItem()
            {
                Text = "----Seleccione una opción----",
                Value = string.Empty
            });

            courseTypeList.Insert(0, new SelectListItem()
            {
                Text = "----Seleccione una opción----",
                Value = string.Empty
            });

            ViewBag.StudyTypeList = studyTypeList;
            ViewBag.CourseTypeList = courseTypeList;

            return View();
        }

        // POST: UserRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,BirthDate,ProfileImage,Active,StudyLevel,CourseType,ImageFile")] UserRegister userRegister)
        {
            userRegister.StudyLevel = _context.StudyLevels.Find(userRegister.StudyLevel.Id);
            userRegister.CourseType = _context.CourseTypes.Find(userRegister.CourseType.Id);
            ModelState.Remove("StudyLevel.Name");
            ModelState.Remove("CourseType.Name");
            using (var memoryStream = new MemoryStream())
            {
                await userRegister.ImageFile.CopyToAsync(memoryStream);
                userRegister.ProfileImage = memoryStream.ToArray();
            };

            if (ModelState.IsValid)
            {
                _context.Add(userRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(userRegister);
        }

        // GET: UserRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegisters.FindAsync(id);
            if (userRegister == null)
            {
                return NotFound();
            }
            return View(userRegister);
        }

        // POST: UserRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,BirthDate,ProfileImage,Active")] UserRegister userRegister)
        {
            if (id != userRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegisterExists(userRegister.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userRegister);
        }

        // GET: UserRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userRegister = await _context.UserRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userRegister == null)
            {
                return NotFound();
            }

            return View(userRegister);
        }

        // POST: UserRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userRegister = await _context.UserRegisters.FindAsync(id);
            _context.UserRegisters.Remove(userRegister);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegisterExists(int id)
        {
            return _context.UserRegisters.Any(e => e.Id == id);
        }
    }
}
