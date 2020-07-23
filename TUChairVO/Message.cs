using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
  
        public class Message<T>
        {
            public bool IsSuccess { get; set; }
            public string ResultMessage { get; set; }
            public T Data { get; set; }
        }
        public class Message
        {
            public bool IsSuccess { get; set; }
            public string ResultMessage { get; set; }

        }
    
}
