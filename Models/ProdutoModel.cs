using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite o preço do produto")]
        public double Preco { get; set; }
        
        [Required(ErrorMessage = "Digite o código SKU do produto")]
        public string Sku { get; set; }

        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Escolha o fornecedor desse produto")]
        public string Fornecedor { get; set; }
        
        [Required(ErrorMessage = "Faça o upload da imagem do produto")]
        public string Imagem { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }
        
    }
}
  