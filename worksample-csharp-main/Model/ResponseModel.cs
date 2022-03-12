using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Model
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            Result = new List<string>();
        }
        public List<string> Result { get; set; }
        public string Message { get; set; }
    }
}
