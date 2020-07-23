using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class UserVO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
    public class TestVO
    {
         public string  a { get; set; }
        public string  b { get; set; }
        public string  c { get; set; }
        public string  d { get; set; }
    }
}
