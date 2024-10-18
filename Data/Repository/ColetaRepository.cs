using Microsoft.EntityFrameworkCore;
using NotificacaoColetaApi.Data;
using NotificacaoColetaApi.Data.Repository.Interfaces;
using NotificacaoColetaApi.Models;

namespace NotificacaoColetaApi.Repositories
{
    public class ColetaRepository : IColetaRepository
    {
        private readonly AppDbContext _context;

        public ColetaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarAsync(Coleta coleta)
        {
            _context.Coletas.Update(coleta);
            await _context.SaveChangesAsync();
        }

        public async Task CriarAsync(Coleta coleta)
        {
            await _context.Coletas.AddAsync(coleta);
            await _context.SaveChangesAsync();
        }

        public async Task<Coleta?> ObterPorIdAsync(int id)
        {
            return await _context.Coletas.FindAsync(id);
        }
    }
}