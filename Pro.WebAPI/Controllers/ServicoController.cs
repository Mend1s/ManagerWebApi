using Microsoft.AspNetCore.Mvc;
using Pro.Business.Interfaces;

namespace Pro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicoController : MainController
{
    public ServicoController(INotificador notificador) : base(notificador)
    {
    }
}
