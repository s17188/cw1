using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! Git");
            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl/");

            if (result.IsSuccessStatusCode)
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z0-9]+@[a-z0-9]+\\.[a-z]+",RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(html);

                foreach(var m in matches)
                {
                    Console.WriteLine(m);
                }
            }
        }
    }
}
