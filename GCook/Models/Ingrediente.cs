using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GCook.Models;
[Table("Ingrediente")]

    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }
    }
