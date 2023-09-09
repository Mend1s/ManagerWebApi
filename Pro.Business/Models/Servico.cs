using Pro.Business.Enum;

namespace Pro.Business.Models
{
    public class Servico : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public CategoriaServicos CategoriaServicos { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
