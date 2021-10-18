using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication45.Models;

namespace WebApplication45.Controllers
{
    public class StudentController : Controller
    {

        SakshamEntities dbObj = new SakshamEntities();
        // GET: Student
        
        public ActionResult Student(tblstudent obj)
        {
                return View(obj);
          
        }

        [HttpPost]
        public ActionResult AddStudent(tblstudent model)
        {
            if (ModelState.IsValid)
            {
                tblstudent obj = new tblstudent();
                obj.Email = model.Email;
                obj.StudentId = model.StudentId;
                obj.Phone = model.Phone;
                obj.Fullname = model.Fullname;

                if(model.StudentId ==0)
                {
                    dbObj.tblstudents.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();
                }
                
            }
                ModelState.Clear();
            


            return View("Student");
        }
        public ActionResult StudentList()
        {
            var res = dbObj.tblstudents.ToList();
            return View(res);
        }
        public ActionResult Delete(int StudentId)
        {
            var res = dbObj.tblstudents.Where(x => x.StudentId == StudentId).FirstOrDefault();
            dbObj.tblstudents.Remove(res);
            dbObj.SaveChanges();

            var Lst = dbObj.tblstudents.ToList();
            return View("StudentList",Lst);
        }
       

    }
}