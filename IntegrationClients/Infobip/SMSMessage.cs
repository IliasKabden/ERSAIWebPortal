using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClients.Infobip
{
    public class SMSMessage
    {
        public string CampaignID { get; set; }
        public string From { get; set; }
        public string OperatorClientID { get; set; }
        public string Text { get; set; }
        public IList<string> To { get; set; }
        public string Transliteration { get; set; }
    }
}