using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Clientes.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ClienteRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            _bancoContext.Clientes.Add(cliente);
            _bancoContext.SaveChanges();

            return cliente;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.Id);

            if(clienteDB == null)
            {
                throw new Exception("Houve um erro na atualização do cliente");
            }
            else
            {
                clienteDB.Nome = cliente.Nome;
                clienteDB.Email = cliente.Email;
                clienteDB.Celular = cliente.Celular;

                _bancoContext.Clientes.Update(clienteDB);
                _bancoContext.SaveChanges();
            }
            return clienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel clienteDB = ListarPorId(id);

            if (clienteDB == null)
            {
                throw new Exception("Houve um erro ao deletar o cliente");
            }
            else
            {
                _bancoContext.Clientes.Remove(clienteDB);
                _bancoContext.SaveChanges();

                return true;
            }
            
        }

    }
}
