using System.ComponentModel.DataAnnotations;
namespace GCook.ViewModels;

    public class LoginVM
    {
        [Display(Name = "Email ou Nome de Usuário", Prompt = "Informe seu email ou nome de usuário")]
        [Required(ErrorMessage = "Email ou nome de usuário é obrigatório!")]        
        public string Email { get; set; }

        [Display(Name = "Senha de Acesso", Prompt = "*****")]
        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Manter conectado")]
        public bool Lembrar { get; set; }

        public string UrlRetorno { get; set; }
    }
