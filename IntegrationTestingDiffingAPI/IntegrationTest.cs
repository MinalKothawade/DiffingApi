using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace IntegrationTestingDiffingAPI
{
    public static class ContentHelper
    {        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }

    public class IntegrationTest
    {
        private HttpClient Client = new HttpClient();
        [Fact]
        public async Task TestPostLeftRequestDataAsync()
        {

            // Arrange
            var request = new
            {
                Url = "http://localhost/Identity/api/DiffService/GetRequestData/3/Left",
                Body = new
                {
                    Id="3",
                    InputString="Test"
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.StatusCode.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestPostRightRequestDataAsync()
        {

            // Arrange
            var request = new
            {
                Url = "http://localhost/Identity/api/DiffService/GetRequestData/3/Right",
                Body = new
                {
                    Id = "3",
                    InputString = "Test"
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.StatusCode.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetResponseDataforEqualDataAsync()
        {

            // Arrange
            var request = new
            {
                Url = "http://localhost/Identity/api/DiffService/GetResponseData",
                Body = new
                {
                    Id = "3"
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.StatusCode.Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestPGetResponseDataforEqualSizeAsync()
        {

            // Arrange
            var request = new
            {
                Url = "http://localhost/Identity/api/DiffService/GetResponseData",
                Body = new
                {
                    Id = "11"
                }
            };

            // Act
            var response = await Client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            response.StatusCode.Equals(HttpStatusCode.OK);
        }
    }
}
