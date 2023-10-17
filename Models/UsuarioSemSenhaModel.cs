using System;
using System.ComponentModel.DataAnnotations;
using CrudApp.Enums;

namespace CrudApp.Models
{   // Classe feita para a edição de usuários(onde não é possível editar a senha)
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set;}
    }
}
