using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace MyOfficialPortfolio.Services
{
    public class SESService
    {
        private readonly IAmazonSimpleEmailService _client;

        public SESService(string accessKey, string secretKey, string region)
        {
            var config = new AmazonSimpleEmailServiceConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(region)
            };
            _client = new AmazonSimpleEmailServiceClient(accessKey, secretKey, region);
        }

        public async Task<bool> SendEmailAsync(string from, string to, string subject, string body)
        {
            var request = new SendEmailRequest
            {
                Source = from,
                Destination = new Destination
                {
                    ToAddresses = new List<string> { to }
                },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body
                    {
                        Html = new Content(body)
                    }
                }
            };

            try
            {
                var response = await _client.SendEmailAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch //(Exception ex)
            {
                return false;
            }
        }
    }
}
