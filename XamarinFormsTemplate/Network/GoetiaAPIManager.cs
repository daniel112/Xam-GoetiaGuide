using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
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

        public async Task<Goetia> GetByNameAsync(string name) {

            Goetia goetia = new Goetia();
            try {
                List<ScanCondition> conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.Name), ScanOperator.Equal, name)
                };

                var results = await _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync();
                goetia = results.FirstOrDefault();
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
                goetia.Message = e.Message;
            }

            return goetia;
        }

        public async Task<Goetia> GetByIDAsync(int id) {

            Goetia goetia = new Goetia();
            try {
                List<ScanCondition> conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.ID), ScanOperator.Equal, id)
                };

                var results = await _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync();
                goetia = results.FirstOrDefault();
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
                goetia.Message = e.Message;
            }

            return goetia;
        }

        public async Task<List<Goetia>> PerformSearchQuery(string searchValue) {

            List<Goetia> goetias = new List<Goetia>();
            try {
                List<ScanCondition> conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.Keywords), ScanOperator.Contains, searchValue.ToLower()),
                };
                // search in Keywords col
                var results = await _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync();

                // search in name col
                if (results.Count == 0) {
                    conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.Name), ScanOperator.Contains, searchValue),
                };
                    results = await _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync();
                }
                results.Select(item => { item.Success = true; return item; }).ToList();
                goetias = results;

            } catch (AmazonDynamoDBException e) {
                Console.WriteLine(e.Message);
            } catch (AmazonServiceException e) {
                Console.WriteLine(e.Message);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            return goetias;
        }


        public async Task<bool> UpdateItem(int id, List<string> newList) {

            var client = DynamoDBAPI.DynamoDBClient;

            var request = new UpdateItemRequest {
                TableName = "Goetias",
                Key = new Dictionary<string, AttributeValue>() { { "ID", new AttributeValue { N = id.ToString() } } },
                ExpressionAttributeNames = new Dictionary<string, string>()
                            {
                    {"#P", "Keywords"},

                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
                            {
                    {":p",new AttributeValue {SS = newList } }
                },


                UpdateExpression = "SET #P = :p"
            };
            try {
                var response = await client.UpdateItemAsync(request);
                Console.WriteLine("Success");
            } catch (Exception ex) {
                Console.WriteLine($"unsuccessful: {id} : {ex.Message}");
            }

            return true;
        }

        #endregion

        #region Delegates

        #endregion
    }
}
