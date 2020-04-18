﻿using System;
using System.Collections.Generic;

namespace IPTester
{
    public class Task03
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
        public double Khi; //Точна кількість вузлів (IP-адрес вузлів) однієї підмережі
        public int X = 0;
        public string X2 = "";

        public void Randoms()
        {
            Random rnd = new Random();
            List<string> IPadresses = new List<string>();
            List<double> kh = new List<double>();

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

            kh.Add(60);
            kh.Add(1000);
            kh.Add(5000);
            kh.Add(100);
            kh.Add(500);
            kh.Add(8000);
            kh.Add(30);
            kh.Add(900);
            kh.Add(10000);
            kh.Add(120);
            kh.Add(4000);
            kh.Add(4000);
            kh.Add(20);
            kh.Add(1500);
            kh.Add(2500);
            kh.Add(10);
            kh.Add(6000);
            kh.Add(9000);
            kh.Add(30);
            kh.Add(12000);
            kh.Add(12000);
            kh.Add(90);
            kh.Add(900);
            kh.Add(90000);
            kh.Add(60);
            kh.Add(3600);
            kh.Add(3600);
            kh.Add(10);
            kh.Add(16000);
            kh.Add(16000);

            int tmp = rnd.Next(0, IPadresses.Count);
            IPaddr = IPadresses[tmp];
            Kh = kh[tmp];
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
        public void getX()
        {
            X = Convert.ToInt32(Kh) + 2 - 1;
            X2 =  Convert.ToString(X, 2);
            H = X2.Length;
        }
        public void final_result()
        {
            S = 32 - N - H;
            P = 32 - H;
            //получение маски
            for (int i = 0; i < P; i++)
            {
                maskBin += "1";
            }
            int dopoln = 32 - P;
            for (int i = 0; i < dopoln; i++)
            {
                maskBin += "0";
            }
            for (int i = 0; i < 4; i++)
            {
                string tmp = maskBin.Substring(8 * i, 8);
                int byte0 = Convert.ToInt32(tmp, 2);
                mask += Convert.ToString(byte0) + ".";
            }
            mask = mask.Substring(0, mask.Length - 1);
            Ks = Math.Pow(2, Convert.ToDouble(S));
            Khi = Math.Pow(2, Convert.ToDouble(H))-2;
            Khr = Ks * Khi;
        }
    }
}
