[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(CrudMVC.MVCGridConfig), "RegisterGrids")]

namespace CrudMVC
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
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

    using MVCGrid.Models;
    using MVCGrid.Web;

    public static class MVCGridConfig
    {
        public static string Options(int CodValue)
        {
            String retorno = null;
            
            retorno = "<select id='cmd_pais' name='cmd_pais'>";
            retorno += "<option value='-1'>Selecione</option>";

            string select = null;

            for (int i = 1; i < 5; i++)
            {
                select = null;
                if (i == CodValue) { select = "selected='selected'"; }

                retorno += "<option value='" + i.ToString() + "' " + select + ">Paraguai" + i.ToString() + "</option>";
            }
            retorno += "</ select>";
            return retorno;
        }

        //public static string BotaoAcao()
        //{
        //    string Val =
        //    "<input id='idbtvaidar' type='button' value='teste'  onclick='BotaoValidar()'/>";
        //}

        public static List<Livro> ClsLivros()
        {
            List<Livro> ListaLivro = new List<Models.Livro>();

            //ListaLivro.Add(new Livro() { Id = 1, Titulo = "Titulo um", Autor = "altor um", AnoEdicao = 1987, Genero = null, Valor = 30, cmd_pais = 2 });
            //ListaLivro.Add(new Livro() { Id = 2, Titulo = "Titulo Dois", Autor = "altor Dois", AnoEdicao = 1988, Genero = null, Valor = 40, cmd_pais = 1 });
            return ListaLivro;

        }

        public static void RegisterGrids()
        {
            GridDefaults defaultSet1 = new GridDefaults()
            {
                Paging = true,
                ItemsPerPage = 20,
                Sorting = true,
                NoResultsMessage = "Sorry, sem dados"
            };



            MVCGridDefinitionTable.Add("grvManolo", new MVCGridBuilder<Livro>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    //Add your columns here
                    cols.Add("Id").WithColumnName("Id")
                        .WithHeaderText("Any Header")
                        .WithValueExpression(i => i.Id.ToString());

                    cols.Add("Titulo").WithColumnName("Titulo")
                     .WithHeaderText("Titulo")
                     .WithValueExpression(i => i.Titulo);// use the Value Expression to return the cell text for this column

                    cols.Add("Valor").WithColumnName("Valor")
                        .WithHeaderText("Edit")
                        .WithValueExpression(i => i.Valor.ToString());

                    cols.Add("cmd_pais").WithSorting(false).WithHtmlEncoding(false)
                    .WithHeaderText("Texto")
                    .WithValueExpression(p => Options(p.cmd_pais))
                    .WithValueTemplate("{Value}", false);

                    //   .WithValueTemplate("<select id='cmd_pais' name='cmd_pais'>" + Options({Value}) + "</ select>", false);

                    cols.Add("Autor").WithSorting(false).WithHtmlEncoding(false)
                        .WithValueExpression((p, c) => c.UrlHelper.Action("testando", "Livros", new { id = p.Id, autor = p.Autor, md_pais = p.cmd_pais }))
                        .WithValueTemplate("<a href='{Value}'>{Row.Id}</a>", false);


                    cols.Add("Botao").WithSorting(false).WithHtmlEncoding(false)
                     .WithValueExpression(p => p.Id.ToString())
                        .WithValueTemplate("<input id='idbtvaidar' contID='{Value}' type='button' value='teste'  onclick='BotaoValidar()'/>", false);


                })
                .WithRetrieveDataMethod((context) =>
                {
                    // Query your data here. Obey Ordering, paging and filtering parameters given in the context.QueryOptions.
                    // Use Entity Framework, a module from your IoC Container, or any other method.
                    //Return QueryResult object containing IEnumerable<YouModelItem>

                    var result = new QueryResult<Livro>();

                    //using (var db = new LivroContexto())
                    //{
                    //    result.Items = db.Livros.ToList();
                    //}
                    //result.Items = Session["MyProp"] as List<Livro>;

                    return result;


                })
            );

        }
    }
}