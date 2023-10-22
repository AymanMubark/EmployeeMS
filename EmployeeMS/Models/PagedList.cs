namespace EmployeeMS.Models
{
    public class PagedList<T>
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages { get; }
        public List<T> Data { get; }

        public PagedList(List<T> data, int pageNumber, int pageSize, int totalCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            Data = data;
        }
    }

}
