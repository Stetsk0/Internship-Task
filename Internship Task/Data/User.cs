using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Forms;

namespace Internship_Task.Data
{
    public class User
    {
        
        public string? Email { get; set; }
        public IBrowserFile? File { get; private set; }

        private readonly IConfiguration _jsonSecretsConfiguration;

        public const long maximumAllowedFileSize = 1024 * 1000;

        public User(IConfiguration jsonSecretsConfiguration) => _jsonSecretsConfiguration = jsonSecretsConfiguration; 

        public void HandleSelection(InputFileChangeEventArgs e)
        {
            File = e.File;
            FileStatus.Selected = true;
        }

        /// <summary>
        /// Uploads the file to the Blob storage
        /// </summary>
        public async Task UploadFile()
        {
            if (FileStatus.CanBeUploaded(File, Email))
            {
                var metadata = new Dictionary<string, string?>
                {
                    { "Email", Email }
                };

                var blobStorageConnectionString = _jsonSecretsConfiguration["AzureStorageConnectionKey"];
                var blobStorageContainerName = "files";

                var container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);

                BlobClient blobClient = container.GetBlobClient(File?.Name);

                if (!blobClient.Exists() && blobClient != null)
                {
                    if (!(File?.Size >= maximumAllowedFileSize))
                    {
                        using (Stream? stream = File?.OpenReadStream(maximumAllowedFileSize))
                        {
                            await blobClient.UploadAsync(stream, new BlobUploadOptions { Metadata = metadata });
                        }
                        FileStatus.Uploaded = true;
                    }
                    else
                    {
                        FileStatus.LimitExceeded = true;
                    }
                }
                else
                {
                    FileStatus.Exists = true;
                }

            }
        }
    }
}
