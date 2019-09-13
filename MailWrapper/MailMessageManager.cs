using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MailKit;
using MimeKit;

namespace MailWrapper
{
    public class MailMessageManager
    {
        private string _basePath;



        public MailMessageManager(string basePath) {

            this._basePath = basePath;
        }

        public MimeMessage GetMailMessage()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("John Doe", "john.doe@something.com"));
            message.To.Add(new MailboxAddress("Jane Doe", "jane.doe@something.com"));
            message.Subject = "This is a test subject..";

            message.Body = new TextPart("html")
            {
                 Text = "<div>test</div>"
            };

            message.Headers.Add("X-Unsent", "1");

            return message;

        }

        public MimeMessage GetMailMessageWithAttachments()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("John Doe", "john.doe@something.com"));
            message.To.Add(new MailboxAddress("Jane Doe", "jane.doe@something.com"));
            message.Subject = "This is a test subject..";

            var builder = new BodyBuilder();

            builder.HtmlBody = "<div>This is a test HTML content</div>";
            builder.TextBody = "This is a test PLAIN content";

            // attach PDF
            builder.Attachments.Add(_basePath + @"\test_doc_1.pdf");

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();

            //must have or Send button will not show up
            message.Headers.Add("X-Unsent", "1");

            return message;

        }



        public bool VerifyMailMessage (Stream s)
        {
            var message = MimeMessage.Load(s);

            return true;
        }

    }
}
