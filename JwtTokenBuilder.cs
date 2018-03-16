using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JWTGenerator
{
    public class JwtTokenBuilder
    {
        private string _header;
        private string _headerBase64;
        private string _payload;
        private string _payloadBase64;
        private byte[] _secret;

        public string Signature { get; set; }
        public string Header {
            get { return _header; }
            set {
                _header = value;
                _headerBase64 = value.AsByteArray().EncodeToBase64(true);
            }
        }
        public string Payload
        {
            get { return _payload; }
            set
            {
                _payload = value;
                _payloadBase64 = value.AsByteArray().EncodeToBase64(true);
            }
        }


        public JwtTokenBuilder(string secret)
        {
            _secret = secret.AsByteArray();
        }

        public string Generate()
        {
            return $"{_headerBase64}.{_payloadBase64}.{GenerateSignature()}";
        }

        private string GenerateSignature()
        {
            var hasher = new HMACSHA256(_secret);
            var message = $"{_headerBase64}.{_payloadBase64}".AsByteArray();
            var hash = hasher.ComputeHash(message).EncodeToBase64(true);
            return hash;
        }
    }
}
