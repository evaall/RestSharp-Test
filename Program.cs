using RestSharp;
using System;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestApiCalls
{
    class Program
    {
        static async Task Main()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/todos");

            // By pass Proxy
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = proxy;

            // Build Request
            RestRequest request = new RestRequest(Method.GET);
            
            // Add Token to Head
            request.AddHeader("token", "1234");
            
            
            // Exexute Resquest 
            IRestResponse response = client.Execute(request);
            // Convert resoponse to string
            string content = response.Content;

            Console.WriteLine(content);
            Console.Read();
        }

        class Todo
        {
            [JsonPropertyName("userId")]
            public int ChangeName { get; set; }

            public int id { get; set; }

            public string title { get; set; }

            public bool completed { get; set; }
        }
    }
}