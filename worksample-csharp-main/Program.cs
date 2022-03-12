using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MultiValueDictionary
{
    public class Program
    {
      //  private readonly Dictionary dictionary;
        static void Main(string[] args)
        {            
            var service = CreateHostBuilder(args).Build().Services.GetRequiredService<Dictionary>();

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                var res = service.CallMethod(input);
                service.ParseResponse(res);
               
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddTransient<IDictionaryService, DictionaryService>();
                        services.AddSingleton<Dictionary>();
                    });
        }
    }
}
