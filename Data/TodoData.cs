using RestSharp;
using System;
using System.Net;
using TestApiCalls.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestApiCalls.Data
{
    class TodoData
    {
        static string url = "https://jsonplaceholder.typicode.com/todos";

        public void getTodos()
        {
            var endpoint = "";

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("token", "124");

            string res = RestCall(endpoint, header);

            List<modTodo> modTodoList = JsonConvert.DeserializeObject<List<modTodo>>(res);


            foreach(var todo in modTodoList)
            {
                Console.WriteLine(todo.title);
            }
        }

        private string RestCall(string endpoint, Dictionary<string, string> header) 
        {
            var client = new RestClient(url + endpoint);

            // By pass Proxy
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            client.Proxy = proxy;

            // Build Request
            RestRequest request = new RestRequest(Method.GET);

            request.AddHeaders(header);

            // Exexute Resquest 
            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}