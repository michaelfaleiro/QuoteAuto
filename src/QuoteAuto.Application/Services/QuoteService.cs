using Microsoft.Extensions.DependencyInjection;
using QuoteAuto.Application.UseCase.Quotes.GetAll;
using QuoteAuto.Application.UseCase.Quotes.GetById;
using QuoteAuto.Application.UseCase.Quotes.QuoteProducts.AddQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.QuoteProducts.RemoveQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.Register;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.AddSupplierPriceOnQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.DeselectSupplierPriceOnQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.RemoveSupplierPriceOnQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.SupplierPrices.SelectSupplierPriceOnQuoteProduct;
using QuoteAuto.Application.UseCase.Quotes.Update;

namespace QuoteAuto.Application.Services;

public static class QuoteService
{
    public static IServiceCollection AddQuoteService(this IServiceCollection services)
    {
        services.AddScoped<RegisterQuoteUseCase>();
        services.AddScoped<GetAllQuotesUseCase>();
        services.AddScoped<GetQuoteByIdUseCase>();
        services.AddScoped<UpdateQuoteUseCase>();
        services.AddScoped<AddQuoteProductOnQuoteUseCase>();
        services.AddScoped<RemoveQuoteProductOnQuoteUseCase>();
        services.AddScoped<AddSupplierPriceOnQuoteProductUseCase>();
        services.AddScoped<RemoveSupplierPriceOnQuoteUseCase>();
        services.AddScoped<SelectSupplierPriceOnQuoteProductUseCase>();
        services.AddScoped<DeselectSupplierPriceOnQuoteProductUseCase>();

        return services;
    }
    
}