using NotificacaoColetaApi.Data.Repository.Interfaces;
using NotificacaoColetaApi.Models;
using NotificacaoColetaApi.Services.Interfaces;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Services
{
    public class ColetaService : IColetaService
    {
        private readonly IColetaRepository _coletaRepository;
        private readonly INotificacaoService _notificacaoService;

        public ColetaService(IColetaRepository coletaRepository, INotificacaoService notificacaoService)
        {
            _coletaRepository = coletaRepository;
            _notificacaoService = notificacaoService;
        }

        public async Task<Coleta?> AtualizarColetaAsync(ColetaViewModel coletaViewModel)
        {
            var coleta = await _coletaRepository.ObterPorIdAsync(coletaViewModel.ColetaId);
            if (coleta == null)
            {
                return null;
            }

            coleta.DataColeta = coletaViewModel.DataColeta;
            coleta.TipoResiduos = coletaViewModel.TipoResiduos;

            await _coletaRepository.AtualizarAsync(coleta);
            return coleta;
        }

        public async Task<Coleta> CriarColetaAsync(ColetaViewModel coletaViewModel)
        {
            var coleta = new Coleta
            {
                DataColeta = coletaViewModel.DataColeta,
                TipoResiduos = coletaViewModel.TipoResiduos,
            };

            await _coletaRepository.CriarAsync(coleta);

            await _notificacaoService.CriarNotificacaoAsync(new NotificacaoViewModel
            {
                Mensagem = "Coleta criada com sucesso!",
                NotificacaoId = new Random().Next(333, 999),
                Titulo = "Coleta criada",
            });

            return coleta;
        }
    }
}