using QuoteAuto.Core.ValueObject;

namespace QuoteAuto.Communication.Request.Quotes;

public record UpdateQuoteRequest(
    string Status,
    Vehicle Vehicle
    ) : RegisterQuoteRequest(Status, Vehicle);