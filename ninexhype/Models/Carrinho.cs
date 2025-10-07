using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ninexhype.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();
    }
}
