using CrudApp.Filters;
using CrudApp.Models;
using CrudApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio) 
        { 
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir contato";
                }
               
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir contato: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar contato: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar contato: {ex.Message}";
                return RedirectToAction("Index");
            }

            
        }
    }
}
