using System.Text.Json.Serialization;

namespace Pro.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
