using System;
using System.Globalization;
using System.Text;

namespace JWTGenerator
{
    public static class ExtensionMethods
    {
        public static byte[] HexDecode(this string input)
        {
            var bytes = new byte[input.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(input.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            return bytes;
        }

        public static string EncodeToBase64(this byte[] input, bool urlSafe = false)
        {
            var base64String = input.AsString();
            if (urlSafe)
            {
                base64String = base64String.Split('=')[0];
                base64String = base64String.Replace('+', '-');
                base64String = base64String.Replace('/', '_');
            }
            return base64String;
        }

        public static byte[] AsByteArray(this string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        public static string AsString(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }
    }
}
