using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Helper methods for converting IP addresses.
    /// </summary>
    public class IpHelpers
    {
        /// <summary>
        /// Converts an IP string to the hexadecimal equivalent.
        /// </summary>
        /// <param name="ip">The IP to convert.</param>
        /// <param name="padIp">Determines if IP addresses should be padded to the full width of an IPv6 address. If false leading zero bytes will be removed.</param>
        /// <returns>The hexadecimal representation of the IP address.</returns>
        public static string IpToHex(string ip, bool padIp)
        {
            if (ip.Contains('.'))
            {
                return Ip4ToHex(ip, padIp);
            }
            else
            {
                return Ip6ToHex(ip, padIp);
            }
        }

        /// <summary>
        /// Converts an IPv4 string to the hexadecimal equivalent.
        /// </summary>
        /// <param name="ip">The IP to convert.</param>
        /// <param name="padIp">Determines if IP addresses should be padded to the full width of an IPv6 address. If false leading zero bytes will be removed.</param>
        /// <returns>The hexadecimal representation of the IP address.</returns>
        public static string Ip4ToHex(string ip, bool padIp) => Ip6ToHex(Ip4ToIp6(ip), padIp);

        /// <summary>
        /// Converts an IPv4 address to the IPv6 equivalent.
        /// </summary>
        /// <param name="ip">The IP to convert.</param>
        /// <returns>The converted IP.</returns>
        public static string Ip4ToIp6(string ip)
        {
            string[] ipv4Strings = ip.Split('.');

            if (ipv4Strings.Length == 4)
            {
                string[] ipv4Bytes = StringArrayToHexArray(ipv4Strings);
                return "::" + ipv4Bytes[0] + ipv4Bytes[1] + ":" + ipv4Bytes[2] + ipv4Bytes[3];
            }

            throw new ArgumentException($"The provided IP of {ip} is not a valid IP address.");
        }

        /// <summary>
        /// Converts a string array to a hexadecimal array.
        /// </summary>
        /// <param name="input">The array to convert.</param>
        /// <returns>The hexadecimal equivalent.</returns>
        public static string[] StringArrayToHexArray(string[] input) => input.ToList().Select(x => Convert.ToByte(x, 10).ToString("x")).ToArray();

        /// <summary>
        /// Convets an IPv6 address to a hexadecimal string.
        /// </summary>
        /// <param name="ip">The IP address to convert.</param>
        /// <param name="padIp">Determines if IP addresses should be padded to the full width of an IPv6 address. If false leading zero bytes will be removed.</param>
        /// <returns>The hexadecimal string representing the IPv6 address.</returns>
        public static string Ip6ToHex(string ip, bool padIp)
        {
            string result = "0x";

            ip = ExpandIp6(ip);

            string[] ipv6Words = ip.Split(':');

            for (int i = 0; i < ipv6Words.Length; i++)
            {
                result += ipv6Words[i].PadLeft(4, '0');
            }

            if (!padIp)
            {
                result = StripLeadingZeroes(result);
            }

            return result;
        }

        /// <summary>
        /// Expands an IPv6 address by replacing `::` with the appropriate expansion.
        /// </summary>
        /// <param name="ip">The IPv6 address to expand.</param>
        /// <returns>The expanded IPv6 address.</returns>
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

        /// <summary>
        /// Strips leading zero bytes from a hex string.
        /// </summary>
        /// <param name="input">The hex string to strip.</param>
        /// <returns>A new hex string with leading zero bytes stripped.</returns>
        public static string StripLeadingZeroes(string input)
        {
            string result = "0x";

            if (input.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                input = input.Substring(2);
            }

            bool inIp = false;

            for (int i = 0; i < input.Length; i+=2)
            {
                if (input[i] != '0' || input[i+1] != '0')
                {
                    inIp = true;
                }

                if (inIp)
                {
                    result += input[i];
                    result += input[i + 1];
                }
            }

            return result;
        }

        /// <summary>
        /// Converts a hexadecimal string to a byte array.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>The byte array representing the hexadecimal string.</returns>
        public static byte[] HexToByteArray(string hex)
        {
            if (hex[0] == '0' && (hex[1] == 'x' || hex[1] == 'X'))
            {
                hex = hex.Substring(2);
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return result;
        }
    }
}
