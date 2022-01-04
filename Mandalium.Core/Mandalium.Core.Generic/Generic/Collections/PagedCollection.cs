namespace Mandalium.Core.Generic.Collections
{
    public class PagedCollection<T> where T : class
    {
        public int TotalCount { get; init; }
        public ICollection<T> Collection { get; set; }

        public PagedCollection() {}

        public PagedCollection(int totalCount, ICollection<T> collection )
        {
            this.TotalCount = totalCount;  
            this.Collection = collection;
        }
    }
}
