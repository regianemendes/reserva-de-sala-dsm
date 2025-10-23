﻿using Microsoft.AspNetCore.Mvc;
using reserva_de_sala_dsm.Interfaces;
using reserva_de_sala_dsm.Models;
using reserva_de_sala_dsm.Services;
using System.Threading.Tasks;

namespace reserva_de_sala_dsm.Controllers
{
    public class SalaController : Controller
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        //GET : /Salas/Index ou /Salas/
        public async Task<IActionResult> Index()
        {
            var salas = await _salaService.GetAllSalasAsync();
            return View(salas);
        }

        public async Task<IActionResult> Details(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada";
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }
        //GET : /Salas/Create
        public IActionResult Create()
        {
            return View(new Sala());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Nome,Capacidade, Recursos")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _salaService.SaveSalaAsync(sala);
                    TempData["SucessMessage"] = "Sala criada com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao criar sala: " + ex.Message);
                }
            }
            return View(sala);
        }

        //GET: Salas/Edit/{id}
        public async Task<IActionResult> Edit(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                TempData["ErrorMessage"] = "Sala não encontrada";
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }


        //POST: /Salas/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long id, [Bind("Id, Nome, Capacidade, Recursos")] Sala sala)
        {
            if (id != sala.Id)
            {
                TempData["ErrosMessage"] = "ID da sala incosistente";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _salaService.SaveSalaAsync(sala);
                    TempData["SucessMessage"] = "Sala atualizada com sucesso";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Erro ao atualizar sala: " + ex.Message);
                }
            }
            return View(sala);
        }
        //GET: /Salas/Delete/{id}
        public async Task<IActionResult> Delete(long id)
        {
            var sala = await _salaService.GetSalaByIdAsync(id);

            if (sala == null)
            {
                TempData["ErrosMessage"] = "Sala não encontrada para deleção";
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        //POST: /Salas/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(long id)
        {
            try
            {
                await _salaService.DeleteSalasAsync(id);
                TempData["SucessMessage"] = "Sala foi excluída com sucesso!";
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao excluir sala: " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
