﻿using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }       

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if(usuarioDB == null)
            {
                throw new Exception("Houve um erro na atualização do usuário");
            }
            else
            {
                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Email = usuario.Email;
                usuarioDB.Login = usuario.Login;
                usuarioDB.Perfil = usuario.Perfil;
                usuarioDB.DataAtualizacao = DateTime.Now;

                _bancoContext.Usuarios.Update(usuarioDB);
                _bancoContext.SaveChanges();
            }
            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null)
            {
                throw new Exception("Houve um erro ao deletar o usuário");
            }
            else
            {
                _bancoContext.Usuarios.Remove(usuarioDB);
                _bancoContext.SaveChanges();

                return true;
            }
            
        }

    }
}
