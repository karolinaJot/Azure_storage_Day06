
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;


// UPLOAD DATA to Blob container

//var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";
//var containerName = "volleyball-photos";
//var blobServiceClient = new BlobServiceClient(connectionString);
//var containerClient =
//blobServiceClient.GetBlobContainerClient(containerName);
//Console.WriteLine("Enter the file path of the image to upload:");
//var imagePath = Console.ReadLine();
//using var fileStream = File.OpenRead(imagePath);
//var blobName = Path.GetFileName(imagePath);
//var blobClient = containerClient.GetBlobClient(blobName);
//await blobClient.UploadAsync(fileStream, true);
//Console.WriteLine($"Image '{imagePath}' uploaded successfull to Blob storage.");


var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";
var containerName = "volleyball-photos";
var blobServiceClient = new BlobServiceClient(connectionString);
var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

Console.WriteLine("Enter the name of the image to download from Blob storage: ");
var imageNameToDownload = Console.ReadLine();

var downloadBlobClient = containerClient.GetBlobClient(imageNameToDownload);
Console.WriteLine("Enter the destination file path to save the downloaded image: ");
var destinationPath = Console.ReadLine();

BlobDownloadInfo download = await downloadBlobClient.DownloadAsync();
using var downloadFileStream = File.OpenWrite(destinationPath);
await download.Content.CopyToAsync(downloadFileStream);
downloadFileStream.Close();
Console.WriteLine($"Image '{imageNameToDownload}' downloaded successfully from Blob storage and saved to '{destinationPath}'.");
