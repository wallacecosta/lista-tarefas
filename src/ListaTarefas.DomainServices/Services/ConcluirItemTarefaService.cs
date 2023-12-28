using ListaTarefas.DomainServices.Abstraction;
using ListaTarefas.DomainServices.Helpers;
using ListaTarefas.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.DomainServices.Services
{
    public class ConcluirItemTarefaService : IConcluirItemTarefaService
    {
        private readonly AppDbContext _appDbContext;

        public ConcluirItemTarefaService(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task Execute(string id)
        {
            var idItem = id.ToGuid();

            var item = await _appDbContext.Itens
                .Where(t => t.ItemId == idItem)
                .SingleOrDefaultAsync();

            if (item == null)
                throw new Exception($"Item id: {id} não encontrado");

            item.Concluir(item);

            _appDbContext.Itens.Update(item);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
