using System.Collections.Generic;

namespace ArangoDBNetStandard.ImportApi.Models
{
    /// <summary>
    /// Options used when calling ArangoDB POST import endpoint
    /// to create one or multiple Import.
    /// </summary>
    public class PostImportJsonQuery
    {
        /// <summary>
        /// Determines how the body of the request will be interpreted. type can have the following values:
        /// - documents: when this type is used, each line in the request body is expected to be an individual JSON-encoded document. Multiple JSON objects in the request body need to be separated by newlines.
        /// - list: when this type is used, the request body must contain a single JSON-encoded array of individual objects to import.
        /// - auto: if set, this will automatically determine the body type (either documents or list).
        /// </summary>
        public string Type { get; set; }

        public string Collection { get; set; }

        /// <summary>
        /// An optional prefix for the values in _from attributes.
        /// If specified, the value is automatically prepended to each _from input value.
        /// This allows specifying just the keys for _from.
        /// </summary>
        public string FromPrefix { get; set; }

        /// <summary>
        /// An optional prefix for the values in _to attributes.
        /// If specified, the value is automatically prepended to each _to input value.
        /// This allows specifying just the keys for _to.
        /// </summary>
        public string ToPrefix { get; set; }

        /// <summary>
        /// If this parameter has a value of true or yes,
        /// then all data in the collection will be removed prior to the import.
        /// Note that any existing index definitions will be preserved.
        /// </summary>
        public bool? Overwrite { get; set; }

        /// <summary>
        /// Wait until documents have been synced to disk before returning.
        /// </summary>
        public bool? WaitForSync { get; set; }

        /// <summary>
        /// Controls what action is carried out in case of a unique key constraint violation. Possible values are:
        /// - error: this will not import the current document because of the unique key constraint violation.This is the default setting.
        /// - update: this will update an existing document in the database with the data specified in the request.Attributes of the existing document that are not present in the request will be preserved.
        /// - replace: this will replace an existing document in the database with the data specified in the request.
        /// - ignore: this will not update an existing document and simply ignore the error caused by the unique key constraint violation.
        /// Note that update, replace and ignore will only work when the import document in the request contains the _key attribute.
        /// update and replace may also fail because of secondary unique key constraint violations.
        /// </summary>
        public string OnDuplicate { get; set; }

        /// <summary>
        /// If set to true or yes, it will make the whole import fail
        /// if any error occurs.Otherwise the import will continue
        /// even if some documents cannot be imported.
        /// </summary>
        public bool? Complete { get; set; }

        /// <summary>
        /// If set to true or yes, the result will include an attribute details with details about documents that could not be imported.
        /// </summary>
        public bool? Details { get; set; }


        /// <summary>
        /// Get the set of options in a format suited to a URL query string.
        /// </summary>
        /// <returns></returns>
        internal string ToQueryString()
        {
            List<string> query = new List<string>();
            if (Type != null)
            {
                query.Add("type=" + Type.ToLower());
            }
            if (Collection != null)
            {
                query.Add("collection=" + Collection);
            }
            if (FromPrefix != null)
            {
                query.Add("fromPrefix=" + FromPrefix.ToLower());
            }
            if (ToPrefix != null)
            {
                query.Add("toPrefix=" + ToPrefix.ToLower());
            }
            if (WaitForSync != null)
            {
                query.Add("waitForSync=" + WaitForSync.ToString().ToLower());
            }
            if (OnDuplicate != null)
            {
                query.Add("onDuplicate=" + OnDuplicate.ToLower());
            }
            if (Complete != null)
            {
                query.Add("complete=" + Complete.ToString().ToLower());
            }
            if (Details != null)
            {
                query.Add("details=" + Details.ToString().ToLower());
            }
            return string.Join("&", query);
        }
    }
}