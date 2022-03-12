using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public struct ReturnMessages
    {
        public const string EmptySet = "(empty set)";
        public const string KeyNotExist = ") ERROR, key does not exist";
        public const string MemberNotExist = ") ERROR, member does not exist";
        public const string MemberAlreadyExists = ") ERROR, member already exists for key";
        public const string Added = ") Added";
        public const string Removed = ") Removed";
        public const string Cleared = ") Cleared";
        public const string False = ") false";
        public const string True = ") true";
    }
}
