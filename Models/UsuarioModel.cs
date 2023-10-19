using System;
using System.ComponentModel.DataAnnotations;
using CrudApp.Enums;
using CrudApp.Helper;

namespace CrudApp.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set;}

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha{ get; set;}
        public string? Salt { get; set;}
        public DateTime DataCadastro { get; set;}
        public DateTime? DataAtualizacao { get; set;}


        public void SetSenhaHash()
        {
            Salt = Criptografia.GerarSalt();
            Senha = Criptografia.GerarHash(Senha, Salt);
        }

        public bool SenhaValida(string senha)
        {
            return Senha == Criptografia.GerarHash(senha, Salt);
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Salt = Criptografia.GerarSalt();
            Senha = Criptografia.GerarHash(novaSenha, Salt);
            return novaSenha;
        }

        public void SetNovaSenha(string novaSenha)
        {
            Salt = Criptografia.GerarSalt();
            Senha = Criptografia.GerarHash(novaSenha, Salt);
        }
    }
}
