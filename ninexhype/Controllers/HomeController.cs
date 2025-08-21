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
    var produtos = _db.Produtos
        .Where(p => p.CategoriaId != 8)
        .Include(p => p.Categoria)
        .Include(p => p.Fotos)
        .ToList();

    var destaques = _db.Produtos
        .Where(p => p.CategoriaId == 8)
        .OrderBy(p => EF.Functions.Random())
        .Include(p => p.Fotos)
        .Take(4)
        .ToList();

    var tiposRoupa = _db.TiposRoupa
        .Include(t => t.Categorias)
        .ThenInclude(c => c.Produtos)
        .ToList();

    // Filtrar produtos de cada categoria, removendo destaques
    foreach (var tipo in tiposRoupa)
    {
        foreach (var categoria in tipo.Categorias)
        {
            categoria.Produtos = categoria.Produtos
                .Where(p => p.CategoriaId != 8)
                .ToList();
        }
}
    var indexVM = new IndexVM
    {
        Produtos = produtos,
        Destaques = destaques,
        TiposRoupa = tiposRoupa
    };

    return View(indexVM);
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

    // public IActionResult PagHomem()
    // {
    //     var produtos = _db.Produtos
    //     .Where(p => p.Genero == Genero.Masculino)
    //     .Include(p => p.Categoria)
    //     .Include(p => p.Fotos)
    //     .ToList();

    // var paghomemVM = new pagHomemVM
    // {
    //     Produtos = produtos
    // };
    //     return View();
    // }

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
