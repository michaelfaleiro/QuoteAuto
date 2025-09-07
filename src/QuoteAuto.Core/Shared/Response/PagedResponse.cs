namespace QuoteAuto.Core.Shared.Response;

public class PagedResponse<TData>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public IEnumerable<TData> Data { get; set; }

    public PagedResponse(int pageNumber, int pageSize, int totalCount, IEnumerable<TData> data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        Data = data;
    }
}