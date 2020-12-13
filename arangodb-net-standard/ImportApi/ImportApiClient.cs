using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ArangoDBNetStandard.DocumentApi.Models;
using ArangoDBNetStandard.ImportApi.Models;
using ArangoDBNetStandard.Serialization;
using ArangoDBNetStandard.Transport;


namespace ArangoDBNetStandard.ImportApi
{
    /// <summary>
    /// Provides access to ArangoDB Import API.
    /// </summary>
    public class ImportApiClient : ApiClientBase, IImportApiClient
    {
        /// <summary>
        /// The transport client used to communicate with the ArangoDB host.
        /// </summary>
        protected IApiClientTransport _client;

        /// <summary>
        /// The root path of the API.
        /// </summary>
        protected readonly string _ImportApiPath = "_api/Import";

        /// <summary>
        /// Create an instance of <see cref="ImportApiClient"/>
        /// using the provided transport layer and the default JSON serialization.
        /// </summary>
        /// <param name="client"></param>
        public ImportApiClient(IApiClientTransport client)
            : base(new JsonNetApiClientSerialization())
        {
            _client = client;
        }

        /// <summary>
        /// Create an instance of <see cref="ImportApiClient"/>
        /// using the provided transport and serialization layers.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="serializer"></param>
        public ImportApiClient(IApiClientTransport client, IApiClientSerialization serializer)
            : base(serializer)
        {
            _client = client;
        }

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
        public virtual async Task<PostImportDocumentsResponse<T>> PostImportDocumentsAsync<T>(
            string collectionName,
            IList<T> documents,
            PostImportDocumentsQuery query = null,
            ApiClientSerializationOptions serializationOptions = null
            )
        {
            string uriString = _ImportApiPath + "#document/" + WebUtility.UrlEncode(collectionName);
            if (query != null)
            {
                uriString += "?" + query.ToQueryString();
            }
            var content = GetContent(documents, serializationOptions);
            using (var response = await _client.PostAsync(uriString, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    if (query != null && query.Silent.HasValue && query.Silent.Value)
                    {
                        return PostImportDocumentsResponse<T>.Empty();
                    }
                    else
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        return DeserializeJsonFromStream<PostImportDocumentsResponse<T>>(stream);
                    }
                }
                throw await GetApiErrorException(response);
            }
        }

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
        public virtual async Task<PostImportJsonResponse<T>> PostImportJsonAsync<T>(
            string collectionName,
            IList<T> documents,
            PostImportJsonQuery query = null,
            ApiClientSerializationOptions serializationOptions = null)
        {
            string uriString = _ImportApiPath + "#json/" + WebUtility.UrlEncode(collectionName);
            if (query != null)
            {
                uriString += "?" + query.ToQueryString();
            }
            var content = GetContent(documents, serializationOptions);
            using (var response = await _client.PostAsync(uriString, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    if (query != null && query.Silent.HasValue && query.Silent.Value)
                    {
                        return PostImportJsonResponse<T>.Empty();
                    }
                    else
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        return DeserializeJsonFromStream<PostImportJsonResponse<T>>(stream);
                    }
                }
                throw await GetApiErrorException(response);
            }
        }
    }
}
