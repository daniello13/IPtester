using System;
using System.Collections.Generic;

namespace IPTester
{
    public class Task04
    {
        public string IPaddr = "";
        public string mask = "";
        public string CIDRmask = "";
        public int C; //кількість бітів, які виділені для адресації мережі (номер мережі, CIDR-префікс);
        public int S; //кількість бітів, які виділені для адресації підмереж;
        public int H; //кількість бітів, які виділені для адресації вузлів
        public int P; //кількість бітів, які виділені для формування префікса підмережі.
        public double Kp; //Кількість підмереж
        public double Kv; //Кількість вузлів (IP-адрес вузлів) однієї підмережі
        public double Kz; //загальна кількість вузлів у всіх підмережах

        public void Randoms()
        {
            Random rnd = new Random();
            List<string> IPadresses = new List<string>();
            List<string> CIDRmasks = new List<string>();
            List<string> masks = new List<string>();

            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");
            IPadresses.Add("64.0.0.0");
            IPadresses.Add("128.0.0.0");
            IPadresses.Add("192.0.0.0");

            CIDRmasks.Add("192.0.0.0");
            CIDRmasks.Add("128.0.0.0");
            CIDRmasks.Add("255.224.0.0");
            CIDRmasks.Add("192.0.0.0");
            CIDRmasks.Add("224.0.0.0");
            CIDRmasks.Add("255.128.0.0");
            CIDRmasks.Add("192.0.0.0");
            CIDRmasks.Add("224.0.0.0");
            CIDRmasks.Add("255.128.0.0");
            CIDRmasks.Add("192.0.0.0");
            CIDRmasks.Add("224.0.0.0");
            CIDRmasks.Add("255.128.0.0");
            CIDRmasks.Add("192.0.0.0");
            CIDRmasks.Add("224.0.0.0");
            CIDRmasks.Add("255.128.0.0");
            CIDRmasks.Add("240.0.0.0");
            CIDRmasks.Add("252.0.0.0");
            CIDRmasks.Add("255.255.128.0");
            CIDRmasks.Add("240.0.0.0");
            CIDRmasks.Add("252.0.0.0");
            CIDRmasks.Add("255.255.128.0");
            CIDRmasks.Add("240.0.0.0");
            CIDRmasks.Add("252.0.0.0");
            CIDRmasks.Add("255.255.128.0");
            CIDRmasks.Add("240.0.0.0");
            CIDRmasks.Add("252.0.0.0");
            CIDRmasks.Add("255.255.192.0");
            CIDRmasks.Add("240.0.0.0");
            CIDRmasks.Add("252.0.0.0");
            CIDRmasks.Add("255.255.192.0");

            masks.Add("224.0.0.0");
            masks.Add("192.0.0.0");
            masks.Add("255.240.0.0");
            masks.Add("248.0.0.0");
            masks.Add("248.0.0.0");
            masks.Add("255.240.0.0");
            masks.Add("255.0.0.0");
            masks.Add("255.0.0.0");
            masks.Add("255.255.0.0");
            masks.Add("255.224.0.0");
            masks.Add("255.128.0.0");
            masks.Add("255.255.192.0");
            masks.Add("255.255.0.0");
            masks.Add("255.240.0.0");
            masks.Add("255.255.255.128");
            masks.Add("252.0.0.0");
            masks.Add("255.128.0.0");
            masks.Add("255.255.224.0");
            masks.Add("255.128.0.0");
            masks.Add("255.240.0.0");
            masks.Add("255.255.248.0");
            masks.Add("255.240.0.0");
            masks.Add("255.255.128.0");
            masks.Add("255.255.255.0");
            masks.Add("255.255.0.0");
            masks.Add("255.255.248.0");
            masks.Add("255.255.255.128");
            masks.Add("255.255.128.0");
            masks.Add("255.255.255.0");
            masks.Add("255.255.255.240");

            int tmp = rnd.Next(0, IPadresses.Count);
            IPaddr = IPadresses[tmp];
            CIDRmask = CIDRmasks[tmp];
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
        public void CIDRMasktoC()
        {
            int a, b, c, d = 0;
            string a1, b1, c1, d1 = "";
            string str = CIDRmask;
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

            str += a == 0 ? "00000000" : Convert.ToString(a, 2);
            str += " ";
            str += b == 0 ? "00000000" : Convert.ToString(b, 2);
            str += " ";
            str += c == 0 ? "00000000" : Convert.ToString(c, 2);
            str += " ";
            str += d == 0 ? "00000000" : Convert.ToString(d, 2);
            C = (str.Length - str.Replace("1", "").Length) / "1".Length;

        }
        public void final_result(){
            S = P - C;
            H = 32 - P;
            Kp = Math.Pow(2, Convert.ToDouble(S));
            Kv = Math.Pow(2, Convert.ToDouble(H)) - 2;
            Kz = Kp * Kv;
        }
    }
}
