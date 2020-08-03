using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUChairVO
{
   public  class ComboItemVO
    {
        public string Code { get; set; }
        public string CodeType { get; set; }
        public string CodeNm { get; set; }

        public ComboItemVO() { }
        public ComboItemVO(string blankText, string mode = "Y")
        {
            if (mode == "Y")
            {
                Code = "";
                CodeNm = blankText;
            }
            else if(mode =="R")
            {
                Code = blankText;
                CodeNm ="" ;
            }

        }
    }
}
