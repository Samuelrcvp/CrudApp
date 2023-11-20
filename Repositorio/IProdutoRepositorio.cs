using CrudApp.Models;

namespace CrudApp.Repositorio
{
    public interface IProdutoRepositorio
    {
        ProdutoModel ListarPorId(int id);
        List<ProdutoModel> BuscarTodos(int usuarioId);
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel Atualizar(ProdutoModel produto);
        bool Apagar(int id);
    }
}
