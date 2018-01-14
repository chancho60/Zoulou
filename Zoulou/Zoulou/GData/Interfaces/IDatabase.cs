namespace Zoulou.GData.Interfaces {
    /// <summary>
    /// Spreadsheet document
    /// </summary>
    public interface IDatabase {
        /// <summary>
        /// Creates a new worksheet in this document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        void CreateTable(string Name);

        /// <summary>
        /// Gets an existing worksheet in this document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns>Searched worksheet or null if not found</returns>
        ITable<T> GetTable<T>(string Name, string Range) where T : new();

        /// <summary>
        /// Deletes this spreadsheet document
        /// </summary>
        void Delete();
    }
}
