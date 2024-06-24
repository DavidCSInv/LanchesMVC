using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name ="Nome")]
        [MaxLength(100,ErrorMessage ="O limite maximo de caracteres são 100")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O descrição deve ser informada")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20,ErrorMessage ="Deve ser digitado no minimo 20 caracteres")]
        [MaxLength(100, ErrorMessage = "O limite maximo de caracteres são 100")] 
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O descrição deve ser informada")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Deve ser digitado no minimo 20 caracteres")]
        [MaxLength(300, ErrorMessage = "O limite maximo de caracteres são 200")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "O descrição deve ser informada")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal (10,2)")]
        [Range(1,999.99,ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name ="Caminho Imagem normal")]
        [StringLength(500,ErrorMessage = "O {0} deve ter no maximo {1} caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(500, ErrorMessage = "O {0} deve ter no maximo {1} caracteres")]
        public string ImagemThumbnail { get; set; }
        [Display(Name = "Lanche preferido")]
        public bool isLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
