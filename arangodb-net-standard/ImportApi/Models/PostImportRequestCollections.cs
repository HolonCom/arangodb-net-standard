using System.Collections.Generic;

namespace ArangoDBNetStandard.ImportApi.Models
{
    /// <summary>
    /// Represents the collections object passed in an ArangoDB Import request.
    /// </summary>
    public class PostImportRequestCollections
    {
        /// <summary>
        /// The list of read-only collections involved in a Import.
        /// </summary>
        public IList<string> Read { get; set; }

        /// <summary>
        /// The list of write collection involved in a Import.
        /// </summary>
        public IList<string> Write { get; set; }

        /// <summary>
        /// Collections for which to obtain exclusive locks during a Import.
        /// </summary>
        public IList<string> Exclusive { get; set; }
    }
}