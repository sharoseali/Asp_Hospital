using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patient_Doctor_Application.Models;

namespace Patient_Doctor_Application.Controllers
{
    public class AppointmentsController : Controller
    {
        private Patient_Doctor_ApplicationContext db = new Patient_Doctor_ApplicationContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.DoctorObj).Include(a => a.PatientObj);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.DoctorID = new SelectList(db.Doctors, "ID", "firstName");
            ViewBag.PatientID = new SelectList(db.Patients, "ID", "firstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DoctorID,PatientID,AppointmentDate,AppointmentTime")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorID = new SelectList(db.Doctors, "ID", "firstName", appointments.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "ID", "firstName", appointments.PatientID);
            return View(appointments);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "ID", "firstName", appointments.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "ID", "firstName", appointments.PatientID);
            return View(appointments);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DoctorID,PatientID,AppointmentDate,AppointmentTime")] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorID = new SelectList(db.Doctors, "ID", "firstName", appointments.DoctorID);
            ViewBag.PatientID = new SelectList(db.Patients, "ID", "firstName", appointments.PatientID);
            return View(appointments);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return HttpNotFound();
            }
            return View(appointments);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointments appointments = db.Appointments.Find(id);
            db.Appointments.Remove(appointments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
