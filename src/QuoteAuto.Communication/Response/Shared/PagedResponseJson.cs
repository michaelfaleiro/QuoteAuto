namespace QuoteAuto.Communication.Response.Shared;

public class PagedResponseJson<TData>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public IEnumerable<TData> Data { get; set; }

    public PagedResponseJson(int pageNumber, int pageSize, int totalCount, IEnumerable<TData> data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        Data = data;
    }
}