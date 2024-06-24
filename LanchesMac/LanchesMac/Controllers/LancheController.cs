using LanchesMac.Repository.Interfaces;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILanchesRepository _LancheRepository;

        public LancheController(ILanchesRepository lancheRepository)
        {
            _LancheRepository = lancheRepository;
        }
            
        public IActionResult List() 
        {
            var LanchesViewModel = new LanchesListViewModel();

            LanchesViewModel.LanchesViewModel = _LancheRepository.Lanches;
            LanchesViewModel.CategoriaAtual = "Categoria Atual";

            return View(LanchesViewModel);
        }
    }
}
