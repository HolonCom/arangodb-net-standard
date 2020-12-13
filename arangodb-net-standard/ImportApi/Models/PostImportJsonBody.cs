using System.Collections.Generic;

namespace ArangoDBNetStandard.ImportApi.Models
{
    /// <summary>
    /// Represents information required to make a Import request to ArangoDB.
    /// </summary>
    public class PostImportJsonBody
    {
        /// <summary>
        /// JavaScript function describing the Import action.
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Collections configuration for the Import.
        /// </summary>
        public PostImportRequestCollections Collections { get; set; }

        /// <summary>
        /// The maximum Import size before making intermediate commits (RocksDB only).
        /// </summary>
        public long? MaxImportSize { get; set; }

        /// <summary>
        /// The maximum time to wait for required locks to be released, before the Import times out.
        /// </summary>
        public long? LockTimeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool? WaitForSync { get; set; }

        /// <summary>
        /// Parameters to be passed into the Import JavaScript function defined by <see cref="Action"/>.
        /// </summary>
        public Dictionary<string, object> Params { get; set; }
    }
}