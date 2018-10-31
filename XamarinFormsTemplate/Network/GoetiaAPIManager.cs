using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network.AWS;

namespace GoetiaGuide.Core.Network {
    public class GoetiaAPIManager {
        #region Variables
        private DynamoDBContext _Context;
        #endregion

        #region Initialization
        public GoetiaAPIManager() {
            _Context = new DynamoDBContext(DynamoDBAPI.DynamoDBClient);
        }
        #endregion

        #region Private API

        #endregion

        #region Public API
        public async Task<bool> SaveAsync(Goetia item) {
            DynamoDBOperationConfig config = new DynamoDBOperationConfig {
                IgnoreNullValues = true,
                Conversion = DynamoDBEntryConversion.V2 // allows duplicate (this is used for keyword
            };
            try {
                await _Context.SaveAsync(item, config);
                return true;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message + $" ID: {item.ID}");
                return false;
            }
        }

        public List<Goetia> GetAll() {

            return new List<Goetia>();
        }

        public Goetia GetByName(string name) {

            // TODO: update to send error message back
            Goetia goetia = new Goetia();
           try {
                List<ScanCondition> conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.Name), ScanOperator.Equal, name)
                };

                goetia = _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync().Result.FirstOrDefault();
                goetia.Success = true;
            } catch (AmazonDynamoDBException e) {
                Console.WriteLine(e.Message);
                goetia.Success = false;
            } catch (AmazonServiceException e) {
                Console.WriteLine(e.Message);
                goetia.Success = false;
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                goetia.Success = false;
            }

            return goetia;
        }

        public void testImage() {

            // Issue request and remember to dispose of the response
            try {
                if (S3API.BucketExist().Result) {
                    // TODO: get image via URL: ex {BUCKET_NAME}.s3.amazonaws.com/{IMAGE_NAME.png}

                }
                Console.WriteLine("gg");
            } catch (AmazonS3Exception e) {
                Console.WriteLine(e.Message);

            }

        }


        #endregion

        #region Delegates

        #endregion
    }
}
