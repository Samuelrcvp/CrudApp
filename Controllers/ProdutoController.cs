using CrudApp.Filters;
using CrudApp.Helper;
using CrudApp.Models;
using CrudApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly ISessao _sessao;

        public ProdutoController(IProdutoRepositorio produtoRepositorio,
                                 ISessao sessao) 
        {
            _produtoRepositorio = produtoRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
            List<ProdutoModel> produtos = _produtoRepositorio.BuscarTodos(usuarioLogado.Id);

            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _produtoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Produto deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir produto";
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir produto: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    produto.UsuarioId = usuarioLogado.Id;
                    _produtoRepositorio.Adicionar(produto);

                    TempData["MensagemSucesso"] = "Produto cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar produto: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    produto.UsuarioId = usuarioLogado.Id;

                    _produtoRepositorio.Atualizar(produto);
                    TempData["MensagemSucesso"] = "Produto alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", produto);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar produto: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
