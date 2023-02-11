using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace geekible.todo.repositories
{
    public class DynamoDBTableMigrations : contracts.IDynamoDBTableMigrations
    {
        private readonly AmazonDynamoDBClient _client;

        public DynamoDBTableMigrations()
        {
            this._client = DynamoDBClientConfig.DynamoDBClient;
        }

        private async Task CreateTable(string tableName)
        {
            try
            {
                var response = await this._client.CreateTableAsync(new CreateTableRequest
                {
                    TableName = tableName,
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition
                        {
                            AttributeName = "ID",
                            AttributeType = "S"
                        },
                    },
                    KeySchema = new List<KeySchemaElement>()
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "ID",
                            KeyType = "HASH"
                        }
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 5,
                        WriteCapacityUnits = 5,
                    }
                });

                var result = response.HttpStatusCode;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<List<string>> GetDynamoDBTables()
        {
            var tables = new List<string>();
            string? lastTableNameEvaluated = null;
            do
            {
                var request = new ListTablesRequest
                {
                    Limit = 10,
                    ExclusiveStartTableName = lastTableNameEvaluated
                };

                var response = await this._client.ListTablesAsync(request);
                foreach (var name in response.TableNames)
                {
                    tables.Add(name);
                }
            } while (lastTableNameEvaluated != null);

            return tables;
        }

        public async Task BuildDynamoDBTables()
        {
            var tables = await GetDynamoDBTables();
            var tableDefinitions = new List<AttributeDefinition>();

            if (!tables.Contains("todo", StringComparer.OrdinalIgnoreCase))
            {
                tableDefinitions = new List<AttributeDefinition>();
                var toDoTable = new todo.models.ToDo();

                await CreateTable("ToDos");
            }
        }
    }
}
