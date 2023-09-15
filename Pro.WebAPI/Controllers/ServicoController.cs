using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pro.API.ViewModels;
using Pro.Business.Interfaces;
using Pro.Business.Models;

namespace Pro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : MainController
{
    private readonly IMapper _mapper;
    private readonly IServicoRepository _servicoRepository;

    public ServicoController(
        INotificador notificador,
        IMapper mapper,
        IServicoRepository servicoRepository) : base(notificador)
    {
        _mapper = mapper;
        _servicoRepository = servicoRepository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServicoViewModel>> GetById(int id)
    {
        var servico = await _servicoRepository.ObterPorId(id);

        if (servico == null) { return NotFound(); }

        return Ok(servico);
    }

    [HttpGet]
    public async Task<IEnumerable<ServicoViewModel>> List()
    {
        return _mapper.Map<IEnumerable<ServicoViewModel>>(await _servicoRepository.ObterTodos());
    }

    [HttpPost]
    [Route("add-service")]
    public async Task<ActionResult<ServicoViewModel>> Create(ServicoViewModel servicoViewModel, [FromServices] IMapper _mapper)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        await _servicoRepository.Adicionar(_mapper.Map<Servico>(servicoViewModel));

        return Ok(servicoViewModel);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServicoViewModel>> Atualizar(int id, ServicoViewModel servicoViewModel)
    {
        if (id != servicoViewModel.Id) { return BadRequest(); }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _servicoRepository.Atualizar(_mapper.Map<Servico>(servicoViewModel));

        return Ok(servicoViewModel);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ServicoViewModel>> Excluir(int id)
    {
        //var servicoViewModel = await _servicoRepository.ObterPorId(id);

        //if (servicoViewModel == null) return NotFound();

        await _servicoRepository.Remover(id);

        //return CustomResponse(servicoViewModel);
        return Ok();
    }
}
