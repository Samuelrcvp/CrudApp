using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if(contatoDB == null)
            {
                throw new Exception("Houve um erro na atualização do contato");
            }
            else
            {
                contatoDB.Nome = contato.Nome;
                contatoDB.Email = contato.Email;
                contatoDB.Celular = contato.Celular;

                _bancoContext.Contatos.Update(contatoDB);
                _bancoContext.SaveChanges();
            }
            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null)
            {
                throw new Exception("Houve um erro ao deletar o contato");
            }
            else
            {
                _bancoContext.Contatos.Remove(contatoDB);
                _bancoContext.SaveChanges();

                return true;
            }
            
        }
    }
}
