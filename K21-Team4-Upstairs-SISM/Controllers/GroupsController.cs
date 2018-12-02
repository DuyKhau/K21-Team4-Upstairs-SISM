using K21_Team4_Upstairs_SISM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace K21_Team4_Upstairs_SISM.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (StudentEntities db = new StudentEntities())
            {
                List<Group> grList = db.Groups.ToList<Group>();
                return Json(new { data = grList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Group());
            else
            {
                using (StudentEntities db = new StudentEntities())
                {
                    return View(db.Groups.Where(x => x.ID == id).FirstOrDefault<Group>());
                }
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(Group gr)
        {
            using (StudentEntities db = new StudentEntities())
            {
                if (gr.ID == 0)
                {
                    db.Groups.Add(gr);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(gr).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (StudentEntities db = new StudentEntities())
            {
                Group gr = db.Groups.Where(x => x.ID == id).FirstOrDefault<Group>();
                db.Groups.Remove(gr);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupName,Privacy,Description,Session,Faculty,Creator")] Group group)
        {
           using(StudentEntities db = new StudentEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Groups.Add(group);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(group);
            }
        }
    }
}