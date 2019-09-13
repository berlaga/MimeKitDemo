using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

using MailWrapper;
using MimeKit;

namespace EmailDemo.Controllers
{
    [RoutePrefix("api/MailMessage")]
    public class MailMessageController : ApiController
    {
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


        [HttpGet]
        [Route("MailMessageTest")]
        public IHttpActionResult MailMessageTest()
        {

            MailMessageManager manager = new MailMessageManager(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data"));

            var message = manager.GetMailMessage();

            MemoryStream streamFinal = new MemoryStream();
            message.WriteTo(streamFinal);
            //must set position back to 0
            streamFinal.Position = 0;

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(streamFinal)

            };
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "WebApi2GeneratedFile.eml",
            };
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("message/rfc822");

            ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);
            return responseMessageResult;
        }


        [HttpGet]
        [Route("MailMessageTestAttachment")]
        public IHttpActionResult MailMessageTestAttachment()
        {

            MailMessageManager manager = new MailMessageManager(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data"));

            var message = manager.GetMailMessageWithAttachments();

            MemoryStream streamFinal = new MemoryStream();
            message.WriteTo(streamFinal);
            //must set position back to 0
            streamFinal.Position = 0;

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(streamFinal)

            };
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "WebApi2GeneratedFile.eml",
            };
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("message/rfc822");

            ResponseMessageResult responseMessageResult = ResponseMessage(httpResponseMessage);
            return responseMessageResult;
        }


    }
}
