using System;
using System.Text.Json.Serialization;

namespace TestApiCalls.Model
{
    class modTodo
    {
        [JsonPropertyName("userId")]
        public int ChangeName { get; set; }

        public int id { get; set; }

        public string title { get; set; }

        public bool completed { get; set; }
    }
}
