using Microsoft.EntityFrameworkCore;
using Pro.Business.Interfaces;
using Pro.Business.Models;
using Pro.Data.Context;

namespace Pro.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApiContext context) : base(context) { }

        public async Task<Cliente> ObterClienteEndereco(int id)
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Cliente>> ObterTodosComEnderecos()
        {
            return await Db.Clientes.AsNoTracking()
                .Include(c => c.Endereco)
                .ToListAsync();
        }

    }
}
