using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CrudMVC.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrudMVC.AcessoDados
{
    public class LivroContexto : DbContext
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Retirar pluralização de tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Configurando colunas do tipo string da tabela parater no máximo 100 caracteres
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));

        }
    }
}