using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TUChairVO;

namespace TUChaiAPI.Controllers
{
    public class FileHandleController : ApiController
    {
        [HttpGet]
        [Route("api/FileHandle/GetFileList")]
        //올라가있는 모든 파일의 리스트를 가져옴
        public IEnumerable<FilePathVO> GetFilesInfo()
        {
            List<FilePathVO> files = new List<FilePathVO>();

            //Server.MapPath() 가상경로로부터 실제경로 반환
            var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads/");// 절대경로로 바꿈
            DirectoryInfo dir = new DirectoryInfo(uploadPath);//모든 파일 가져옴
            foreach (FileInfo fInfo in dir.GetFiles())//모든 파일을 list에 추가
            {
                files.Add(new FilePathVO
                {
                    FileName = fInfo.Name,
                    Path = uploadPath,
                    Length = fInfo.Length
                });
            }
            return files;//리스트 return
        }
        // 파일 하나를 가져온다
        public async Task<FilePathVO> Post()
        {
            FilePathVO result = null;

            var httpReq = HttpContext.Current.Request;

            if (Request.Content.IsMimeMultipartContent())//파일이 Multipart로 넘어오면
            {
                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                if (!Directory.Exists(uploadPath))//Uploads 폴더가 없으면 만들어라
                    Directory.CreateDirectory(uploadPath);

                // Microsoft.AspNet.WebApi.Client NuGet 패키지설치 => System.Net.Formatting.dll 
                // MultipartFormDataStreamProvider 클래스 이용
                var multiPart = new UploadFileMultipartProvider(uploadPath);//파일 이름을 가져온다

                await Request.Content.ReadAsMultipartAsync(multiPart);//기다림

                string _localFileName = multiPart.FileData
                                        .Select(p => p.LocalFileName).FirstOrDefault();// 같은 이름을 가져온다

                result = new FilePathVO//VO에 값을 준다
                {
                    FileName = _localFileName,
                    Path = Path.GetFileName(_localFileName),
                    Length = new FileInfo(_localFileName).Length
                };
            }
            return result;//파일 하나 return
        }
    }
    public class UploadFileMultipartProvider : MultipartFormDataStreamProvider
    {
        public UploadFileMultipartProvider(string rootPath) : base(rootPath) { }

        public override string GetLocalFileName(HttpContentHeaders headers)//특수문자 처리해서 업로드한 파일 이름을 가져온다
        {
            if (headers != null &&
                headers.ContentDisposition != null)
            {
                return headers
                    .ContentDisposition
                    .FileName.TrimEnd('"').TrimStart('"');
            }

            return base.GetLocalFileName(headers);
        }
    }
}