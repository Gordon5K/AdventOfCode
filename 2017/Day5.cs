using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AOC
{
    class Day5
    {
        readonly string _input = @"reyedfim";

        public object Task1()
        {
            int i = 0;
            StringBuilder password = new();
            while (true)
            {
                var hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(_input + i));
                string hex = BitConverter.ToString(hash);
                hex = hex.Replace("-", "");

                if (hex.Length >= 5 && hex.Substring(0, 5) == "00000")
                {
                    password.Append(hex.Substring(5, 1));
                }
                i++;
                
                if(password.Length == 8)
                {
                    break;
                }
            }

            return password;
            
        }

        public object Task2()
        {
            int i = 0;
            StringBuilder[] password = new StringBuilder[8];
            while (true)
            {
                var hash = MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(_input + i));
                string hex = BitConverter.ToString(hash);
                hex = hex.Replace("-", "");

                if (hex.Length >= 5 && hex.Substring(0, 5) == "00000")
                {
                    if (int.TryParse(hex.Substring(5, 1), out int position) && position >= 0 && position < 8)
                    {
                        password[position].Append((hex.Substring(6, 1))[0]);
                    }
                }
                i++;

                if (password.All(s=>s != null))
                {
                    break;
                }
            }

            return string.Join("", password.Select(s => s.ToString().First()));
        }

    }
}
