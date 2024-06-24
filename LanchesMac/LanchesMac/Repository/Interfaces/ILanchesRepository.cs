using LanchesMac.Models;

namespace LanchesMac.Repository.Interfaces
{
    public interface ILanchesRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLanche(int id);
    }
}
