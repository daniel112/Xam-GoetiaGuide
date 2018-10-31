using System;
using Amazon.DynamoDBv2.DataModel;

namespace GoetiaGuide.Core.Models {

    [DynamoDBTable("Users")]
    public class User : ModelBase {
        [DynamoDBHashKey]   
        public string ID { get; set; }
        [DynamoDBProperty]
        public string Username { get; set; }
        [DynamoDBProperty]
        public string Password { get; set; }

        public User() {
        }

        public User(string username, string password) {
            this.Username = username;
            this.Password = password;
            this.ID = Guid.NewGuid().ToString();
        }
    }
}
