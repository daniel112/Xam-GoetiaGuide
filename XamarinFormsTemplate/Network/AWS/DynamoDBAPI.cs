using System;
using Amazon.DynamoDBv2;
using GoetiaGuide.Core.Components;

namespace GoetiaGuide.Core.Network.AWS {
    public class DynamoDBAPI : AWSBaseAPI {
        #region Variables
        private static AmazonDynamoDBClient _DynamoDBClient;
        public static AmazonDynamoDBClient DynamoDBClient {
            get {
                if (_DynamoDBClient == null) {
                    _DynamoDBClient = new AmazonDynamoDBClient(Credentials, Constants.DYNAMODB_REGION);
                }
                return _DynamoDBClient;
            }
        }
        #endregion

        #region Initialization
        public DynamoDBAPI() {
        }
        #endregion

        #region Private API

        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
