using GettingStarted.Data;
using GettingStarted.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStarted.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get Section of Course
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            var course = _context.Courses.Where(x => x.CourseId == Id).FirstOrDefault();
            return View(course);
        }
        
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var course = _context.Courses.Where(x => x.CourseId == Id).FirstOrDefault();
            return View(course);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var course = _context.Courses.Where(x => x.CourseId == Id).FirstOrDefault();
            return View(course);
        }

        /// <summary>
        /// Post section of Course Model
        /// </summary>
        [HttpPost]        
        public IActionResult Create(Course model)
        {
            _context.Courses.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Course model)
        {
            _context.Courses.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Course model)
        {
            _context.Courses.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
