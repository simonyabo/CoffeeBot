using System;
using Twilio.Lookups;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot_Application1.Services
{
    public class TwilioLookupService
    {
        public static Number GetNumberInfo(string number)
        {
            var lookupClient = new LookupsClient("AC1a7661b31b926a5830af3df19e54e8a2", "ee3c03f6799bab89090e148c2d623f38");
            var response = lookupClient.GetPhoneNumber(number, true);

            return response;
        }
    }
}