using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Implement a function that receives two IPv4 addresses, and returns the number of addresses between them (including the first one, excluding the last one).

All inputs will be valid IPv4 addresses in the form of strings. The last address will always be greater than the first one.

* With input "10.0.0.0", "10.0.0.50"  => return   50 
* With input "10.0.0.0", "10.0.1.0"   => return  256 
* With input "20.0.0.10", "20.0.1.0"  => return  246

*/

namespace code_wars
{
    public static class _5_kyu_count_ip_addresses
    {
        public static long IpsBetween(string ipAddressLower, string ipAddressUpper)
        {
            
            int[] ipLow = Array.ConvertAll(array:ipAddressLower.Split(separator: '.'), converter: int.Parse);
            int[] ipUp = Array.ConvertAll(array:ipAddressUpper.Split(separator: '.'), converter: int.Parse);

            var decimalZip = ipLow.Zip(second: ipUp, 
                resultSelector: (octetLow, octetUp) => (octetLow, octetUp));

            string binaryIpUp = string.Empty;
            string binaryIpLow = string.Empty;
            
            // Convert each address to 32bit each (pad the unused space with zeroes)
            foreach(var item in decimalZip)
            {
                string binlow = Convert.ToString(value: item.octetLow,
                                                toBase: 2);
                if (binlow.Length < 8) binlow = binlow.PadLeft(8, '0');
                binaryIpLow += binlow;
                
                string binup = Convert.ToString(value: item.octetUp,
                                                toBase: 2);
                if (binup.Length < 8) binup = binup.PadLeft(8, '0');
                binaryIpUp += binup;
            }
            
            // Subtract both 32bit addresses to get one 32bit result.
            string binaryResult = string.Empty;
            int borrowedBit = new int();
            for(int i = 31; i >= 0; i--)
            {
                int bitLow = Convert.ToInt32(binaryIpLow[i].ToString());
                int bitUp = Convert.ToInt32(binaryIpUp[i].ToString());
                 
                int resultingBit = new int();
                if (borrowedBit == 1)
                {
                    resultingBit = bitUp - borrowedBit - bitLow;
                }
                else
                {
                    resultingBit = bitUp - bitLow;
                }
                if (resultingBit >= 0) borrowedBit = 0;

                else if (resultingBit == -1)
                {
                    borrowedBit = 1;
                    resultingBit = 1;
                }
                else if (resultingBit == -2)
                {
                    borrowedBit = 1;
                    resultingBit = 0;
                }

                binaryResult += resultingBit.ToString();
            }
            
            // Convert the binary result to base 10.
            long result = new long();
            double power = 0;
            foreach(char bit in binaryResult)
            {
                if (bit == '1')
                {
                result += (long)Math.Pow(2, power);
                }
                power++;
            }            
            return result;
        }
        /*
        BEST PRACTISE
        using System;
        public class CountIPAddresses
        {
           public static long IpsBetween(string start, string end)
           {
               return ConvertIPtoValue(end)-ConvertIPtoValue(start);
           }
           public static long ConvertIPtoValue(string ip){
             string[] s= ip.Split('.');
             var value1 = long.Parse(s[0])*256*256*256;
             var value2 =long.Parse(s[1])*256*256;
             var value3 =long.Parse(s[2])*256;
             var value4 =long.Parse(s[3]);
             return value1+value2+value3+value4;
           }
        }
        */
    }
}
