using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ControleVeiculos.Data;
using ControleVeiculos.Models;

namespace ControleVeiculos.Controllers
{
    public class ResponsaveisController : Controller
    {
        private Context db = new Context();

        // GET: Responsaveis
        public ActionResult Index()
        {
            return View(db.Responsaveis.ToList());
        }

        // GET: Responsaveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // GET: Responsaveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsaveis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Responsaveis.Add(responsavel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsavel);
        }

        // GET: Responsaveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsavel);
        }

        // GET: Responsaveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsaveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsavel responsavel = db.Responsaveis.Find(id);
            db.Responsaveis.Remove(responsavel);
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
