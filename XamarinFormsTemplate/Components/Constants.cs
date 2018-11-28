using System;
using System.Net;
using Amazon;

namespace GoetiaGuide.Core.Components {

    public static class ApplicationResourcesConstants {
        public static string CustomFontFamily = "CustomFontFamily";
    }

    public static class Constants {

        public const string COGNITO_IDENTITY_POOL_ID = "us-east-2:4e032ac5-5603-41b4-a903-6b7fe28bb8dd";
        public static RegionEndpoint COGNITO_REGION = RegionEndpoint.USEast2;
        public static RegionEndpoint DYNAMODB_REGION = RegionEndpoint.USEast2;

        public const string BUCKET_NAME = "goetia-images";
        public const HttpStatusCode NO_SUCH_BUCKET_STATUS_CODE = HttpStatusCode.NotFound;
        public const HttpStatusCode BUCKET_ACCESS_FORBIDDEN_STATUS_CODE = HttpStatusCode.Forbidden;
        public const HttpStatusCode BUCKET_REDIRECT_STATUS_CODE = HttpStatusCode.Redirect;

    }

    public static class MessagingCenterKeys {
        public const string RetreivedDetailItem = "RetreivedDetailItem";
    }
}
