using System;
using Amazon.DynamoDBv2.DataModel;

namespace GoetiaGuide.Core.Models {
    public class ModelBase {
        [DynamoDBIgnore]
        public string Message { get; set; }
        [DynamoDBIgnore]
        public bool Success { get; set; }
    }
}
