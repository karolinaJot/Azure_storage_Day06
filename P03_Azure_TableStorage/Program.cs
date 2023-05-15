using Azure;
using Azure.Data.Tables;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";

string tableName = "Persons";

var tableClient = new TableClient(connectionString, tableName);


// Create a table in your storage account
await tableClient.CreateIfNotExistsAsync();
// Insert an entity into the table
//var entity = new TableEntity("volleyball", "player7")
// {
//	{ "firstname", "Ale" },
//	{ "secondname", "New" },
//	{ "phone", "333444555" },

// };
//await tableClient.AddEntityAsync(entity);
//Console.WriteLine("Entity added to the table.");


// Query entities from the table
//var entity = new TableEntity("volleyball", "player7");
//string partitionKeyFilter = $"PartitionKey eq '{entity.PartitionKey}'";

//await foreach (var e in tableClient.QueryAsync<TableEntity>(partitionKeyFilter))
//{
//	Console.WriteLine($"PartitionKey: {e.PartitionKey}, RowKey: {e.RowKey}," +
//		$"Property1: { e.GetString("firstname")}, " +
//		$"Property2: { e.GetString("secondname")}, " +
//		$"Property3: { e.GetString("country")}, " +
//		$"Property4: { e.GetString("phone")}, " +
//		$"Property4: { e.GetDateTime("datebirth")}, " +
//		$"Property5: { e.GetInt32("height")}");
	
//}

// Update an entity in the table
//var entity = new TableEntity("volleyball", "player7");
//entity["country"] = "New Country";
//await tableClient.UpdateEntityAsync(entity, ETag.All);
//Console.WriteLine("Entity updated in the table.");

// Delete an entity from the table
var entity = new TableEntity("volleyball", "player7");
await tableClient.DeleteEntityAsync(entity.PartitionKey, entity.RowKey);
Console.WriteLine("Entity deleted from the table.");
