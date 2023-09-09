using System.ComponentModel.DataAnnotations;

namespace Pro.WebAPI.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "O campo Logradouro deve ter no máximo {1} caracteres.")]
        public string Logradouro { get; set; }

        [StringLength(20, ErrorMessage = "O campo Número deve ter no máximo {1} caracteres.")]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "O campo Complemento deve ter no máximo {1} caracteres.")]
        public string Complemento { get; set; }

        [StringLength(10, ErrorMessage = "O campo CEP deve ter no máximo {1} caracteres.")]
        public string Cep { get; set; }

        [StringLength(100, ErrorMessage = "O campo Bairro deve ter no máximo {1} caracteres.")]
        public string Bairro { get; set; }

        [StringLength(100, ErrorMessage = "O campo Cidade deve ter no máximo {1} caracteres.")]
        public string Cidade { get; set; }

        [StringLength(50, ErrorMessage = "O campo Estado deve ter no máximo {1} caracteres.")]
        public string Estado { get; set; }

        public int ClienteId { get; set; }
    }
}
