using Microsoft.AspNetCore.Mvc;
using QuoteAuto.Application.UseCase.Quotes.GetAll;
using QuoteAuto.Application.UseCase.Quotes.GetById;
using QuoteAuto.Application.UseCase.Quotes.QuoteProducts.AddQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.Register;
using QuoteAuto.Application.UseCase.Quotes.Update;
using QuoteAuto.Communication.Request.Quotes;

namespace QuoteAuto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterQuote(
        [FromServices]RegisterQuoteUseCase useCase,
        [FromBody] RegisterQuoteRequest request)
    => Created(string.Empty, await useCase.ExecuteAsync(request));
    
    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetQuoteByIdUseCase useCase,
        [FromRoute] string id)
    => Ok(await useCase.ExecuteAsync(id));
    
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromServices] GetAllQuotesUseCase useCase,
        [FromQuery]int page = 1,
        [FromQuery]int pageSize = 10)
    => Ok(await useCase.ExecuteAsync(page, pageSize));

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateQuote(
        string id,
        [FromBody] UpdateQuoteRequest request,
        [FromServices] UpdateQuoteUseCase useCase) 
    => Ok(await useCase.ExecuteAsync(id, request));

    [HttpPost("{id:length(24)}/products")]
    public async Task<IActionResult> AddProductToQuote(
        [FromRoute] string id,
        [FromBody] AddQuoteProductOnQuoteRequest request,
        [FromServices] AddQuoteProductOnQuoteUseCase useCase)
        => Ok(await useCase.ExecuteAsync(id, request));

}