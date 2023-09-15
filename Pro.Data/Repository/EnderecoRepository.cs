using Microsoft.EntityFrameworkCore;
using Pro.Business.Interfaces;
using Pro.Business.Models;
using Pro.Data.Context;

namespace Pro.Data.Repository;

public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(ApiContext context) : base(context) { }

    public async Task<Endereco> ObterEnderecoPorCliente(int clienteId)
    {
        return await Db.Enderecos.AsNoTracking()
            .FirstOrDefaultAsync(e => e.ClienteId == clienteId);
    }
}
