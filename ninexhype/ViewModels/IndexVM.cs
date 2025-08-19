using ninexhype.Models;
using System.Collections.Generic;

namespace ninexhype.ViewModels
{
    public class IndexVM
    {
        public List<Produto> Produtos { get; set; } = new();
        public List<Produto> Destaques { get; set; } = new();
        public List<TipoRoupa> TiposRoupa { get; set; } = new();
    }
}
