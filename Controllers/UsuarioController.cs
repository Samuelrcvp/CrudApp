﻿using CrudApp.Filters;
using CrudApp.Helper;
using CrudApp.Models;
using CrudApp.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [PaginaParaUsuarioLogado]
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IClienteRepositorio _clienteRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao,
                                  IClienteRepositorio clienteRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _clienteRepositorio = clienteRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário deletado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao excluir usuário";
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir usuário: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ListarClientesPorUsuarioId(int id)
        {
            List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos(id);
            return PartialView("_ClientesUsuario", clientes);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };
                    _sessao.RemoverSessaoDoUsuario();
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    _sessao.CriarSessaoDoUsuario(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao editar usuário: {ex.Message}";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar usuário: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
