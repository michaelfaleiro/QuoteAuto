namespace QuoteAuto.Communication.Response.Shared;

public class ResponseJson<TData>
{
    public TData? Data { get; set; }
    public IList<string> Errors { get; set; }

    public ResponseJson(TData data)
    {
        Data = data;
        Errors = [];
    }
}