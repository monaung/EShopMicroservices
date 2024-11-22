namespace BuildingBlocks.Pagination
{
    public class PaginatedResult<TEnity>
        (int pageIndex, int pageSize, long count, IEnumerable<TEnity> data)
    {
        public int PageIndex { get; private set; } = pageIndex;
        public int PageSize { get; } = pageSize;
        public long Count { get; } = count;
        public IEnumerable<TEnity> Data { get; } = data;
    }
}
