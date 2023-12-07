using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


/*
 * Take the following IPv4 address: 128.32.10.1
 *
 * This address has 4 octets where each octet is a single byte (or 8 bits).
 *
 * 1st octet 128 has the binary representation: 10000000
 * 2nd octet 32 has the binary representation: 00100000
 * 3rd octet 10 has the binary representation: 00001010
 * 4th octet 1 has the binary representation: 00000001
 * So 128.32.10.1 == 10000000.00100000.00001010.00000001
 * 
 * Because the above IP address has 32 bits,
 * we can represent it as the unsigned 32 bit number: 2149583361
 * Complete the function that takes an unsigned 32 bit number and returns a string
 * representation of its IPv4 address.
 * 
 * 2149583361 ==> "128.32.10.1"
 * 32         ==> "0.0.0.32"
 * 0          ==> "0.0.0.0"
 * 
 */


// 10000000.00100000.00001010.00000001
// 10000000.00100000.00001010.00000001
// 10000000.00100000.00001010.00000001

namespace code_wars
{
    internal static class _5_kyu_int32_to_IPv4
    {
        internal static string UInt32ToIP(double ipAddress)
        {
            string binaryNumber = "";
            double ipAddressCumulative = 0;
            const uint two = 2;
            
            for (int i = 31; i >= 0; i--)
            {
                // 'decimalRepresentation' is actually always a multiple of 2. (2^some_number)
                double decimalRepresentation = Math.Pow(two, i);
                if (decimalRepresentation + ipAddressCumulative <= ipAddress)
                {
                    binaryNumber += "1";
                    ipAddressCumulative += decimalRepresentation;
                }
                else
                {
                    binaryNumber += "0";
                }
            }

            double octet_1 = 0;
            double octet_2 = 0;
            double octet_3 = 0;
            double octet_4 = 0;

            int reverseIndex = 31;

            for (int i = 0; i <= reverseIndex; i++)
            {
                if (binaryNumber[i] == '1')
                {
                    if (0 <= i && i < 8) { octet_1 += Math.Pow(two, reverseIndex - i - 24); }
                    else if (8 <= i && i < 16) { octet_2 += Math.Pow(two, reverseIndex - i - 16); }
                    else if (16 <= i && i < 24) { octet_3 += Math.Pow(two, reverseIndex - i - 8); }
                    else if (24 <= i && i < 32) { octet_4 += Math.Pow(two, reverseIndex - i); }
                }
            }

            return $"{octet_1}.{octet_2}.{octet_3}.{octet_4}";


            // BEST PRACTISE:
            /*
            {
                public static string UInt32ToIP(uint ip)
                    => IPAddress.Parse(ip.ToString()).ToString();
            }
            */
        }
    }
}
