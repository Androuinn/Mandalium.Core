namespace Mandalium.Core.Generic.Collections
{
    public class PagedCollection<T> where T : class
    {
        public int TotalCount { get; init; }
        public ICollection<T> Collection { get; set; }
        public int PageCount => Math.Max((int)Math.Ceiling((decimal)TotalCount / PageSize), 1);
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PagedCollection()
        {
            Collection ??= new List<T>();
        }

        public PagedCollection(int totalCount, ICollection<T> collection)
        {
            this.TotalCount = totalCount;
            this.Collection = collection;
            this.PageSize = 10;
        }

        public PagedCollection(int totalCount, int pageSize, ICollection<T> collection)
        {
            this.TotalCount = totalCount;
            this.Collection = collection;
            this.PageSize = pageSize;
        }

        public PagedCollection(int totalCount, int pageSize, int currentPage, ICollection<T> collection)
        {
            this.TotalCount = totalCount;
            this.Collection = collection;
            this.PageSize = pageSize;
            this.CurrentPage = currentPage;
            if (CurrentPage > PageCount)
                CurrentPage = PageCount;

        }
    }
}
