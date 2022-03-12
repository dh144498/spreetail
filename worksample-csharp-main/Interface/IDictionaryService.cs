using MultiValueDictionary.Model;

namespace MultiValueDictionary
{
    public interface IDictionaryService
    {
        ResponseModel Keys();
        ResponseModel Members(string key);
        ResponseModel Add(string key, string value);
        ResponseModel Remove(string key, string value);
        ResponseModel RemoveAll(string key);
        ResponseModel Clear();
        ResponseModel KeyExists(string key);
        ResponseModel MemberExists(string key, string value);
        ResponseModel AllMembers();
        ResponseModel Items();
    }
}
