using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SnippetsForTesting
{
    public class ESBSaSTokenGen
    {
        public readonly string queueOrTopicUrl; // Format: "https://<service bus namespace>.servicebus.windows.net/<topic name or queue>/messages";
        public readonly string signatureKeyName;
        public readonly string signatureKey;
        public readonly TimeSpan timeToLive = TimeSpan.FromDays(1);

        public ESBSaSTokenGen(string queueOrTopicUrlArg, string signatureKeyNameArg, string signatureKeyArg)
        {
            queueOrTopicUrl = queueOrTopicUrlArg;
            signatureKeyName = signatureKeyNameArg;
            signatureKey = signatureKeyArg;
        }

        public string GetSasToken()
        {
            var expiry = GetExpiry(timeToLive);
            string stringToSign = HttpUtility.UrlEncode(queueOrTopicUrl) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(signatureKey));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}",
            HttpUtility.UrlEncode(queueOrTopicUrl), HttpUtility.UrlEncode(signature), expiry, signatureKeyName);
            return sasToken;
        }

        private static string GetExpiry(TimeSpan ttl)
        {
            TimeSpan expirySinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1) + ttl;
            return Convert.ToString((int)expirySinceEpoch.TotalSeconds);
        }
    }
}
