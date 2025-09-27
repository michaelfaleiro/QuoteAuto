using Microsoft.AspNetCore.Mvc;
using QuoteAuto.Application.UseCase.Quotes.GetAll;
using QuoteAuto.Application.UseCase.Quotes.GetById;
using QuoteAuto.Application.UseCase.Quotes.QuoteProducts.AddQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.QuoteProducts.RemoveQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.Register;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.AddSupplierPriceOnQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.RemoveSupplierPriceOnQuoteProduct;
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
    {
        await useCase.ExecuteAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{quoteId:length(24)}/products/{quoteProductId:length(24)}")]
    public async Task<IActionResult> RemoveProductFromQuote(
        [FromRoute] string quoteId,
        [FromRoute] string quoteProductId,
        [FromServices] RemoveQuoteProductOnQuoteUseCase useCase)
    {
        await useCase.ExecuteAsync(quoteId, quoteProductId);
        return NoContent();
    }

    [HttpPost("{quoteId:length(24)}/products/{quoteProductId:length(24)}/suppliePrices")]
    public async Task<IActionResult> AddSupplierPriceToQuoteProduct(
        [FromRoute] string quoteId,
        [FromRoute] string quoteProductId,
        [FromBody] AddSupplierPriceOnQuoteProductRequest request,
        [FromServices] AddSupplierPriceOnQuoteProductUseCase useCase)
    {
        await useCase.ExecuteAsync(quoteId, quoteProductId, request);
        return NoContent();
    }

    [HttpDelete(
        "{quoteId:length(24)}/products/{quoteProductId:length(24)}/supplierPrices/{supplierPriceId:length(24)}")]
    public async Task<IActionResult> RemoveSupplierPriceFromQuoteProduct(
        [FromRoute] string quoteId,
        [FromRoute] string quoteProductId,
        [FromRoute] string supplierPriceId,
        [FromServices] RemoveSupplierPriceOnQuoteUseCase useCase)
    {
        await useCase.ExecuteAsync(quoteId, quoteProductId, supplierPriceId);
        return NoContent();
    }
    
}