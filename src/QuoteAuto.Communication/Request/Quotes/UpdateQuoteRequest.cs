namespace QuoteAuto.Communication.Request.Quotes;

public record UpdateQuoteRequest(
    string Status
    ) : RegisterQuoteRequest(Status);