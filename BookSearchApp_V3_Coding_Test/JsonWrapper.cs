using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookSearchApp_V3_Coding_Test
{
    class JsonWrapper
    {
        public async Task<JsonModel> GetBookByTitle(string title)
        {
            string url = "https://openlibrary.org/search.json?title=";
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url + title);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JsonModel jsonModel = JsonConvert.DeserializeObject<JsonModel>(responseBody);
                jsonModel.Docs = jsonModel.Docs.Where(b => b.Title.Equals(title, StringComparison.Ordinal)).ToArray();
                return jsonModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        public JsonModel DeserializeJsonFromFile(string fileName)
        {
            var rawJson = ReadFromFile(fileName);
            var parsedJson = JsonConvert.DeserializeObject<JsonModel>(rawJson);
            return parsedJson;
        }

        public string ReadFromFile(string fileName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            return File.ReadAllText(filePath);
        }
    }
}