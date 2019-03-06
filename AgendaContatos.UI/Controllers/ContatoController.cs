using AgendaContatos.AppService.Interfaces;
using AgendaContatos.AppService.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgendaContatos.UI.Controllers
{
    public class ContatoController : Controller
    {
        private IContatoAppService _contatoAppService;

        public ContatoController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        // GET: Contato
        public ActionResult Index()
        {
            var lista = _contatoAppService.ListarTodos();

            return View(lista);
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContatoModel contatoModel)
        {
            try
            {
                contatoModel = _contatoAppService.Incluir(contatoModel);

                foreach (var erro in contatoModel.ListaErros)
                {
                    ModelState.AddModelError(erro.Key, erro.Value);
                }

                if (ModelState.IsValid)
                    return RedirectToAction(nameof(Index));
                else
                    return View(contatoModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int id)
        {
            var contatoModel = _contatoAppService.ListarPorId(id);

            if (contatoModel.ContatoId == 0)
                return NotFound();

            return View(contatoModel);
        }

        // POST: Contato/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContatoModel contatoModel)
        {
            try
            {
                contatoModel = _contatoAppService.Editar(contatoModel);

                foreach (var erro in contatoModel.ListaErros)
                {
                    ModelState.AddModelError(erro.Key, erro.Value);
                }

                if (ModelState.IsValid)
                    return RedirectToAction(nameof(Index));
                else
                    return View(contatoModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int id)
        {
            var contatoModel = _contatoAppService.ListarPorId(id);

            if (contatoModel.ContatoId == 0)
                return NotFound();

            return View(contatoModel);
        }

        // POST: Contato/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ContatoModel contatoModel)
        {
            try
            {
                if (_contatoAppService.Excluir(contatoModel.ContatoId))
                {
                    return RedirectToAction(nameof(Index));
                }

                return View(contatoModel);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("ContatoId", ex.Message);
                return View(contatoModel);
            }
        }
    }
}