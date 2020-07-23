using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using TUChaiAPI.DAC;
using TUChairVO;
using Message = TUChairVO.Message;

namespace TUChaiAPI.Controllers
{
    [RoutePrefix("api/TUChair")]
    public class TUChairController : ApiController
    {
        UserDAC uDac = new UserDAC();
        [Route("GetAllUser")]
        public List<TestVO> GetAllUser()
        {
            return uDac.GetAllUsers();

        }
        [Route("GetUserInfo/{id}")]
        public UserVO GetUserInfo(int id)
        {
            return new UserVO() { Id = id, Name = "홍길동" };
        }
        [HttpPost]
        [Route("SaveUser")]
        public IHttpActionResult SaveUser([FromBody] UserVO user)
        {
            Message msg = new Message();
            string result = uDac.SaveUser(user);
            if (result == "C200" && user.Id == 0)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 등록 되였습니다";
            }
            else if (result == "C202" && user.Id > 0)
            {
                msg.IsSuccess = true;
                msg.ResultMessage = "성공적으로 수정 되였습니다";
            }
            else if (result == "C201")
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "이미 등록된 Email입니다";
            }
            else if (result == "C202")
            {
                msg.IsSuccess = false;
                msg.ResultMessage = "이미 등록된 폰번입니다";
            }
            return Ok(msg);
        }
    }
}
