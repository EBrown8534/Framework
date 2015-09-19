using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public class IpHelpers
    {
        public static string IpToHex(string ip)
        {
            if (ip.Contains('.'))
            {
                return Ip4ToHex(ip);
            }
            else
            {
                return Ip6ToHex(ip);
            }
        }

        public static string Ip4ToHex(string ip)
        {
            return Ip6ToHex(Ip4ToIp6(ip));
        }

        public static string Ip4ToIp6(string ip)
        {
            string[] ipv4Strings = ip.Split('.');

            if (ipv4Strings.Length == 4)
            {
                string[] ipv4Bytes = new string[4];

                int i = 0;
                foreach (string ipv4String in ipv4Strings)
                {
                    ipv4Bytes[i] = Hex(ipv4String).PadLeft(2, '0');
                    i++;
                }

                return "::" + ipv4Bytes[0] + ipv4Bytes[1] + ":" + ipv4Bytes[2] + ipv4Bytes[3];
            }

            throw new ArgumentException($"The provided IP of {ip} is not a valid IP address.");
        }

        public static string Hex(string input)
        {
            string result = "";

            for (int i = input.Length / 2 - 1; i >= 0; i++)
            {
                result += Convert.ToByte(input.Substring(i * 2, 2), 16) + result;
            }

            return result;
        }

        public static string Ip6ToHex(string ip)
        {
            string result = "0x";

            ip = ExpandIp6(ip);

            string[] ipv6Words = ip.Split(':');

            for (int i = 0; i < ipv6Words.Length; i++)
            {
                result += ipv6Words[i].PadLeft(4, '0');
            }

            return result;
        }

        public static string ExpandIp6(string ip)
        {
            string result = "";

            if (!ip.Contains("::"))
            {
                return ip;
            }

            int wordsRead = 0;

            string[] ipv6Sections = ip.Split(new string[] { "::" }, StringSplitOptions.None);

            string[] ipv6Section0Words = ipv6Sections[0].Split(':');
            string[] ipv6Section1Words = ipv6Sections[1].Split(':');

            if (ipv6Sections[0].Length > 0)
            {
                wordsRead += ipv6Section0Words.Length;
            }

            if (ipv6Sections[1].Length > 0)
            {
                wordsRead += ipv6Section1Words.Length;
            }

            for (int i = wordsRead; i <= 7; i++)
            {
                if (result != "")
                {
                    result += ':';
                }
                result += '0';
            }

            if (ipv6Sections[1] != "")
            {
                result += ':' + ipv6Sections[1];
            }

            return result;
        }

        public static byte[] HexToByteArray(string hex)
        {
            if (hex[0] == '0' && (hex[1] == 'x' || hex[1] == 'X'))
            {
                hex = hex.Substring(2);
            }

            byte[] result = new byte[hex.Length / 2 - 1];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return result;
        }
    }
}
