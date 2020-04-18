using System;
using System.Collections.Generic;

namespace IPTester
{
    public class Task05
    {
        public string IPaddr = "";
        public string mask = "";
        public double Kv, Kp = 0;
        public string nullsIP, minIP, maxIP, broadcast ="";
        public string nullsIP_bin, minIP_bin, maxIP_bin, broadcast_bin = "";
        public int P = 0; //кількість бітів, які виділені для формування класового префікса мережі.
        public int N = 0; //кількість бітів, які виділені для адресації IP-мережі (номер мережі)
        public int S = 0; //кількість бітів S, що виділяються для адресації підмереж
        public int H = 0; // кількість бітів H, що виділяються для адресації вузлів
        int X;
        string X2;

        public void Randoms()
        {
            Random rnd = new Random();
            List<string> IPadresses = new List<string>();
            List<int> KVs = new List<int>();

            IPadresses.Add("220.10.160.0");
            IPadresses.Add("200.160.10.0");
            IPadresses.Add("180.20.0.0");
            IPadresses.Add("155.170.0.0");
            IPadresses.Add("100.0.0.0");
            IPadresses.Add("75.0.0.0");
            IPadresses.Add("215.40.190.0");
            IPadresses.Add("205.190.40.0");
            IPadresses.Add("175.50.0.0");
            IPadresses.Add("150.200.0.0");
            IPadresses.Add("95.0.0.0");
            IPadresses.Add("70.0.0.0");
            IPadresses.Add("210.70.220.0");
            IPadresses.Add("210.220.70.0");
            IPadresses.Add("170.80.0.0");
            IPadresses.Add("145.230.0.0");
            IPadresses.Add("90.0.0.0");
            IPadresses.Add("65.0.0.0");
            IPadresses.Add("205.100.250.0");
            IPadresses.Add("215.250.100.0");
            IPadresses.Add("165.110.0.0");
            IPadresses.Add("140.130.0.0");
            IPadresses.Add("85.0.0.0");
            IPadresses.Add("60.0.0.0");
            IPadresses.Add("200.130.140.0");
            IPadresses.Add("220.140.130.0");
            IPadresses.Add("160.140.0.0");
            IPadresses.Add("135.145.0.0");
            IPadresses.Add("80.0.0.0");
            IPadresses.Add("55.0.0.0");
            KVs.Add(60);
            KVs.Add(10);
            KVs.Add(1000);
            KVs.Add(6000);
            KVs.Add(5000);
            KVs.Add(9000);
            KVs.Add(100);
            KVs.Add(30);
            KVs.Add(500);
            KVs.Add(12000);
            KVs.Add(8000);
            KVs.Add(12000);
            KVs.Add(30);
            KVs.Add(90);
            KVs.Add(900);
            KVs.Add(900);
            KVs.Add(10000);
            KVs.Add(90000);
            KVs.Add(120);
            KVs.Add(60);
            KVs.Add(4000);
            KVs.Add(3600);
            KVs.Add(4000);
            KVs.Add(3600);
            KVs.Add(20);
            KVs.Add(10);
            KVs.Add(1500);
            KVs.Add(16000);
            KVs.Add(2500);
            KVs.Add(16000);
            int tmp = rnd.Next(0, IPadresses.Count);
            IPaddr = IPadresses[tmp];
            Kv = KVs[tmp];


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
        public void getXandX2()
        {
            X = Convert.ToInt32(Kv)+ 2 - 1;
            X2 = Convert.ToString(X, 2);
            H = X2.Length;
        }
        string IPaddrToBin(string IP)
        {
            int a, b, c, d = 0;
            string a1, b1, c1, d1 = "";
            string str = IP;
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
            return str;
        }
        string BinToIPAddr(string Bin)
        {
            string resut = "";
            resut += Convert.ToString(Convert.ToInt32(Bin.Substring(0, 8), 2));
            resut += ".";
            resut += Convert.ToString(Convert.ToInt32(Bin.Substring(8, 8), 2));
            resut += ".";
            resut += Convert.ToString(Convert.ToInt32(Bin.Substring(16, 8), 2));
            resut += ".";
            resut += Convert.ToString(Convert.ToInt32(Bin.Substring(24, 8), 2));
            return resut;

        }

        public void final_res()
        {
            S = 32 - H - N;
            P = N + S;
            Kp = Math.Pow(2, Convert.ToDouble(S));
            Kv = Math.Pow(2, Convert.ToDouble(H)) - 2;
            string header= IPaddrToBin(IPaddr).Substring(0, N);
            nullsIP_bin = header; minIP_bin = header; maxIP_bin = header; broadcast_bin = header;
            string maskBin = "";
            for (int i = 0; i< S; i++) //для последней подсети
            {
                nullsIP_bin += "1";
                minIP_bin += "1";
                maxIP_bin += "1";
                broadcast_bin += "1";
            }
            for(int i = 0; i< H; i++)
            {
                nullsIP_bin += "0";
                minIP_bin += (i == H - 1) ? "1" : "0";
                maxIP_bin += (i == H - 1) ? "0" : "1";
                broadcast_bin += "1";
            }
            nullsIP = BinToIPAddr(nullsIP_bin);
            minIP = BinToIPAddr(minIP_bin);
            maxIP = BinToIPAddr(maxIP_bin);
            broadcast = BinToIPAddr(broadcast_bin);
            for(int i = 0; i < N + S;i++)
            {
                maskBin += "1";

            }
            for(int i = 0; i < H; i++)
            {
                maskBin += "0";
            }
            mask = BinToIPAddr(maskBin);
            


        }
    }
}
