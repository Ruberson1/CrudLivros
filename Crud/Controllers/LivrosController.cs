using Crud.Data;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crud.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AplicationDbContext _context;

        public LivrosController(AplicationDbContext context)
        {
            _context = context;
        }
        //http Get Index
        public IActionResult Index()
        {
            IEnumerable<Livro> listLivros = _context.Livro;

            return View(listLivros);
        }
        //http Get Create
        public IActionResult Create()
        {
            return View();
        }
        //http Post Creat
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Livro.Add(livro);
                _context.SaveChanges();
                TempData["Mensagem"] = "Livro criado com sucesso";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //getlivro
            var livro = _context.Livro.Find(id);

            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }
        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Livro.Update(livro);
                _context.SaveChanges();

                TempData["Mensagem"] = "Livro atualizado com sucesso";
                return RedirectToAction("Index");
            }
            return View();
        }
        // Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //getlivro
            var livro = _context.Livro.Find(id);

            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }
            //Post Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLivro(int? id)
        {
            //get livro por Id
            var livro = _context.Livro.Find(id);

            if (livro == null )
            {
                return NotFound();
            }
        
            _context.Livro.Remove(livro);
            _context.SaveChanges();

            TempData["Mensagem"] = "Livro excluído com sucesso";
            return RedirectToAction("Index");
            
            
        }

    }
}
