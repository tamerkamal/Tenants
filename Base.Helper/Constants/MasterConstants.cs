namespace Base.Helpers.Constants
{
    /// <summary>
    /// All hard-coded strings can be read as properties in the application
    /// </summary>
    public static class MasterConstants
    {
        /// <summary>
        /// Prefix of the Master libraries
        /// </summary>
        public const string Master = nameof(Master);

        /// <summary>
        /// Name of the Master Repository library
        /// </summary>
        public const string RepositoryLibraryName = Master + ".Repository";

        /// <summary>
        /// Name of the Master Service library
        /// </summary>
        public const string ServiceLibraryName = Master + ".Service";    
    }
}