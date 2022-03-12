using Microsoft.Extensions.DependencyInjection;
using System;

namespace MultiValueDictionary
{
    public class Program
    {     
        static void Main(string[] args)
        {           
            DictionaryService _dict = new DictionaryService();
            var dictionary = new Dictionary(_dict);

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();
                var res = dictionary.CallMethod(input);
                dictionary.ParseResponse(res);
               
            }
        }
    }
}
