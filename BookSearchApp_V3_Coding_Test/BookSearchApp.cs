using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BookSearchApp_V3_Coding_Test
{
    internal class Program
    {
        private const string title1 = "Goodnight Moon";
        private const string title2 = "Goodnight Moon Base";
        private const string jsonFileName = "ExpectedJson.json";
        private const int publishYear = 2000;

        private static void Main(string[] args)
        {
            JsonWrapper wrapper = new JsonWrapper();

            //Task 3.1 + Task 3.1.1
            Console.WriteLine("##################### TASK 3.1 + 3.1.1 #####################\n");

            JsonModel result1 = Task.Run(async () => await wrapper.GetBookByTitle(title1)).Result;
            Console.WriteLine(
                $"Total number of books with the title matching exactly '{title1}': {result1.Docs.Length}\n");

            //Task 3.1.2
            Console.WriteLine("##################### TASK 3.1.2 #######################\n");
            Console.WriteLine(
                $"List of [key] of books with title '{title2}' that were published since '{publishYear}' year: \n");
            result1.Docs
                .Where(b => b.FirstPublishYear >= publishYear).ToList().ForEach(docs =>
                    Console.WriteLine("Key: '{0}' | Publish year: '{1}'\n", docs.Key,
                        docs.FirstPublishYear));

            //Task 3.2 + Task 3.2.1
            Console.WriteLine("##################### TASK 3.2 + 3.2.1 #####################\n");

            JsonModel actualJson = Task.Run(async () => await wrapper.GetBookByTitle(title2)).Result;
            JsonModel expectedJson = wrapper.DeserializeJsonFromFile(jsonFileName);

            JObject expectedJObject = JObject.FromObject(expectedJson);
            JObject actualJObject = JObject.FromObject(actualJson);

            if (!JToken.DeepEquals(expectedJObject, actualJObject))
            {
                Console.WriteLine($"Actual API call does not match provided file '{jsonFileName}'\n");

                foreach (var expectedToken in expectedJObject.Descendants().OfType<JProperty>())
                {
                    var actualToken = actualJObject.SelectToken(expectedToken.Path);

                    if (actualToken == null)
                    {
                        Console.WriteLine($"Missing property: \n{expectedToken.Path}\n");
                    }
                    else if (!JToken.DeepEquals(expectedToken.Value, actualToken))
                    {
                        Console.WriteLine("Mismatched property name '{0}',\n EXPECTED:{1}\n ACTUAL:{2}\n",
                            expectedToken.Path, expectedToken.Value, actualToken);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Actual API call matches provided file '{jsonFileName}'\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}