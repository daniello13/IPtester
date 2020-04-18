using System;
using System.Collections.Generic;

namespace IPTester
{
    public class Task01
    {
        public string IPaddr = "";
        public string mask = "";
        public int P = 0; //кількість бітів, які виділені для формування класового префікса мережі.
        public int N = 0; //кількість бітів, які виділені для адресації IP-мережі (номер мережі)
        public int S = 0; //кількість бітів S, що виділяються для адресації підмереж
        public int H = 0; // кількість бітів H, що виділяються для адресації вузлів
        public double Ks = 0; //Кількість підмереж
        public double Kh = 0; //Кількість вузлів(IP-адрес вузлів) однієї підмережі

        public Task01()
        {
        }
        public void Randoms()
        {
            Random rnd = new Random();
            List<string> IPadresses = new List<string>();
            List<string> masks = new List<string>();
            IPadresses.Add("10.0.0.0");
            IPadresses.Add("130.20.0.0");
            IPadresses.Add("192.10.1.0");
            IPadresses.Add("15.0.0.0");
            IPadresses.Add("140.50.0.0");
            IPadresses.Add("193.2.20.0");
            IPadresses.Add("20.0.0.0");
            IPadresses.Add("150.80.0.0");
            IPadresses.Add("194.30.3.0");
            IPadresses.Add("25.0.0.0");
            IPadresses.Add("160.110.0.0");
            IPadresses.Add("195.4.40");
            IPadresses.Add("30.0.0.0");
            IPadresses.Add("170.140.0.0");
            IPadresses.Add("196.50.5.0");
            IPadresses.Add("35.0.0.0");
            IPadresses.Add("135.170.0.0");
            IPadresses.Add("197.6.60.0");
            IPadresses.Add("40.0.0.0");
            IPadresses.Add("145.200.0.0");
            IPadresses.Add("198.70.7.0");
            IPadresses.Add("45.0.0.0");
            IPadresses.Add("155.230.0.0");
            IPadresses.Add("199.8.80.0");
            IPadresses.Add("50.0.0.0");
            IPadresses.Add("165.130.0.0");
            IPadresses.Add("200.90.9.0");
            IPadresses.Add("55.0.0.0");
            IPadresses.Add("175.145.0.0");
            IPadresses.Add("201.10.10.0");

            masks.Add("255.128.0.0");
            masks.Add("255.255.128.0");
            masks.Add("255.255.255.128");
            masks.Add("255.192.0.0");
            masks.Add("255.255.192.0");
            masks.Add("255.255.255.192");
            masks.Add("255.224.0.0");
            masks.Add("255.255.224.0");
            masks.Add("255.255.255.224");
            masks.Add("255.240.0.0");
            masks.Add("255.255.240.0");
            masks.Add("255.255.255.240");
            masks.Add("255.248.0.0");
            masks.Add("255.255.248.0");
            masks.Add("255.255.255.248");
            masks.Add("255.128.0.0");
            masks.Add("255.255.128.0");
            masks.Add("255.255.255.128");
            masks.Add("255.192.0.0");
            masks.Add("255.255.192.0");
            masks.Add("255.255.255.192");
            masks.Add("255.224.0.0");
            masks.Add("255.255.224.0");
            masks.Add("255.255.255.224");
            masks.Add("255.240.0.0");
            masks.Add("255.255.240.0");
            masks.Add("255.255.255.240");
            masks.Add("255.248.0.0");
            masks.Add("255.255.248.0");
            masks.Add("255.255.255.248");
            int tmp = rnd.Next(0, masks.Count);
            IPaddr = IPadresses[tmp];
            mask = masks[tmp];
        }
        public void MasktoP()
        {
            int a, b, c, d = 0;
            string a1, b1, c1, d1 = "";
            string str = mask;
            a1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(a1.Length + 1);
            b1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(b1.Length + 1);
            c1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(c1.Length + 1);
            d1 = str;
            a = Convert.ToInt32(a1);
            b = Convert.ToInt32(b1);
            c = Convert.ToInt32(c1);
            d = Convert.ToInt32(d1);
            str = "";

            if (a == 0)
                str += "00000000";
            else
            {
                string tmp = Convert.ToString(a, 2);
                if (tmp.Length < 8)
                {
                    for (int i = 0; i < 8 - tmp.Length; i++)
                        tmp = "0" + tmp;

                }
                str += tmp;
            }
            if (b == 0)
                str += "00000000";
            else
            {
                string tmp = Convert.ToString(b, 2);
                if (tmp.Length < 8)
                {
                    for (int i = 0; i < 8 - tmp.Length; i++)
                        tmp = "0" + tmp;
                }
                str += tmp;
            }
            if (c == 0)
                str += "00000000";
            else
            {
                string tmp = Convert.ToString(c, 2);
                if (tmp.Length < 8)
                {
                    for (int i = 0; i < 8 - tmp.Length; i++)
                        tmp = "0" + tmp;
                }
                str += tmp;
            }
            if (d == 0)
                str += "00000000";
            else
            {
                string tmp = Convert.ToString(d, 2);
                if (tmp.Length < 8)
                {
                    for (int i = 0; i < 8 - tmp.Length; i++)
                        tmp = "0" + tmp;
                }
                str += tmp;
            }
            P = (str.Length - str.Replace("1", "").Length) / "1".Length;
           
        }
        public int classIP()
        {
            int a, b, c, d = 0;
            string a1, b1, c1, d1 = "";
            string str = IPaddr;
            a1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(a1.Length + 1);
            b1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(b1.Length + 1);
            c1 = str.Substring(0, str.IndexOf("."));
            str = str.Substring(c1.Length + 1);
            d1 = str;
            a = Convert.ToInt32(a1);
            b = Convert.ToInt32(b1);
            c = Convert.ToInt32(c1);
            d = Convert.ToInt32(d1);
            if (a >= 1 && a <= 126)
                N = 8;
            else if (a >= 128 && a <= 191)
                N = 16;
            else if (a >= 192 && a <= 223)
                N = 24;
            else
            {
                Console.WriteLine("Этот IP  нельзя отнести к какому-либо классу.");
                return 0;
            }
            return 1;
        }
        public void final_answer()
        {
            S = P - N;
            H = 32 - P;
            Ks = Math.Pow(2, Convert.ToDouble(S));
            Kh = Math.Pow(2, Convert.ToDouble(H))-2;
        }
    }
}
