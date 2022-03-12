using MultiValueDictionary.Model;
using System;

namespace MultiValueDictionary
{
    public class Dictionary
    {
        private readonly IDictionaryService _dict;
        public Dictionary(IDictionaryService dict)
        {
            _dict = dict;
        }
        public ResponseModel CallMethod(string input)
        {
            var response = new ResponseModel();
            try
            {
                var parsedInput = input.Split(' ');

                switch(parsedInput[0].ToLowerInvariant())
                {
                    case "keys":
                        return _dict.Keys();
                    case "members":
                        return _dict.Members(parsedInput[1]);
                    case "add":
                        return _dict.Add(parsedInput[1], parsedInput[2]);
                    case "remove":
                        return _dict.Remove(parsedInput[1], parsedInput[2]);
                    case "removeall":
                        return _dict.RemoveAll(parsedInput[1]);
                    case "clear":
                        return _dict.Clear();
                    case "keyexists":
                        return _dict.KeyExists(parsedInput[1]);
                    case "memberexists":
                        return _dict.MemberExists(parsedInput[1], parsedInput[2]);
                    case "allmembers":
                        return _dict.AllMembers();
                    case "items":
                        return _dict.Items();
                    default:
                        response.Message = "Invalid command name";
                        return response;
                }
            }            
            catch(IndexOutOfRangeException ex)
            {
                response.Message = "Invalid inputs - missing required key or value";
                return response;
            }
            catch(Exception ex)
            {
                response.Message = "Invalid inputs - " + ex.Message;
                return response;
            }            
        }
        public void ParseResponse(ResponseModel res)
        {
            if (res.Result.Count > 0)
            {
                var count = 1;
                foreach (var r in res.Result)
                {
                    Console.WriteLine(count + ") " + r);
                    count++;
                }
            }
            else
            {
                Console.WriteLine(res.Message);
            }
        }
    }
}
