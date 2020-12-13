using System.Collections.Generic;

namespace ArangoDBNetStandard.ImportApi.Models
{
    /// <summary>
    /// Represents the response for creating multiple documents.
    /// </summary>
    /// <typeparam name="T">The type of the deserialized new/old document object when requested.</typeparam>
    public class PostImportJsonResponse<T> : List<PostImportResponse<T>>
    {
        /// <summary>
        /// Creates an instance of <see cref="PostImportDocumentsResponse{T}"/>.
        /// </summary>
        public PostImportJsonResponse()
        {
        }

        private PostImportJsonResponse(int capacity)
            : base(capacity)
        {
        }

        /// <summary>
        /// Creates an empty response.
        /// This is used when <see cref="PostImportDocumentsQuery.Silent"/> is true.
        /// </summary>
        /// <returns></returns>
        public static PostImportJsonResponse<T> Empty()
        {
            return new PostImportJsonResponse<T>(0);
        }
    }
}