using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ControleVeiculos.Data;
using ControleVeiculos.Models;

namespace ControleVeiculos.Controllers
{
    public class VeiculosController : Controller
    {
        private Context db = new Context();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculos = db.Veiculos.Include(v => v.Categoria).Include(v => v.Responsavel);
            return View(veiculos.ToList());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(db.Categorias, "Id", "Descricao");
            ViewData["ResponsavelId"] = new SelectList(db.Responsaveis, "Id", "Nome");
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculos.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["CategoriaId"] = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewData["ResponsavelId"] = new SelectList(db.Responsaveis, "Id", "Nome", veiculo.ResponsavelId);
            db.Veiculos.Add(veiculo);
            db.SaveChanges();
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewData["CategoriaId"] = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewData["ResponsavelId"] = new SelectList(db.Responsaveis, "Id", "Nome", veiculo.ResponsavelId);
            return View(veiculo);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategoriaId"] = new SelectList(db.Categorias, "Id", "Descricao", veiculo.CategoriaId);
            ViewData["ResponsavelId"] = new SelectList(db.Responsaveis, "Id", "Nome", veiculo.ResponsavelId);
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculo veiculo = db.Veiculos.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculos.Find(id);
            db.Veiculos.Remove(veiculo);
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
