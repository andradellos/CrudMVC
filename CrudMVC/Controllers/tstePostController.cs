using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;


namespace CrudMVC.Controllers
{
    public class tstePostController : Controller
    {
        // GET: tstePost
        Livro clslll = Livro.CriarConexaoComBancoDeDados();
        public ActionResult Index()
        {


            clslll.ListaPedidos.Add(new TestarPost { nome = "Laura", livro = "Livro Um" });
            return View();
        }

        // GET: tstePost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: tstePost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstePost/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                clslll.ListaPedidos.Add(new TestarPost { nome = "Laura12", livro = "Livro Dois" });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tstePost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tstePost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: tstePost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: tstePost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


       
        //public ActionResult testando(int id, string autor, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
