using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace EmailDemo.Controllers
{
    [RoutePrefix("api/MailMessage")]
    public class MailMessageController : ApiController
    {
        // GET: api/MailMessage/5
        [HttpGet]
        [Route("TextFileTest")]
        public IHttpActionResult TextFileText()
        {

            string someTextToSendAsAFile = "Hello world";
            byte[] textAsBytes = Encoding.Unicode.GetBytes(someTextToSendAsAFile);

            MemoryStream stream = new MemoryStream(textAsBytes);

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "WebApi2GeneratedFile.txt"
            };
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");

            ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);
            return responseMessageResult;
            //return Ok("");
        }

   }
}
