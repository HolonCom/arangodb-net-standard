﻿using ArangoDBNetStandard.DatabaseApi.Models;
using System.Threading.Tasks;

namespace ArangoDBNetStandard.DatabaseApi
{
    /// <summary>
    /// Defines a client for the ArangoDB Database API.
    /// </summary>
    public interface IDatabaseApiClient
    {
        /// <summary>
        /// Creates a new database.
        /// (Only possible from within the _system database)
        /// </summary>
        /// <param name="request">The parameters required by this endpoint.</param>
        /// <returns></returns>
        Task<PostDatabaseResponse> PostDatabaseAsync(PostDatabaseBody request);

        /// <summary>
        /// Delete a database. Dropping a database is only possible from within the _system database.
        /// The _system database itself cannot be dropped.
        /// DELETE /_api/database/{database-name}
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        Task<DeleteDatabaseResponse> DeleteDatabaseAsync(string databaseName);

        /// <summary>
        /// Retrieves the list of all existing databases.
        /// (Only possible from within the _system database)
        /// </summary>
        /// <remarks>
        /// You should use <see cref="GetUserDatabasesAsync"/> to fetch the list of the databases
        /// available for the current user.
        /// </remarks>
        /// <returns></returns>
        Task<GetDatabasesResponse> GetDatabasesAsync();

        /// <summary>
        /// Retrieves the list of all databases the current user can access.
        /// </summary>
        /// <returns></returns>
        Task<GetDatabasesResponse> GetUserDatabasesAsync();

        /// <summary>
        /// Retrieves information about the current database.
        /// </summary>
        /// <returns></returns>
        Task<GetCurrentDatabaseInfoResponse> GetCurrentDatabaseInfoAsync();
    }
}
