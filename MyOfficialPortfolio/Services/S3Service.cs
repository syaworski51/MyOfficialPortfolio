using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MyOfficialPortfolio.Services
{
    public class S3Service
    {
        private readonly IAmazonS3 _client;

        public S3Service(string accessKey, string secretKey, string region)
        {
            var config = new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };
            _client = new AmazonS3Client(accessKey, secretKey, region);
        }

        public async Task UploadFileAsync(string bucket, string filePath, string key)
        {
            var transferUtility = new TransferUtility(_client);
            await transferUtility.UploadAsync(filePath, bucket, key);
        }

        public async Task<string> GeneratePresignedURLAsync(string bucket, string key, int expiryTime)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucket,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(expiryTime)
            };
            return await _client.GetPreSignedURLAsync(request);
        }
    }
}
