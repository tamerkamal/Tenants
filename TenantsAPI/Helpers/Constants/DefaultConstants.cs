namespace TenantsAPI.Helper.Constants
{
    /// <summary>
    /// All hard-coded strings can be read as properties in the application
    /// </summary>
    public static class DefaultConstants
    {
        /// <summary>
        /// Prefix of the TenantsAPI libraries
        /// </summary>
        public const string TenantsAPI = nameof(TenantsAPI);

        /// <summary>
        /// Name of the TenantsAPI Repository library
        /// </summary>
        public const string TenantsAPIRepositoryLibraryName = TenantsAPI + ".Repository";

        /// <summary>
        /// Name of the TenantsAPI Service library
        /// </summary>
        public const string TenantsAPIServiceLibraryName = TenantsAPI + ".Service";

        /// <summary>
        /// Name of the TenantsAPI connection string
        /// </summary>
        public const string TenantsAPIConnection = nameof(TenantsAPIConnection);
    }
}