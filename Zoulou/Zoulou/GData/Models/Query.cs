namespace Zoulou.GData.Models {
    /// <summary>
    /// Query parameters
    /// </summary>
    public class Query {
        /// <summary>
        /// Start index, for paging
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Record count to fetch, for paging
        /// </summary>
        public int Count { get; set; }
    }
}