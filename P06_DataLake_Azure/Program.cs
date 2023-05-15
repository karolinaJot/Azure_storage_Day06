using Azure.Storage.Files.DataLake;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

string connectionString = configuration.GetConnectionString("DataLakeConnectionString");

var containerName = "new-datalake-storage";

//var connectionString = "myconnection";
//var containerName = "mystoragecontainer";


var dataLakeServiceClient = new DataLakeServiceClient(connectionString);
var dataLakeContainerClient = dataLakeServiceClient.GetFileSystemClient(containerName);

Console.WriteLine("Enter the file path of the image to upload:");
var imagePath = Console.ReadLine();

using var fileStream = File.OpenRead(imagePath);
var blobName = Path.GetFileName(imagePath);

var blobClient = dataLakeContainerClient.GetFileClient(blobName);
await blobClient.UploadAsync(fileStream, true);
Console.WriteLine($"Image '{imagePath}' uploaded successfully to Data Lake Storage Gen2.");

Console.WriteLine("Enter the name of the image to download from Data Lake Storage Gen2:");
var imageNameToDownload = Console.ReadLine();

var downloadBlobClient = dataLakeContainerClient.GetFileClient(imageNameToDownload);
Console.WriteLine("Enter the destination file path to save the downloaded image:");
var destinationPath = Console.ReadLine();

var download = await downloadBlobClient.ReadAsync();
using var downloadFileStream = File.OpenWrite(destinationPath);

await download.Value.Content.CopyToAsync(downloadFileStream);
downloadFileStream.Close();
Console.WriteLine($"Image '{imageNameToDownload}' downloaded successfully from Data Lake Storage Gen2 and saved to '{destinationPath}'.");