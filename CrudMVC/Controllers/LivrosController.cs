using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudMVC.AcessoDados;
using CrudMVC.Models;

namespace CrudMVC.Controllers
{
    public class LivrosController : Controller
    {
        private LivroContexto db = new LivroContexto();
        Livro clslll;

        // GET: Livros
        public ActionResult Index()
        {
            clslll = Livro.CriarConexaoComBancoDeDados();
            clslll.ListaPedidos.Add(new TestarPost { nome = "Laura", livro = "Livro Um" });
            return View();
        }
        public PartialViewResult Listar(int pagina = 1, int registros = 5)
        {
            var livros = db.Livros.Include(l => l.Genero);
            var livrospaginados = livros.OrderBy(l => l.Titulo).Skip((pagina - 1) * registros).Take(5);
            return PartialView("_Listar", livrospaginados.ToList());
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Generos, "id", "Nome");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,AnoEdicao,Valor,GeneroId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                clslll.ListaPedidos.Add(new TestarPost { nome = "Laura", livro = "Livro Um" });
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Generos, "id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,AnoEdicao,Valor,GeneroId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "id", "Nome", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
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






        public Livro testando(int id, string autor, int md_pais, Livro collection)
        {
            //try
            //{
            //    // TODO: Add delete logic here

            return collection;
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
