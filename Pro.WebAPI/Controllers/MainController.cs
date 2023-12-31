﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pro.Business.Interfaces;
using Pro.Business.Notificacoes;

namespace Pro.API.Controllers;

[ApiController]
public abstract partial class MainController : ControllerBase
{
    private readonly INotificador _notificador;
    //public readonly IUser AppUser;

    protected Guid UsuarioId { get; set; }
    protected bool UsuarioAutenticado { get; set; }

    // validação de notificacao de erro

    // validação de modelstate

    // validação da operação de negócios


    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
        //AppUser = appUser;

        //if (appUser.IsAuthenticated())
        //{
        //    UsuarioId = appUser.GetUserId();
        //    UsuarioAutenticado = true;
        //}
    }

    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacao();
    }

    protected ActionResult CustomResponse(object result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
        return CustomResponse();
    }

    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(errorMsg);
        }
    }

    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}
