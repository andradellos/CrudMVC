using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC.Models;

namespace CrudMVC.Controllers
{
    public class VariosBotoesController : Controller
    {
        // GET: VariosBotoes
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(VariosBotoes varios, string id)
        {

            int resultados = 0;
           
            resultados = varios.PrimeiroValor + varios.SegundoValor;
            //VariosBotoes nm = new VariosBotoes();
            //nm.PrimeiroValor = varios.PrimeiroValor;
            //nm.SegundoValor = varios.SegundoValor;
            //nm.resultado = resultados;
            return View(varios);
            //return View("Somar",new VariosBotoes() {PrimeiroValor=varios.PrimeiroValor,SegundoValor= varios.SegundoValor, resultado= resultados });
        }
        public ActionResult Somar()
        {
            return View();
        }
        



    }
}