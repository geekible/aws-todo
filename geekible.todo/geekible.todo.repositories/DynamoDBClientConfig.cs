using Amazon;
using Amazon.DynamoDBv2;

namespace geekible.todo.repositories
{
    public static class DynamoDBClientConfig
    {
        public static AmazonDynamoDBClient DynamoDBClient
        {
            get
            {
                var clientConfig = new AmazonDynamoDBConfig();
                clientConfig.RegionEndpoint = RegionEndpoint.EUWest2;
                var client = new AmazonDynamoDBClient(clientConfig);
                return client;
            }
        }
    }
}