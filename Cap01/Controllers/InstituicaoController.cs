using Cap01.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cap01.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID=1,
                Nome="Uniparaná",
                Endereco="Paraná"
            },
            new Instituicao()
            {
                InstituicaoID=2,
                Nome="Unisanta",
                Endereco="Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoID=3,
                Nome="UniSãoPaulo",
                Endereco="São Paulo"
            },
            new Instituicao()
            {
                InstituicaoID=4,
                Nome="UniGrandense",
                Endereco="Rio Grande do Sul"
            },
            new Instituicao()
            {
                InstituicaoID=5,
                Nome="Unicarioca",
                Endereco="Rio de Janeiro"
            }
        };

        public IActionResult Index()
        {
            return View(instituicoes.OrderBy(i => i.InstituicaoID)); // Coloca em ordem de ID
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        public ActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.InstituicaoID == id).First());
        }

        // create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instituicao instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoID = instituicoes.Select(i => i.InstituicaoID).Max() + 1; //incrementa o ID
            return RedirectToAction("Index");
        }

        //edit quando editar na view Edit, vai atualizar e voltar para o Index modificado. (PG 47)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Instituicao instituicao)
        {
            //// Tecnica que remove depois adiciona a modificação
            //instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            //instituicoes.Add(instituicao);

            //Tecnica sem remover e adicionar a modificada.
            instituicoes[instituicoes.IndexOf(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First())] = instituicao;

            return RedirectToAction("Index");
        }

        //metedo delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID).First());
            return RedirectToAction("Index");
        }
    }
}