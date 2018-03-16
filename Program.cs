using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTGenerator
{
    class Program
    {
        private static string HEADER = "{\"alg\":\"HS256\",\"typ\":\"JWT\"}";
        private static string PAYLOAD = "{\"sub\":\"1234567890\",\"name\":\"John Doe\",\"manager\":true}";
        private static string SECRET = "MySuperSecretSigningKey";

        static void Main(string[] args)
        {
            Console.WriteLine($"Setting Secret:  {SECRET}");
            var jwtTokenBuilder = new JwtTokenBuilder(SECRET);

            jwtTokenBuilder.Header = HEADER;
            Console.WriteLine($"Setting Header:  {HEADER}");
            Console.WriteLine($"Header becomes:  {HEADER.AsByteArray().EncodeToBase64(true)}");

            jwtTokenBuilder.Payload = PAYLOAD;
            Console.WriteLine($"Setting Payload: {PAYLOAD}");
            Console.WriteLine($"Payload becomes: {PAYLOAD.AsByteArray().EncodeToBase64(true)}");
            Console.WriteLine("");


            Console.WriteLine($"Combining Header and Payload:");
            Console.WriteLine($"{HEADER.AsByteArray().EncodeToBase64(true)}.{PAYLOAD.AsByteArray().EncodeToBase64(true)}");
            Console.WriteLine($"");

            var token = jwtTokenBuilder.Generate();
            Console.WriteLine($"Generating Signature:");
            Console.WriteLine($"{token.Split('.')[2]}");
            Console.WriteLine($"");

            Console.WriteLine($"JWT generated:");
            Console.WriteLine(token);
            Console.WriteLine($"");
            Console.WriteLine($"You can test the generated JWT on: https://jwt.io/");
            Console.ReadLine();
        }
    }
}
