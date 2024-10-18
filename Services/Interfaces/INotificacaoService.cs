using NotificacaoColetaApi.Models;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Services.Interfaces
{
    public interface INotificacaoService
    {
        public Task<Notificacao> CriarNotificacaoAsync(NotificacaoViewModel notificacaoViewModel);

        public Task<bool> HealthCheck();
    }
}