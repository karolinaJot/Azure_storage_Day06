

using Azure;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Storage;

//var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";
//var shareName = "pictures";

//ShareServiceClient shareServiceClient = new ShareServiceClient(connectionString);
//ShareClient shareClient = shareServiceClient.GetShareClient(shareName);
//ShareDirectoryClient directoryClient = shareClient.GetRootDirectoryClient();

//Console.WriteLine("Enter the file path of the image to upload:");
//var imagePath = Console.ReadLine();

//using var fileStream = File.OpenRead(imagePath);
//var fileName = Path.GetFileName(imagePath);

//ShareFileClient fileClient = directoryClient.GetFileClient(fileName);

//await fileClient.CreateAsync(fileStream.Length);
//await fileClient.UploadRangeAsync(new HttpRange(0, fileStream.Length), fileStream);

//Console.WriteLine($"Image '{imagePath}' uploaded successfully to the File Share.");


//Console.WriteLine("Enter the name of the image to download from the File Share:");

//var imageNameToDownload = Console.ReadLine();
//var downloadFileClient = directoryClient.GetFileClient(imageNameToDownload);
//Console.WriteLine("Enter the destination file path to save the downloaded image:");

//var destinationPath = Console.ReadLine();

//ShareFileDownloadInfo download = await downloadFileClient.DownloadAsync();
//using var downloadFileStream = File.OpenWrite(destinationPath);
//await download.Content.CopyToAsync(downloadFileStream);
//downloadFileStream.Close();

//Console.WriteLine($"Image '{imageNameToDownload}' downloaded successfully from the File Share and saved to '{destinationPath}'.");


var connectionString = "DefaultEndpointsProtocol=https;AccountName=volleyballsa2;AccountKey=iy/BJyPxlSLlryA5mgKpwTYIP/HFfNW6KSZFUMIzY9vfWuY0ght3IDdrZ1anf9n0C4A1XuxLZ/rk+AStjvr8lw==;EndpointSuffix=core.windows.net";
var shareName = "pictures";

var storageAccount = CloudStorageAccount.Parse(connectionString);
var fileClient = storageAccount.CreateCloudFileClient();
var share = fileClient.GetShareReference(shareName);
var rootDirectory = share.GetRootDirectoryReference();

Console.WriteLine("Enter the file path of the image to upload:");
var imagePath = Console.ReadLine();

using var fileStream = File.OpenRead(imagePath);
var fileName = Path.GetFileName(imagePath);

var file = rootDirectory.GetFileReference(fileName);
await file.UploadFromStreamAsync(fileStream);

Console.WriteLine($"Image '{imagePath}' uploaded successfully to the File Share.");

Console.WriteLine("Enter the name of the image to download from the File Share:");
var imageNameToDownload = Console.ReadLine();

var downloadFile = rootDirectory.GetFileReference(imageNameToDownload);
Console.WriteLine("Enter the destination file path to save the downloaded image:");
var destinationPath = Console.ReadLine();

using var downloadFileStream = File.OpenWrite(destinationPath);
await downloadFile.DownloadToStreamAsync(downloadFileStream);

Console.WriteLine($"Image '{imageNameToDownload}' downloaded successfully from the File Share and saved to '{destinationPath}'.");