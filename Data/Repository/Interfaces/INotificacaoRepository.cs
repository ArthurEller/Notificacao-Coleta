using NotificacaoColetaApi.Models;

namespace NotificacaoColetaApi.Data.Repository.Interfaces
{
    public interface INotificacaoRepository
    {
        public Task<Notificacao> CriarAsync(Notificacao notificacao);
    }
}