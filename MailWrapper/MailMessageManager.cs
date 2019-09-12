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

        public MimeMessage GetMailMessage()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey", "joey@friends.com"));
            message.To.Add(new MailboxAddress("Alice", "alice@wonderland.com"));
            message.Subject = "How you doin?";

            //message.Body = new TextPart("plain")
            //{
            //    Text = @"Hey Alice,

            //            What are you up to this weekend? Monica is throwing one of her parties on
            //            Saturday and I was hoping you could make it.

            //            Will you be my +1?

            //            -- Joey
            //            "
            //};

            message.Body = new TextPart("html")
            {
                 Text = "<div>test</div>"
            };

            return message;


            //MemoryStream stream = new MemoryStream();

            //message.WriteTo(stream);

        }

        public bool VerifyMailMessage (Stream s)
        {
            var message = MimeMessage.Load(s);

            return true;
        }

    }
}
