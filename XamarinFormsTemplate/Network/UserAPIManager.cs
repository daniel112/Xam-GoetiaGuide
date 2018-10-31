using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network.AWS;

namespace GoetiaGuide.Core.Network {
    public class UserAPIManager {

        #region Variables
        private DynamoDBContext _Context;

        #endregion

        #region Initialization
        public UserAPIManager() {
            _Context = new DynamoDBContext(DynamoDBAPI.DynamoDBClient);
        }
        #endregion

        #region Private API

        #endregion

        #region Public API
        public async Task<bool> SaveAsync<User>(User newUser) {
            DynamoDBOperationConfig config = new DynamoDBOperationConfig {
                IgnoreNullValues = true
            };
            try {
                await _Context.SaveAsync<User>(newUser, config);
                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

        #region Delegates

        #endregion
    }
}
