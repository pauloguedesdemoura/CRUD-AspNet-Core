using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_Fiap.Web.AspNet.Contexts;
using _05_Fiap.Web.AspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _05_Fiap.Web.AspNet.Controllers
{
    public class SorveteController : Controller
    {
        private SorveteriaContext _context;

        public SorveteController(SorveteriaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Sorvete sorvete)
        {
            _context.Sorvetes.Add(sorvete);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado!";
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(int id)
        {
            Sorvete sorvete = _context.Sorvetes.Find(id);
            return View(sorvete);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_context.Sorvetes.ToList());
        }
        [HttpPost]
        public IActionResult Editar(Sorvete sorvete)
        {
            _context.Update(sorvete);
            _context.SaveChanges();
            TempData["msg"] = "Atualizado!";
            return RedirectToAction("Listar");
        }

        public IActionResult Excluir(int id)
        {
            Sorvete sorvete = _context.Sorvetes.Find(id);
            _context.Sorvetes.Remove(sorvete);
            _context.SaveChanges();
            return RedirectToAction("Listar");

        }


    }
}