﻿ using Azure.Data.Tables;
using IotHubStorage.Models;


namespace IotHubStorage.Repository
{
    public class TableStorage
    {
        public static string connectionString = "DefaultEndpointsProtocol=https;AccountName=iotstorageranjini;AccountKey=9NdKkAZ2DrGFR+l+58zoIAUD++CD1TvRLiPWi+B+MwWBuzCI/44R8tkPHg9piLk/EEr5B9DvJnPI+AStzzzZsQ==;EndpointSuffix=core.windows.net";

        public static async Task AddTable(string tableName)
        {
            var data = new TableServiceClient(connectionString);
            var client = data.GetTableClient(tableName);
            await client.CreateIfNotExistsAsync();
        }

        public static async Task<Details> UpdateTable(Details student,string tableName)
        {
            var data = new TableServiceClient(connectionString);
            var client = data.GetTableClient(tableName);
            await client.UpsertEntityAsync(student);
            return student;
        }

        public static async Task<Details> GetTableData(string tableName,string partitionKey, string rowKey)
        {
            var data = new TableServiceClient(connectionString);
            var client = data.GetTableClient(tableName);
            var tableData = await client.GetEntityAsync<Details>(partitionKey, rowKey);
            return tableData;
        }

        public static async Task<TableClient> GetTable(string tableName)
        {
            var data = new TableServiceClient(connectionString);
            var client = data.GetTableClient(tableName);
            return client;
        }

        public static async Task DeleteTableData(string tableName,string partitionKey, string rowKey)
        {
            var data = new TableServiceClient(connectionString);
            var client = data.GetTableClient(tableName);
            await client.DeleteEntityAsync(partitionKey, rowKey);
            return;
        }
        public static async Task DeleteTable(string tableName)
        {
            var data = new TableServiceClient(connectionString);
            await data.DeleteTableAsync(tableName);

        }

    }
}
