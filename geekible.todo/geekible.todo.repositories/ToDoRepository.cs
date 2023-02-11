using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using geekible.todo.models;
using geekible.todo.repositories.contracts;

namespace geekible.todo.repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly string _tableName;
        private readonly AmazonDynamoDBClient _client;
        private const string dateFormat = "yyyy-MM-dd";

        public ToDoRepository()
        {
            _client = DynamoDBClientConfig.DynamoDBClient;
            _tableName = "ToDos";
        }

        public async Task<ToDo> Create(ToDo toDo)
        {
            var item = new Dictionary<string, AttributeValue>
            {
                ["ID"] = new AttributeValue { S = toDo.ID },
                ["CreatedBy"] = new AttributeValue { S = toDo.CreatedBy },
                ["CreatedDateTime"] = new AttributeValue { S = DateTime.Now.ToString(dateFormat) },
                ["LastUpdatedBy"] = new AttributeValue { S = toDo.LastUpdatedBy },
                ["LastUpdatedDateTime"] = new AttributeValue { S = DateTime.Now.ToString(dateFormat) },
                ["AssignedByUserId"] = new AttributeValue { S = toDo.AssignedByUserId },
                ["AssignedToUserId"] = new AttributeValue { S = toDo.AssignedToUserId },
                ["AssignedDate"] = new AttributeValue { S = DateTime.Now.ToString(dateFormat) },
                ["StartDate"] = new AttributeValue { S = toDo.StartDate.ToString(dateFormat) },
                ["StartHour"] = new AttributeValue { N = toDo.StartHour.ToString() },
                ["StartMins"] = new AttributeValue { N = toDo.StartMins.ToString() },
                ["DueDate"] = new AttributeValue { S = toDo.DueDate.ToString(dateFormat)},
                ["DueHour"] = new AttributeValue { N = toDo.DueHour.ToString() },
                ["DueMins"] = new AttributeValue { N = toDo.DueMins.ToString() },
                ["Title"] = new AttributeValue { S = toDo.Title },
                ["Description"] = new AttributeValue { S = toDo.Description },
                ["StatusID"] = new AttributeValue { N = toDo.StatusID.ToString() }
            };

            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = item
            };

            var response = await _client.PutItemAsync(request);

            if (response.HttpStatusCode != HttpStatusCode.OK)
            {

            }
            

            return toDo;
        }
    }
}
