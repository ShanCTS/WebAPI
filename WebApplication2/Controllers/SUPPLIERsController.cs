using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SUPPLIERsController : Controller
    {
        

        // GET: SUPPLIERs
        public ActionResult Index()
        {
            SupplierClient sc = new SupplierClient();
            return View(sc.findAll());
        }

        // GET: SUPPLIERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            SupplierClient sc = new SupplierClient();
            return View(sc.find(id));
        }

        // GET: SUPPLIERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUPPLIERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SUPLNO,SUPLNAME,SUPLADDR")] SupplierModel sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                //db.SUPPLIERs.Add(sUPPLIER);
                //db.SaveChanges();
                SupplierClient sc = new SupplierClient();
                sc.Create(sUPPLIER);
                return RedirectToAction("Index");
            }

            return View(sUPPLIER);
        }

        // GET: SUPPLIERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            SupplierClient sc = new SupplierClient();
            return View(sc.find(id));
        }

        // POST: SUPPLIERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SUPLNO,SUPLNAME,SUPLADDR")] SupplierModel sUPPLIER)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(sUPPLIER).State = EntityState.Modified;
                //db.SaveChanges();
                sUPPLIER.SUPLNO = sUPPLIER.SUPLNO.Trim();
                SupplierClient sc = new SupplierClient();
                sc.PutSUPPLIER(sUPPLIER);
                return RedirectToAction("Index");
            }
            return View(sUPPLIER);
        }

        // GET: SUPPLIERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            SupplierClient sc = new SupplierClient();
            SupplierModel sm = sc.find(id);
            sc.Delete(id);
            return View(sm);
        }

        // POST: SUPPLIERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //SUPPLIER sUPPLIER = db.SUPPLIERs.Find(id);
            //db.SUPPLIERs.Remove(sUPPLIER);
            //db.SaveChanges();
            SupplierClient sc = new SupplierClient();
            sc.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
