using System.Net;

namespace ArangoDBNetStandard.ImportApi.Models
{
    /// <summary>
    /// Response from ArangoDB after executing a Import.
    /// </summary>
    /// <typeparam name="T">Type used to deserialize the returned object from the Import function.</typeparam>
    public class PostImportResponse<T>
    {
        /// <summary>
        /// Whether the request resulted in error.
        /// </summary>
        public bool Error { get; set; }

        /// <summary>
        /// The ArangoDB result code.
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// Deserialized result from the Import function.
        /// </summary>
        public T Result { get; set; }
    }
}