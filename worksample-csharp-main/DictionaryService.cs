using MultiValueDictionary.Model;
using System.Collections.Generic;

namespace MultiValueDictionary
{
    public class DictionaryService : IDictionaryService
    {
        private IDictionary<string, List<string>> _dict;
        public DictionaryService()
        {
            _dict = new Dictionary<string, List<string>>();
        }

        public ResponseModel Keys()
        {
            var response = new ResponseModel();
            if (_dict.Count == 0)
                response.Message = ReturnMessages.EmptySet;
            else
            {
                foreach (var a in _dict)
                {
                    response.Result.Add(a.Key);
                }
            }
            return response;
        }

        public ResponseModel Members(string key)
        {
            var response = new ResponseModel();
            if (!_dict.ContainsKey(key))
                response.Message = ReturnMessages.KeyNotExist;
            else
            {
                foreach (var a in _dict[key])
                {                  
                    response.Result.Add(a);
                }
            }
            return response;
        }
        public ResponseModel Add(string key, string value)
        {
            var response = new ResponseModel();
            var valueList = new List<string>();
            try
            {
                if (_dict[key].Contains(value))
                {
                    response.Message = ReturnMessages.MemberAlreadyExists;
                    return response;
                }
            }
            catch(KeyNotFoundException ex)
            {
                valueList.Add(value);
                _dict.Add(key, valueList);
                response.Message = ReturnMessages.Added;
                return response;
            }
            valueList = _dict[key];
            valueList.Add(value);          
            response.Message = ReturnMessages.Added;
            return response;
        }
        public ResponseModel Remove(string key, string value)
        {
            var response = new ResponseModel();
            if (!_dict.ContainsKey(key))
            {
                response.Message = ReturnMessages.KeyNotExist;
                return response;
            }
            if (_dict[key].Contains(value))
            {
                _dict[key].Remove(value);
                response.Message = ReturnMessages.Removed;
                if (_dict[key].Count == 0)
                    _dict.Remove(key);
                return response;
            }
            response.Message = ReturnMessages.MemberNotExist;
            return response;
        }
        public ResponseModel RemoveAll(string key)
        {
            var response = new ResponseModel();
            if (_dict.ContainsKey(key))
            {
                _dict.Remove(key);
                response.Message = ReturnMessages.Removed;
                return response;
            }
            response.Message = ReturnMessages.KeyNotExist;
            return response;
        }
        public ResponseModel Clear()
        {
            var response = new ResponseModel();
            _dict.Clear();
            response.Message = ReturnMessages.Cleared;
            return response;
        }
        public ResponseModel KeyExists(string key)
        {
            var response = new ResponseModel();
            response.Message = ReturnMessages.False;
            if (_dict.ContainsKey(key))                
                response.Message = ReturnMessages.True;
            return response;
        }
        public ResponseModel MemberExists(string key, string value)
        {
            var response = new ResponseModel();
            response.Message = ReturnMessages.False;
            if (_dict.ContainsKey(key) && _dict[key].Contains(value))
            {
                response.Message = ReturnMessages.True;
            }              
            return response;
        }
        public ResponseModel AllMembers()
        {
            var response = new ResponseModel();
            if (_dict.Keys.Count == 0)
            {
                response.Message = ReturnMessages.EmptySet;
                return response;
            }
            foreach (var pair in _dict)
            {
                foreach (var value in pair.Value)
                {
                    response.Result.Add(value);
                }
            }           
            return response;
        }
        public ResponseModel Items()
        {
            var response = new ResponseModel();
            if (_dict.Keys.Count == 0)
            {
                response.Message = ReturnMessages.EmptySet;
                return response;
            }
            foreach (var pair in _dict)
            {
                foreach (var value in pair.Value)
                {
                    response.Result.Add(pair.Key + ": " + value);
                }                         
            }
            return response;
        }

    }
}
