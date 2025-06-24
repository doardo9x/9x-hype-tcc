using ninexhype.Models;

namespace ninexhype.ViewModels;

public class ProdutoVM
{
    public Produto Produto { get; set; }
    public List<Produto> Semelhantes { get; set; }

    public Produto Destaque { get; set; }
}
