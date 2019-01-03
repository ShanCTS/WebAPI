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
    public class ITEMsController : Controller
    {
        

        // GET: ITEMs
        public ActionResult Index()
        {
            ItemClient ic = new ItemClient();
            return View(ic.findAll());
        }

        // GET: ITEMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemClient ic = new ItemClient();
            return View(ic.find(id));
        }

        // GET: ITEMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITEMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ITCODE,ITDESC,ITRATE")] ItemModel iTEM)
        {
            if (ModelState.IsValid)
            {
                ItemClient ic = new ItemClient();
                ic.Create(iTEM);
                return RedirectToAction("Index");
            }

            return View(iTEM);
        }

        // GET: ITEMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemClient ic = new ItemClient();
            return View(ic.find(id));
        }

        // POST: ITEMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ITCODE,ITDESC,ITRATE")] ItemModel iTEM)
        {
            if (ModelState.IsValid)
            {
                iTEM.ITCODE = iTEM.ITCODE.Trim();
                ItemClient ic = new ItemClient();
                ic.PutSUPPLIER(iTEM);
                return RedirectToAction("Index");
            }
            return View(iTEM);
        }

        // GET: ITEMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemClient ic = new ItemClient();
            ItemModel sm = ic.find(id);
            ic.Delete(id);
            return View(sm);
        }

        // POST: ITEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ItemClient ic = new ItemClient();
            ic.Delete(id);
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
