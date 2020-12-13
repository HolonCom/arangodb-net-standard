using System.Collections.Generic;
using ArangoDBNetStandard.ImportApi.Models;
using System.Threading.Tasks;
using ArangoDBNetStandard.Serialization;

namespace ArangoDBNetStandard.ImportApi
{
    /// <summary>
    /// Defines a client to access the ArangoDB Imports API.
    /// </summary>
    public interface IImportApiClient
    {
        /// <summary>
        /// Post multiple documents in a single request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documents"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <returns></returns>
        Task<PostImportDocumentsResponse<T>> PostImportDocumentsAsync<T>(
            string collectionName,
            IList<T> documents,
            PostImportDocumentsQuery query = null,
            ApiClientSerializationOptions serializationOptions = null);

        /// <summary>
        /// Post multiple json documents in a single request.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <param name="documents"></param>
        /// <param name="query"></param>
        /// <param name="serializationOptions">The serialization options. When the value is null the
        /// the serialization options should be provided by the serializer, otherwise the given options should be used.</param>
        /// <returns></returns>
        Task<PostImportJsonResponse<T>> PostImportJsonAsync<T>(
            string collectionName,
            IList<T> documents,
            PostImportJsonQuery query = null,
            ApiClientSerializationOptions serializationOptions = null);
    }
}
