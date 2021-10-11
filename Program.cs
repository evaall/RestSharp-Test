using System;
using System.Threading.Tasks;
using TestApiCalls.Data;

namespace TestApiCalls
{
    class Program
    {
        static async Task Main()
        {
            TodoData todoData = new TodoData();
            todoData.getTodos();

            Console.Read();
        }
    }
}