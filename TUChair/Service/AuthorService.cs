using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairDAC;
using TUChairVO;

namespace TUChair.Service
{
    public class AuthorService
    {

        //public DataTable GetBalzuMi()
        //{
        //    balzuDAC dac = new balzuDAC();
        //    return dac.GetBalzu();
        //}
        public List<AuthorGroupVO> GetAllAuthorGroup()
        {
            AuthorDAC dac = new AuthorDAC();
            return dac.GetAllAuthorGroup();
        }

        internal bool SaveAuthorGroup(AuthorGroupVO author)
        {
            AuthorDAC dac = new AuthorDAC();
            return dac.SaveAuthorGroup(author);
        }
    }
}
