using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using GoetiaGuide.Core.Components;

namespace GoetiaGuide.Core.Network.AWS {
    public class S3API : AWSBaseAPI {

        #region Variables
        private static AmazonS3Client _AS3Client;
        public static AmazonS3Client AS3Client {
            get {
                if (_AS3Client == null) {
                    _AS3Client = new AmazonS3Client(Credentials, Constants.DYNAMODB_REGION);
                }
                return _AS3Client;
            }
        }
        #endregion
        
        #region Initialization
        public S3API() {
        }
        #endregion

        #region Private API

        #endregion

        #region Public API
        /// <summary>
        /// Check if the main bucket exists
        /// </summary>
        /// <returns>The exist.</returns>
        public static async Task<bool> BucketExist() {
            try {
                var response = await AS3Client.ListObjectsAsync(new ListObjectsRequest() {
                    BucketName = Constants.BUCKET_NAME.ToLowerInvariant(),
                    MaxKeys = 0
                }).ConfigureAwait(false);
                return true;
            } catch (AmazonS3Exception e) {
                if ((e.StatusCode.Equals(Constants.BUCKET_REDIRECT_STATUS_CODE)) || e.StatusCode.Equals(Constants.BUCKET_ACCESS_FORBIDDEN_STATUS_CODE)) {
                    //bucket exists if there is a redirect errror or forbidden error
                    return true;
                } else if (e.StatusCode.Equals(Constants.NO_SUCH_BUCKET_STATUS_CODE)) {
                    return false;
                } else {
                    throw e;
                }
            }
        }
        #endregion

        #region Delegates

        #endregion
    }
}
