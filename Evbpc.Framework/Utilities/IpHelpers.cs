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
        /// <returns>The hexadecimal representation of the IP address.</returns>
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

        /// <summary>
        /// Converts an IPv4 string to the hexadecimal equivalent.
        /// </summary>
        /// <param name="ip">The IP to convert.</param>
        /// <returns>The hexadecimal representation of the IP address.</returns>
        public static string Ip4ToHex(string ip) => Ip6ToHex(Ip4ToIp6(ip));

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
        /// <returns>The hexadecimal string representing the IPv6 address.</returns>
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
