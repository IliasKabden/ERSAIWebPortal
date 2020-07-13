using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClients.SMTP
{
    public class EmailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ToCC { get; set; }
        public string ToBCC { get; set; }
        /// <summary>
        /// True by default
        /// </summary>
        public bool HTML { get; set; } = true;
        public MessageHeader Header { get; set; }
        public MessageFooter Footer { get; set; }

        public string BodyWithHeaderAndFooter
        {
            get
            {
                var newLine = HTML ? "<br>" : Environment.NewLine;
                return $"{(Header?.Content + newLine) ?? ""}{Body}{(Footer != null ? (newLine + Footer.Content) : "")}";
            }
        }
    }
    public class MessageHeader
    {
        public string Content { get; set; }
        public static MessageHeader GetDefault(string FullName)
        {
            return new MessageHeader()
            {
                Content = $"<div style='font-family:tahoma; font-size:12px;'>Dear {FullName},<br>"
            };
        }
    }
    public class MessageFooter
    {
        public string Content { get; set; }
        public static MessageFooter GetDefault()
        {
            return new MessageFooter()
            {
                Content = "<br>This email can't receive replies. <span style='font-weight:bold;color:#FF0000;'>DO NOT REPLY</span> to this notification message.<br>Best regards,<br>ERSAI/SAKAZ Collaboration"
            };
        }
    }
}