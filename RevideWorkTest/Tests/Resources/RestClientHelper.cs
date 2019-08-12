using NUnit.Framework;
using RestSharp;
using RevideWorkTest.Tests.Resources.Models;

namespace RevideWorkTest.Tests.Resources
{
    public class RestClientHelper
    {
        RestClient client;
        public RestClientHelper()
        {
            client = new RestClient("https://revidetest.eclub.se");
        }

        public ResponseModel verifyRegistration(string emailAddress)
        {
            RestRequest request = new RestRequest(string.Format("/api/v1/contacts?query=Email:\"{0}\"", emailAddress), Method.GET);
            request.AddHeader("apikey", "d0899342-1486-4a9c-b845-02991b5a5662");

            IRestResponse<ResponseModel> response = client.Execute<ResponseModel>(request);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            return response.Data;
        }
    }
}
