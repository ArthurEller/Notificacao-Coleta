using NotificacaoColetaApi.Data.Repository.Interfaces;
using NotificacaoColetaApi.Models;
using NotificacaoColetaApi.Services.Interfaces;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoService(INotificacaoRepository notificacaoRepository)
        {
            _notificacaoRepository = notificacaoRepository;
        }

        public async Task<Notificacao> CriarNotificacaoAsync(NotificacaoViewModel notificacaoViewModel)
        {
            var notificacao = new Notificacao
            {
                Mensagem = notificacaoViewModel.Mensagem,
                DataEnvio = DateTime.Now,
                NotificacaoId = notificacaoViewModel.NotificacaoId,
                Titulo = notificacaoViewModel.Titulo,
            };

            await _notificacaoRepository.CriarAsync(notificacao);

            return notificacao;
        }

        public async Task<bool> HealthCheck()
        {
            return true;
        }
    }
}