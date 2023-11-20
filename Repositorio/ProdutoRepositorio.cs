using CrudApp.Data;
using CrudApp.Models;
using MySqlX.XDevAPI;

namespace CrudApp.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);

        }

        public List<ProdutoModel> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Produtos.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();

            return produto;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null)
            {
                throw new Exception("Houve um erro na atualização do produto");
            }
            else
            {
                produtoDB.Nome = produto.Nome;
                produtoDB.Preco = produto.Preco;
                produtoDB.Sku = produto.Sku;
                produtoDB.Descricao = produto.Descricao;
                produtoDB.Fornecedor = produto.Fornecedor;
                produtoDB.Imagem = produto.Imagem;


                _bancoContext.Produtos.Update(produtoDB);
                _bancoContext.SaveChanges();
            }
            return produtoDB;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = ListarPorId(id);

            if (produtoDB == null)
            {
                throw new Exception("Houve um erro ao deletar o produto");
            }
            else
            {
                _bancoContext.Produtos.Remove(produtoDB);
                _bancoContext.SaveChanges();

                return true;
            }
        }
    }
}
