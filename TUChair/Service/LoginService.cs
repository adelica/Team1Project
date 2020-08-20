using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUChairVO;
using TUChairDAC;

namespace TUChair.Service
{
    class LoginService
    {
        internal CUserVO GetUserinfo(string UserID)
        {
            LoginDAC dac = new LoginDAC();
            return dac.GetUserinfo(UserID);
        }

        internal List<AuthorVO> GetAuthorInfo(int authorGroup_ID)
        {
            LoginDAC dac = new LoginDAC();
            return dac.GetAuthorInfo(authorGroup_ID);
        }

        internal bool InsertMark(string marks, string UID)
        {
            LoginDAC dac = new LoginDAC();
            return dac.InsertMark(marks, UID);
        }

        internal bool InsertAuthor(List<AuthorVO> author)
        {
            LoginDAC dac = new LoginDAC();
            return dac.InsertAuthor(author);
        }
    }
}
