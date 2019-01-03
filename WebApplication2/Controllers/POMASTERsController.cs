using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class POMASTERsController : Controller
    {
        

        // GET: POMASTERs
        public ActionResult Index()
        {
            POMasterClient pc = new POMasterClient();
            SupplierClient sc = new SupplierClient(); 
            IEnumerable<POMasterModel> pm;
            pm = pc.findAll();
            IEnumerable<SupplierModel> sm;
            sm = sc.findAll();
            foreach (var item in pm)
            {
                foreach (var item2 in sm)
                {
                    if (item.SUPLNO.Trim() == item2.SUPLNO.Trim())
                    {
                        item.SUPPLIER = new SupplierModel();
                        item.SUPPLIER.SUPLNAME = item2.SUPLNAME;
                    }
                }
            }
            return View(pm);
        }

        // GET: POMASTERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POMasterClient pc = new POMasterClient();
            SupplierClient sc = new SupplierClient();
            POMasterModel pm;
            pm = pc.find(id);
            SupplierModel sm;
            sm = sc.find(pm.SUPLNO.Trim());
            pm.SUPPLIER = new SupplierModel();
            pm.SUPPLIER.SUPLNAME = sm.SUPLNAME;
            return View(pm);
        }

        // GET: POMASTERs/Create
        public ActionResult Create()
        {
            //ViewBag.SUPLNO = new SelectList(db.SUPPLIERs, "SUPLNO", "SUPLNAME");
            return View();
        }

        // POST: POMASTERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PONO,PODATE,SUPLNO")] POMasterModel pOMASTER)
        {
            if (ModelState.IsValid)
            {
                POMasterClient pc = new POMasterClient();
                pc.Create(pOMASTER);
                return RedirectToAction("Index");
            }

            //ViewBag.SUPLNO = new SelectList(db.SUPPLIERs, "SUPLNO", "SUPLNAME", pOMASTER.SUPLNO);
            return View(pOMASTER);
        }

        // GET: POMASTERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POMasterClient pc = new POMasterClient();
            return View(pc.find(id));
        }

        // POST: POMASTERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PONO,PODATE,SUPLNO")] POMasterModel pOMASTER)
        {
            if (ModelState.IsValid)
            {
                pOMASTER.PONO = pOMASTER.PONO.Trim();
                POMasterClient pc = new POMasterClient();
                pc.PutSUPPLIER(pOMASTER);
                return RedirectToAction("Index");
            }
            SupplierClient sc = new SupplierClient();
            ViewBag.SUPLNO = new SelectList(sc.findAll(), "SUPLNO", "SUPLNAME", pOMASTER.SUPLNO);
            return View(pOMASTER);
        }

        // GET: POMASTERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POMasterClient pc = new POMasterClient();
            POMasterModel pm = pc.find(id);
            pc.Delete(id);
            return View(pm);
        }

        // POST: POMASTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            POMasterClient pc = new POMasterClient();
            pc.Delete(id);
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
