using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(50,ErrorMessage ="O tamanho Maximo do texto é 50")]
        [Required(ErrorMessage ="Campo não pode ser nulo")]
        [Display (Name = "Nome")]
        public string CategoriaNome { get; set; }
        [StringLength(200, ErrorMessage = "O tamanho Maximo do texto é 50")]
        [Required(ErrorMessage = "Campo não pode ser nulo")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }

    }
}
