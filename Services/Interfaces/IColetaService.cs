using NotificacaoColetaApi.Models;
using NotificacaoColetaApi.ViewModel;

namespace NotificacaoColetaApi.Services.Interfaces
{
    public interface IColetaService
    {
        Task<Coleta?> AtualizarColetaAsync(ColetaViewModel coletaViewModel);

        Task<Coleta> CriarColetaAsync(ColetaViewModel coletaViewModel);
    }
}