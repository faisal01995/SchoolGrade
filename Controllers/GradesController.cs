using SchoolGrade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolGrade.Controllers
{

    public class GradesController : Controller
    {
        private DB _db;

        // GET: Grades
        public GradesController()
        {
            _db = new DB();


        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        public ActionResult Index()
        {
            var grade = _db.Grades.Where(g => g.isActive == true).ToList();
            return View(grade);
        }
        public ActionResult AddEditGrade(int id)
        {
            Grades grade = new Grades();
            if (id > 0)
            {
                grade = _db.Grades.SingleOrDefault(g => g.GradeId == id);

            }
            else
            {
                grade = _db.Grades.Add(grade);
            }

            return PartialView("AddEdit", grade);
        }
        [HttpPost]
        public ActionResult AddEditGrade(Grades grades)
        {

            if (grades.GradeId > 0)
            {
                Grades gradedb = _db.Grades.SingleOrDefault(g => g.GradeId == grades.GradeId);
                gradedb.Gradename = grades.Gradename;
                gradedb.isActive = grades.isActive;
            }
            else
            {
                _db.Grades.Add(grades);
            }
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult DelGrade(int id)
        {
            Grades grade = _db.Grades.SingleOrDefault(g => g.GradeId == id);

            return PartialView("DelGrade", grade);
        }
        [HttpPost]
        public ActionResult DelGrade(Grades grade)
        {
            Grades gradeDb = _db.Grades.SingleOrDefault(g => g.GradeId == grade.GradeId);
            gradeDb.isActive = false;

            _db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}