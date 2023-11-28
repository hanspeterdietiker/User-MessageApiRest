using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MessageAPI.Services.AuthSmsService
{
    public class AuthSmsService
    {
        private readonly string accountSid;
        private readonly string authToken;
        private readonly string twilioPhoneNumber;

        public AuthSmsService(string accountSid, string authToken, string twilioPhoneNumber)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.twilioPhoneNumber = twilioPhoneNumber;
        }
    }
}
