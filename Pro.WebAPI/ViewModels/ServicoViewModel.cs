using Pro.Business.Enum;
using System.ComponentModel.DataAnnotations;

namespace Pro.API.ViewModels;

public class ServicoViewModel
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres.")]
    public string Nome { get; set; }
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo Preço é obrigatório.")]
    public decimal Preco { get; set; }
    public CategoriaServicos CategoriaServicos { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}
