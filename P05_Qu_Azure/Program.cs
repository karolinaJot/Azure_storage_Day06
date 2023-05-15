

using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";

var queueName = "messages";

QueueClient queueClient = new QueueClient(connectionString, queueName);

await queueClient.CreateIfNotExistsAsync();

Console.WriteLine("Enter a message to add to the queue:");
var message = Console.ReadLine();
await queueClient.SendMessageAsync(message);

Console.WriteLine($"Message '{message}' added to the queue.");

Console.WriteLine("Retrieving a message from the queue...");

QueueMessage[] retrievedMessage = await queueClient.ReceiveMessagesAsync();
if (retrievedMessage != null && retrievedMessage.Length > 0)
{
	Console.WriteLine($"Message retrieved: '{retrievedMessage[0].MessageText}'");
	Console.WriteLine("Deleting the message from the queue...");
	await queueClient.DeleteMessageAsync(retrievedMessage[0].MessageId,
   retrievedMessage[0].PopReceipt);
	Console.WriteLine("Message deleted successfully.");
}
else
{
	Console.WriteLine("No messages found in the queue.");
}