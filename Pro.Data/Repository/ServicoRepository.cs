using Pro.Business.Interfaces;
using Pro.Business.Models;
using Pro.Data.Context;

namespace Pro.Data.Repository;

public class ServicoRepository : Repository<Servico>, IServicoRepository
{
    public ServicoRepository(ApiContext context) : base(context) { }

}
