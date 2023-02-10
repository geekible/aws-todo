namespace geekible.todo.logic
{
    public class BuildEnvironment : contracts.IBuildEnvironment
    {
        private readonly geekible.todo.repositories.contracts.IDynamoDBTableMigrations _dynamoDbTableMigrations;

        public BuildEnvironment(geekible.todo.repositories.contracts.IDynamoDBTableMigrations dynamoDbTableMigration)
        {
            _dynamoDbTableMigrations = dynamoDbTableMigration;
        }

        public async Task Build()
        {
            await _dynamoDbTableMigrations.BuildDynamoDBTables();
        }
    }
}