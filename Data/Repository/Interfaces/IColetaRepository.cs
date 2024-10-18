using NotificacaoColetaApi.Models;

namespace NotificacaoColetaApi.Data.Repository.Interfaces
{
    public interface IColetaRepository
    {
        Task AtualizarAsync(Coleta coleta);

        Task CriarAsync(Coleta coleta);

        Task<Coleta?> ObterPorIdAsync(int id);
    }
}