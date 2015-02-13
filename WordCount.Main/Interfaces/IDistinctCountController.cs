namespace WordCount.Main.Interfaces
{
    public interface IDistinctCountController
    {
        /// <summary>
        /// Entry point for the entire component, populates the word map
        /// </summary>
        void Execute();
        
        /// <summary>
        /// Ensure you have called execute first to populate the word map
        /// </summary>
        /// <returns>A report listing distinct words and a count of their occurences in the text file</returns>
        string Report();

        /// <summary>
        /// Exposed for testing/mocking purposes only, do not call directly
        /// </summary>
        void PopulateDistinctWordsMap();
    }
}