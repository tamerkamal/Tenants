namespace Base.Helpers.Constants
{
    /// <summary>
    /// All hard-coded strings can be read as properties in the application
    /// </summary>
    public static class TenantsConstants
    {
        /// <summary>
        /// Prefix of the Tenants libraries
        /// </summary>
        public const string Tenants = nameof(Tenants);

        /// <summary>
        /// Name of the Tenants Repository library
        /// </summary>
        public const string TenantsRepositoryLibraryName = Tenants + ".Repository";

        /// <summary>
        /// Name of the Tenants Service library
        /// </summary>
        public const string TenantsServiceLibraryName = Tenants + ".Service";

        /// <summary>
        /// Name of the Tenants connection string
        /// </summary>
        public const string TenantsConnection = nameof(TenantsConnection);
    }
}