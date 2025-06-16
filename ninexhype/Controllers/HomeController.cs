using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ninexhype.Models;
using ninexhype.Data;
using Microsoft.EntityFrameworkCore;
using ninexhype.ViewModels;

namespace ninexhype.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _db;

    public HomeController(ILogger<HomeController> logger, AppDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        List<Produto> produtos = _db.Produtos
            .Where(p => p.Destaque)
            .OrderBy(p => EF.Functions.Random())
            .Include(p => p.Fotos)
            .Take(8)
            .ToList();
        return View(produtos);
    }

    public IActionResult Produto(int id)
    {
        Produto produto = _db.Produtos
            .Where(p => p.Id == id)
            .Include(p => p.Categoria)
            .Include(p => p.Fotos)
            .SingleOrDefault();
        
        List<Produto> semelhantes = _db.Produtos
            .Where(p => p.Id != id && p.CategoriaId == produto.CategoriaId)
            .OrderBy(p => EF.Functions.Random())
            .Include(p => p.Categoria)
            .Include(p => p.Fotos)
            .Take(4)
            .ToList();
        
        ProdutoVM produtoVM = new() {
            Produto = produto,
            Semelhantes = semelhantes
        };
        
        return View(produtoVM);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
