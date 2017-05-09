using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudMVC.Models
{
    public class Livro
    {
        public IList<TestarPost> ListaPedidos { get; set; }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoEdicao { get; set; }
        public decimal Valor { get; set; }
      

        public Genero Genero { get; set; }
        public int GeneroId { get; set; }
        public int cmd_pais { get; set; }

        private Livro()
        {
            // Criar uma tabela em memoria -- TO DO: Criar tabelas
            this.ListaPedidos = new List<TestarPost>();
        }

        /// <summary>
        /// Método para carregar o banco de dados em memória.
        /// NÃO PRECISA ALTERAR ESTE MÉTODO
        /// </summary>
        /// <returns></returns>
        public static Livro CriarConexaoComBancoDeDados()
        {
            Livro banco = HttpContext.Current.Session["bd"] as Livro;

            if (banco == null)
                HttpContext.Current.Session["bd"] = new Livro();

            return HttpContext.Current.Session["bd"] as Livro;
        }

    }
}