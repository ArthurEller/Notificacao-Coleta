using NotificacaoColetaApi.Data.Repository.Interfaces;
using NotificacaoColetaApi.Models;

namespace NotificacaoColetaApi.Data.Repository
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly AppDbContext _context;

        public NotificacaoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Notificacao> CriarAsync(Notificacao notificacao)
        {
            _context.Notificacoes.Add(notificacao);
            await _context.SaveChangesAsync();

            return notificacao;
        }
    }
}