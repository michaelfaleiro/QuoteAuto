using QuoteAuto.Core.ValueObject;

namespace QuoteAuto.Communication.Request.Quotes;

public record RegisterQuoteRequest(
    string Status,
    Vehicle Vehicle
    );