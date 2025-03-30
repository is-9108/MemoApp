using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemosApplication.Models;

namespace MemosApplication.Controllers
{
    [Authorize]
    public class MemoListsController : Controller
    {
        private MemoListsContext db = new MemoListsContext();

        // GET: MemoLists
        public ActionResult Index()
        {
            return View(db.MemoLists.ToList());
        }

        // GET: MemoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemoList memoList = db.MemoLists.Find(id);
            if (memoList == null)
            {
                return HttpNotFound();
            }
            return View(memoList);
        }

        // GET: MemoLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemoLists/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Details")] MemoList memoList)
        {
            if (ModelState.IsValid)
            {
                db.MemoLists.Add(memoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memoList);
        }

        // GET: MemoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemoList memoList = db.MemoLists.Find(id);
            if (memoList == null)
            {
                return HttpNotFound();
            }
            return View(memoList);
        }

        // POST: MemoLists/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Details")] MemoList memoList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memoList);
        }

        // GET: MemoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemoList memoList = db.MemoLists.Find(id);
            if (memoList == null)
            {
                return HttpNotFound();
            }
            return View(memoList);
        }

        // POST: MemoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemoList memoList = db.MemoLists.Find(id);
            db.MemoLists.Remove(memoList);
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
