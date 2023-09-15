using System.ComponentModel.DataAnnotations;

namespace Pro.WebAPI.ViewModels;

public class ClienteViewModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo {1} caracteres.")]
    public string? Nome { get; set; }

    public string Documento { get; set; }

    public int TipoCliente { get; set; }

    public EnderecoViewModel Endereco { get; set; }

    [StringLength(15, ErrorMessage = "O campo Telefone deve ter no máximo {1} caracteres.")]
    public string? Telefone { get; set; }

    [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
    [StringLength(100, ErrorMessage = "O campo Email deve ter no máximo {1} caracteres.")]
    public string? Email { get; set; }

    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    [StringLength(10, ErrorMessage = "O campo Sexo deve ter no máximo {1} caracteres.")]
    public string? Sexo { get; set; }

    [StringLength(500, ErrorMessage = "O campo Observações deve ter no máximo {1} caracteres.")]
    public string? Observacoes { get; set; }
}
