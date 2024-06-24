using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repository
{
    public class LancheRepository : ILanchesRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context) 
        { 
            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(w => w.isLanchePreferido)
                                                                         .Include(c =>c.Categoria);

        public Lanche GetLanche(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(f => f.LancheId == LancheId);
        }
    }
}
