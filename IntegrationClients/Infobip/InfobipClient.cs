using Infobip.Api.Client;
using Infobip.Api.Config;
using Infobip.Api.Model.Sms.Mt.Send;
using Infobip.Api.Model.Sms.Mt.Send.Textual;
using IntegrationClients.Infobip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationClients
{
    public class InfobipClient
    {
        private Configuration config;
        private string FromDefaultAddress;
        public InfobipClient(Configuration config, string FromDefaultAddress)
        {
            this.config = config;
            this.FromDefaultAddress = FromDefaultAddress;
        }
        public async Task<SMSResponse> SendSMS(SMSMessage message)
        {
            var SMSSendRequest = new SendSingleTextualSms(config);
            return await SMSSendRequest.ExecuteAsync(new SMSTextualRequest()
            {
                CampaignId = message.CampaignID,
                From = message.From ?? FromDefaultAddress,
                OperatorClientId = message.OperatorClientID,
                Text = message.Text,
                To = message.To,
                Transliteration = message.Transliteration
            });
        }
    }
}