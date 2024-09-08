
namespace TrafficMonitor.Common.Models
{
    public class Paging
    {
        /// <summary>
        /// Number of pages
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// Total item count
        /// </summary>
        public int TotalItemCount { get; set; }
        /// <summary>
        /// Current page number
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Is there a previous page
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        /// Is there a next page
        /// </summary>
        public bool HasNextPage { get; set; }
        /// <summary>
        /// Are we on the first page
        /// </summary>
        public bool IsFirstPage { get; set; }
        /// <summary>
        /// Are we on the last page
        /// </summary>
        public bool IsLastPage { get; set; }
        /// <summary>
        /// Index of first number on page
        /// </summary>
        public int FirstItemOnPage { get; set; }
        /// <summary>
        /// Index of last number on page
        /// </summary>
        public int LastItemOnPage { get; set; }
    }
}
