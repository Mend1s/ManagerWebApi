using jsreport.Shared;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Pro.Business.Interfaces;

namespace Pro.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConverterHTML : MainController
{
    private readonly IRenderService _render;

    public ConverterHTML(
        INotificador notificador,
        IRenderService render
        ) : base(notificador)
    {
        _render = render;
    }

    [HttpPost]
    public async Task<IActionResult> Convert([FromForm] string html)
    {
        var report = await _render.RenderAsync(new RenderRequest
        {
            Template = new Template
            {
                Recipe = Recipe.ChromePdf,
                Engine = Engine.JsRender,
                Content = html
            }
        });

        return File(report.Content, "application/pdf", "file.pdf");
    }
}
