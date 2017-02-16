using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace CssFilesCreater
{
    public class Program
    {
        static HttpClient client = new HttpClient();

        static void CreatCSSFiles(IEnumerable<Team> team)
        {
            foreach (var t in team) {
                Console.WriteLine("Files are created");
                string path = @"D:\Documents\Visual Studio 2015\Projects\footballvideos.git\FootBallVideos\wwwroot\Content\themes\" + t.TeamName + ".css";
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(".categories-title{background-color:"+ t.BackgroundColor+";}");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                        Console.WriteLine("Did it");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

       static async Task<IEnumerable<Team>> GetTeamAsync(string path)
        {
            HttpResponseMessage response = client.GetAsync(path).Result;

            if (response.IsSuccessStatusCode)
            {
                var teams = await response.Content.ReadAsStringAsync()
                    .ContinueWith<IEnumerable<Team>>(getTask =>
                    {
                        return JsonConvert.DeserializeObject<IEnumerable<Team>>(getTask.Result);
                    });
                return teams;
            }

            return null;
        }
        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:60000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
           IEnumerable<Team> teams = await GetTeamAsync("api/team");
                CreatCSSFiles(teams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();


        }



    }
}
