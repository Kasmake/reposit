 using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace API_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://reqres.in/api/users/2";

            DeleteRequest(URL);
        }

        private static void GetRequest(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "GET";
            request.Credentials = new NetworkCredential("student", "student");

            var response = request.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string text = reader.ReadToEnd();
            var jsonText = JsonConvert.DeserializeObject<User>(text);

            Console.WriteLine($"{jsonText.data.id} {jsonText.data.last_name} {jsonText.data.first_name} {jsonText.data.email}");
            Console.ReadLine();
        }

        private static void PostRequest(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "POST";
            
            var data = @"{""first_name"": ""Misha"", ""last_name"": ""Pigalov""}";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());

            using (writer)
            {
                writer.Write(data);
            }

            var response = request.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader (response.GetResponseStream());

            string text = reader.ReadToEnd();

            Console.WriteLine($"{text}");

            Console.ReadLine(); 
        }

        public static void PutRequest(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "PUT";

            var data = @"{""first_name"": ""Misha"", ""last_name"": ""Pigalov""}";

            StreamWriter writer = new StreamWriter(request.GetRequestStream());

            using (writer)
            {
                writer.Write(data);
            }

            var response = request.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string text = reader.ReadToEnd();

            Console.WriteLine($"{text}");

            Console.ReadLine();
        }

        public static void DeleteRequest(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "DELETE";

            StreamWriter writer = new StreamWriter (request.GetRequestStream());

            var response = request.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string text = reader.ReadToEnd();

            Console.WriteLine($"{text} Status Code: {((int)response.StatusCode).ToString()}");
            Console.ReadLine();
        }
    }
}
