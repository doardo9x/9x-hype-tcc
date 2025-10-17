using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ninexhype.Data;
using ninexhype.Models;

namespace ninexhype.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = _context.Produtos.Include(p => p.Categoria).Include(p => p.Fotos);
            return View(await produtos.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)));
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,CategoriaId,Nome,Descricao,QtdeEstoque,ValorCusto,ValorVenda,Destaque,Genero,Marca,Cor,Material,AtividadeRecomendada")]
            Produto produto,
            List<IFormFile> Fotos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

                if (Fotos != null && Fotos.Count > 0)
                {
                    var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "produtos");
                    if (!Directory.Exists(pastaDestino))
                        Directory.CreateDirectory(pastaDestino);

                    foreach (var foto in Fotos)
                    {
                        if (foto.Length > 0)
                        {
                            var nomeArquivo = Guid.NewGuid() + Path.GetExtension(foto.FileName);
                            var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

                            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                            {
                                await foto.CopyToAsync(stream);
                            }

                            _context.ProdutoFoto.Add(new ProdutoFoto
                            {
                                ProdutoId = produto.Id,
                                ArquivoFoto = "/img/produtos/" + nomeArquivo
                            });
                        }
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _context.Produtos
                .Include(p => p.Fotos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null) return NotFound();

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,CategoriaId,Nome,Descricao,QtdeEstoque,ValorCusto,ValorVenda,Destaque,Genero,Marca,Cor,Material,AtividadeRecomendada")]
            Produto produto)
        {
            if (id != produto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", produto.CategoriaId);
            ViewBag.Generos = new SelectList(Enum.GetValues(typeof(Genero)), produto.Genero);
            return View(produto);
        }

        // POST: Produtos/AdicionarFoto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarFoto(int produtoId, List<IFormFile> novasFotos)
        {
            if (novasFotos != null && novasFotos.Count > 0)
            {
                var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "produtos");
                if (!Directory.Exists(pastaDestino))
                    Directory.CreateDirectory(pastaDestino);

                foreach (var foto in novasFotos)
                {
                    if (foto.Length > 0)
                    {
                        var nomeArquivo = Guid.NewGuid() + Path.GetExtension(foto.FileName);
                        var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

                        using var stream = new FileStream(caminhoCompleto, FileMode.Create);
                        await foto.CopyToAsync(stream);

                        _context.ProdutoFoto.Add(new ProdutoFoto
                        {
                            ProdutoId = produtoId,
                            ArquivoFoto = "/img/produtos/" + nomeArquivo
                        });
                    }
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = produtoId });
        }

        // POST: Produtos/ExcluirFoto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirFoto(int fotoId)
        {
            var foto = await _context.ProdutoFoto.FindAsync(fotoId);
            if (foto != null)
            {
                var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", foto.ArquivoFoto.TrimStart('/'));
                if (System.IO.File.Exists(caminho))
                    System.IO.File.Delete(caminho);

                _context.ProdutoFoto.Remove(foto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = foto?.ProdutoId });
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}