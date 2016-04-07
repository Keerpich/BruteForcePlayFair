using System;
using System.Collections.Generic;
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
            string cipherText = "LOXKT YNKAE RAFSK DPMEB BQNEP MOMPH TEXFS NPOHU TELOP NUPNSYGCLO NLMNB FKMSR AGOPI ABMSU TPQSM MURKG KIRQO FSOQQ UEY ".Replace(" ", "").ToLower();

            string plaintext = "";
            string plainword = "TEHNICE";

            do
            {
                EncryptionAlgorithms.PlayFair pf = new EncryptionAlgorithms.PlayFair(key);
                plaintext = pf.Decrypt(cipherText);
                if (plaintext.Contains(plainword.ToLower()))
                    break;
                key = incrementKey(key).ToLower();
            }
            while (!plaintext.Contains(plainword.ToLower()));

            //print plain text
            Console.WriteLine(key);
            Console.WriteLine();
            Console.WriteLine(plaintext.Replace("x", ""));
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
