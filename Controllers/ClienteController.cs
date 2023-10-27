using CrudApp.Filters;
using CrudApp.Helper;
using CrudApp.Models;
using CrudApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly ISessao _sessao;

        public ClienteController(IClienteRepositorio clienteRepositorio,
                                 ISessao sessao) 
        { 
            _clienteRepositorio = clienteRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos(usuarioLogado.Id);

            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir cliente";
                }
               
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir cliente: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    cliente.UsuarioId = usuarioLogado.Id;
                    _clienteRepositorio.Adicionar(cliente);

                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar cliente: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                    cliente.UsuarioId = usuarioLogado.Id;

                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar cliente: {ex.Message}";
                return RedirectToAction("Index");
            }

            
        }
    }
}
