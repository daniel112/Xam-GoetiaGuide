﻿using System;
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

            // TODO: update to send error message back
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

            // TODO: update to send error message back
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
                    new ScanCondition(nameof(Goetia.Keywords), ScanOperator.Contains, searchValue),
                };
                // search in Keywords col
                var results = await _Context.ScanAsync<Goetia>(conditions).GetRemainingAsync();

                // search in name col
                if (results.Count == 0) {
                    conditions = new List<ScanCondition> {
                    new ScanCondition(nameof(Goetia.Keywords), ScanOperator.Contains, searchValue),
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

        // TODO: doesnt work
        public async Task<List<Goetia>> PerformSearchQuery2(string searchvalue) {

            List<Goetia> goetias = new List<Goetia>();
            AmazonDynamoDBClient client = DynamoDBAPI.DynamoDBClient;

            try {
                var condition1 = new Condition {
                    AttributeValueList = new List<AttributeValue> {
                        new AttributeValue(searchvalue)
                    },
                    ComparisonOperator = ComparisonOperator.CONTAINS
                };

                ScanRequest scanRequest = new ScanRequest("Goetia") {
                    ConditionalOperator = ConditionalOperator.OR,
                    ScanFilter = new Dictionary<string, Condition> {
                        {  "Keywords", condition1 },
                        {  "Name", condition1 },

                    }
                };
                var response = await DynamoDBAPI.DynamoDBClient.ScanAsync(scanRequest);

                foreach (Dictionary<string, AttributeValue> item in response.Items) {
                    // Process the result.
                    Console.WriteLine(item);
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }


            return goetias;

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
