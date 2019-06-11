using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using AngleSharp;
using AngleSharp.Html.Parser;
using FunApp.Data;
using FunApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SandBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);


            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;

                SandBoxCode(serviceProvider);
            }
        }
         
        private static  void SandBoxCode(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<FunAppContext>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var parser = new HtmlParser();
            var webClient = new WebClient() { Encoding = Encoding.GetEncoding("windows-1251") };
            //TODO: code here

            for (int i = 2000; i < 3000; i++)
            {
                var url = "https://fun.dir.bg/vic_open.php?id=" + i;
                var html = webClient.DownloadString(url);
                
                var document = parser.ParseDocument(html);
                var jokeContent = document.QuerySelector("#newsbody")?.TextContent?.Trim();
                var categoryName = document.QuerySelector(".tag-links-left a")?.TextContent?.Trim();
                

                if (!string.IsNullOrWhiteSpace(jokeContent) && !string.IsNullOrWhiteSpace(categoryName))
                {
                    var category = context.Categories.FirstOrDefault(x => x.Name == categoryName);
                    if (category == null)
                    {
                        category = new Category()
                        {
                            Name = categoryName
                        };
                    }

                    var joke = new Joke()
                    {
                        Category = category,
                        Content = jokeContent
                    };

                    context.Jokes.Add(joke);
                    context.SaveChanges();
                }

                Console.WriteLine($"{i} => category Name {categoryName}");
            }
       
            
           
           
        }

      

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<FunAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
