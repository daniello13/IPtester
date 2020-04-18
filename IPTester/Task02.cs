using System;
using System.Collections.Generic;

namespace IPTester
{
    public class Task02
    {
        public string IPaddr = "";
        public string mask = "";
        public string maskBin = "";
        public int P = 0; //кількість бітів, які виділені для формування класового префікса мережі.
        public int N = 0; //кількість бітів, які виділені для адресації IP-мережі (номер мережі)
        public int S = 0; //кількість бітів S, що виділяються для адресації підмереж
        public int H = 0; // кількість бітів H, що виділяються для адресації вузлів
        public double Ks = 0; //Кількість підмереж
        public double Kh; //Кількість вузлів(IP-адрес вузлів) однієї підмережі
        public double Khr; //Кількість вузлів(IP-адрес вузлів) загалом
        public int Y = 0;
        public string Y2 = "";

        public void Randoms()
        {
            Random rnd = new Random();
            List<string> IPadresses = new List<string>();
            List<int> ks = new List<int>();
            IPadresses.Add("220.10.160.0");
            IPadresses.Add("180.20.0.0");
            IPadresses.Add("100.0.0.0");
            IPadresses.Add("215.40.190.0");
            IPadresses.Add("175.50.0.0");
            IPadresses.Add("95.0.0.0");
            IPadresses.Add("210.70.220.0");
            IPadresses.Add("170.80.0.0");
            IPadresses.Add("90.0.0.0");
            IPadresses.Add("205.100.250.0");
            IPadresses.Add("165.110.0.0");
            IPadresses.Add("85.0.0.0");
            IPadresses.Add("200.130.140.0");
            IPadresses.Add("160.140.0.0");
            IPadresses.Add("80.0.0.0");
            IPadresses.Add("200.160.10.0");
            IPadresses.Add("155.170.0.0");
            IPadresses.Add("75.0.0.0");
            IPadresses.Add("205.190.40.0");
            IPadresses.Add("150.200.0.0");
            IPadresses.Add("70.0.0.0");
            IPadresses.Add("210.220.70.0");
            IPadresses.Add("145.230.0.0");
            IPadresses.Add("65.0.0.0");
            IPadresses.Add("215.250.100.0");
            IPadresses.Add("140.130.0.0");
            IPadresses.Add("60.0.0.0");
            IPadresses.Add("220.140.130.0");
            IPadresses.Add("135.145.0.0");
            IPadresses.Add("55.0.0.0");

            ks.Add(64);
            ks.Add(32);
            ks.Add(16);
            ks.Add(8);
            ks.Add(4);
            ks.Add(2);
            ks.Add(64);
            ks.Add(32);
            ks.Add(16);
            ks.Add(8);
            ks.Add(4);
            ks.Add(2);
            ks.Add(64);
            ks.Add(32);
            ks.Add(16);
            ks.Add(8);
            ks.Add(4);
            ks.Add(2);
            ks.Add(64);
            ks.Add(32);
            ks.Add(16);
            ks.Add(8);
            ks.Add(4);
            ks.Add(2);
            ks.Add(64);
            ks.Add(32);
            ks.Add(16);
            ks.Add(8);
            ks.Add(4);
            ks.Add(2);
            int tmp = rnd.Next(0, ks.Count);
            IPaddr = IPadresses[tmp];
            Ks = ks[tmp];
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
        public void getY2andS()
        {
            Y = Convert.ToInt32(Ks) - 1;
            Y2 = Convert.ToString(Y, 2);
            S = Y2.Length;
        }
        public void final_result()
        {
            P = N + S;
            for(int i = 0; i < P; i++)
            {
                maskBin += "1";
            }
            int dopoln = 32 - P;
            for (int i = 0; i < dopoln; i++)
            {
                maskBin += "0";
            }
            for (int i = 0; i < 4; i ++)
            {
                string tmp = maskBin.Substring(8*i, 8);
                int byte0 = Convert.ToInt32(tmp, 2);
                mask += Convert.ToString(byte0) + ".";
            }
            mask = mask.Substring(0, mask.Length-1);
            H = 32 - N - S;
            Kh = Math.Pow(2, Convert.ToDouble(H)) - 2;
            Khr = Kh * Ks;

        }
    }
}
