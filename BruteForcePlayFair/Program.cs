using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruteForcePlayFair
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "aaaa";
            string cipherText = "UGVWE PSLBI LMSQI FRPWN HEISI GSPNT GRRLO KPKMT UZREN ALGUS IDEPNEGSPE SILUS IXAGZ CLMTE CADTM GAHES XEPTA GIAHY TWCFT STHCE LRLFTTMUIX DME ".Replace(" ", "").ToLower();

            string plaintext = "";
            string plainword = "POPOR";

            if (File.Exists("output.txt"))
                File.Delete("output.txt");

            do
            {
                EncryptionAlgorithms.PlayFair pf = new EncryptionAlgorithms.PlayFair(key);
                plaintext = pf.Decrypt(cipherText);
                if (plaintext.Contains(plainword.ToLower()))
                {
                    //Console.WriteLine(key);
                    //Console.WriteLine(plaintext);
                    File.AppendAllText("output.txt", "key: " + key + "\nplaintext: " + plaintext.Replace("x", "") + "\n");
                }
                key = incrementKey(key).ToLower();
            }
            while (key.Length == 4);

            ////print plain text
            //Console.WriteLine(key);
            //Console.WriteLine();
            //Console.WriteLine(plaintext.Replace("x", ""));
            //Console.ReadKey();
        }

        static string incrementKey(string key)
        {
            int keysize = key.Length;

            string maxKey = new string('z', keysize);

            if (key.Equals(maxKey))
            {
                key = new string('a', keysize + 1);
                return key;
            }
            else
            {
                StringBuilder sb = new StringBuilder(key);

                for (int i = sb.Length - 1; i >= 0; i--)
                {
                    if(sb[i] == 'z')
                    {
                        sb[i] = 'a';
                    }
                    else
                    {
                        sb[i]++;
                        if (sb[i] == 'j')
                            sb[i]++;
                        break;
                    }
                }

                return sb.ToString();
            }

        }
        
    }
}
