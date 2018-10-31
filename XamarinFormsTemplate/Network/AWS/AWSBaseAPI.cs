using System;
using System.Threading.Tasks;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Amazon.S3.Model;
using GoetiaGuide.Core.Components;

namespace GoetiaGuide.Core.Network {
    public class AWSBaseAPI {
        #region Variables
        private static CognitoAWSCredentials _credentials;
        protected static CognitoAWSCredentials Credentials {
            get {
                if (_credentials == null)
                    _credentials = new CognitoAWSCredentials(Constants.COGNITO_IDENTITY_POOL_ID, Constants.COGNITO_REGION);
                return _credentials;
            }
        }

        #endregion

        #region Initialization
        public AWSBaseAPI() {
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
