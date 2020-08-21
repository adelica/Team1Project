using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class EmpService
    {
        public List<EmpVO> EmpBinding()
        {
            EmpDAC dac = new EmpDAC();
            return dac.EmpBinding();
        }

        public List<EmpVO> EmpSearch(string id,string name)
        {
            EmpDAC dac = new EmpDAC();
            return dac.EmpSearch(id,name);
        }
        public bool Update(string id, string name, string pwd, string AuthorID, string UseOrNot)
        {
            EmpDAC dac = new EmpDAC();
            return dac.Update( id,  name,  pwd, AuthorID, UseOrNot);
        }
        public bool Insert(string id, string name, string pwd, string AuthorID, string UseOrNot)
        {
            EmpDAC dac = new EmpDAC();
            return dac.Insert(id, name, pwd, AuthorID, UseOrNot);
        }
    }
}
