using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CeasarLab1
{
    internal class Decoder
    {

        public String Decode(String path, String outputpath,int shiftlowercase,int shiftUppercase)
        {
            Dictionary<char, int> letterCountEncrypted = new Dictionary<char, int>();




            using (StreamReader reader = new StreamReader(path))
            {
                StringBuilder stringBuilder = new StringBuilder();
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {

                        char decoder;
                        if (c >= 97 && c <= 122)
                        {
                            decoder = (char)((c - 97 - shiftlowercase + 26) % 26 + 97);

                            // c - 97 is to know the position of a letter in the alphabet, if i 98 -97 we dont know yet the value of 
                            // 98 so by doing 98 - 97 and 1 is the position B and then we doing the shift, the shift for lowercase is 13 
                            // so it will be 1 - 13 = -12 but we want positive value so -12 + 26 = 14  and now we need to add to do the modulo to know the position 
                            //97 + (14 % 26 )  = 111 so b became o

                        }
                        else if (c >= 65 && c <= 90)
                        {

                             decoder = (char)((c - 65 - shiftUppercase + 26) % 26 + 65);
                          

                        }
                        else
                        {
                            decoder = c;
                        }
                        stringBuilder.Append(decoder);
                    }

                    stringBuilder.AppendLine();

                }
                    using (StreamWriter sw = new StreamWriter(outputpath))
                    {

                        sw.WriteLine(stringBuilder.ToString());
                    }

              return stringBuilder.ToString();
            } 
            }
        }
    }
