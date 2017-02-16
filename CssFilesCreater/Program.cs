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
                        Byte[] info = new UTF8Encoding(true).GetBytes(@".header {background-color:" + t.BackgroundColor + @";}
.content { background-color:" + t.WrapperColor + @";}
.footer { background-color:" + t.BackgroundColor + @";}
.nav-header { border-bottom: 1px solid" + t.BorderColor + @";}
.bars { background-color:" + t.ButtonColor + "; box-shadow: 0 5px 0" + t.ButtonColor + ", 0 10px 0" + t.ButtonColor + @";}
.flipkart-navbar-logo a { color:" + t.TextColor + @";}
.flipkart-navbar-input, .tablet-navbar-input {border: 1px solid" + t.BorderColor + "; color:" + t.TextColor + "; background-color:" + t.WrapperColor + @";}
.flipkart-navbar-button, .tablet-navbar-button { color: " + t.ButtonColor + @";}
.links { color:" + t.IconColor + @"; }
.links: hover {color:" + t.WrapperColor + @";}
.block { background-color:"+t.BackgroundColor+"; border-bottom: 1px solid"+t.BorderColor+ @";}
.search-button { color:  " + t.ButtonColor + @"; }
.category-item li.active a { color:  " + t.ButtonColor + @";}
.sidebar { border-right:1px solid" + t.BorderColor + "; background-color:"+t.BackgroundColor+ @"; }
.categories { color: "+t.TextColor+"; border-bottom: 1px solid " + t.BorderColor + @";}
.categories-xs {background-color:"+t.BackgroundColor+" ; color:"+t.TextColor+@";}
.categories-title { background-color: "+t.ButtonColor+"; color:"+t.TextColor+@";}
.categories li > a, .categories-xs li > a { color: "+t.TextColor+@";}
.categories li > a:hover, .categories-xs li > a:hover,
.categories li > a:focus, .categories-xs li > a:focus {color:"+t.IconColor+@";}
.categories-dropdown-content { border-bottom: 1px solid"+t.BorderColor+ @";}
.scrollbar::-webkit-scrollbar-track { background-color:" + t.BorderColor + @";}
.scrollbar::-webkit-scrollbar { background-color:" + t.BorderColor + @";}
.scrollbar::-webkit-scrollbar-thumb {background-color: " + t.ButtonColor + @";}
.btn.btn-danger { background-color: " + t.ButtonColor + "; border: 1px solid " + t.BorderColor + @";}
.videos-content { background-color:" + t.BackgroundColor + "; border: 1px solid " + t.BorderColor + @";}
.videos-img-holder { border: 1px solid " + t.BorderColor + @";}
#footer { border-top:1px solid" + t.BorderColor + @";}
#footer ul li { color:#9d9d9d;}
#footer a { color:#9d9d9d;}
#footer ul li:before { color: #5b5b5b;}
.video-title, .related-title{ color: " + t.ButtonColor + @";}
.videos-img-holder { border: 1px solid " + t.BorderColor + @";}");

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
