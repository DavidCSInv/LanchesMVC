using LanchesMac.Models;

namespace LanchesMac.ViewModel
{
    public class LanchesListViewModel
    {
        public IEnumerable<Lanche> LanchesViewModel { get; set; }   
        public string CategoriaAtual {  get; set; }
    }
}
