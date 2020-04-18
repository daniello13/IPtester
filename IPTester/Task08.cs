using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTester
{
    class Task08
    {
        public string IPaddr1 = "";
        public string IPaddr2 = "";
        public string IPaddr3 = "";
        public string IPaddr4 = "";
        public string IPaddr5 = "";
        public int P = 0;
        public string result = "";

        class IPS
        {
            public string IP1 = "";
            public string IP2 = "";
            public string IP3 = "";
            public string IP4 = "";
            public string IP5 = "";
            public IPS(string src)
            {

                IP1 = src.Substring(0, src.IndexOf(","));
                int tmp = src.Length - IP1.Length - 1;
                src = src.Substring(src.IndexOf(",") + 1, tmp);
                IP2 = src.Substring(0, src.IndexOf(","));
                tmp = src.Length - IP2.Length - 1;
                src = src.Substring(src.IndexOf(",") + 1, tmp);
                IP3 = src.Substring(0, src.IndexOf(","));
                tmp = src.Length - IP3.Length - 1;
                src = src.Substring(src.IndexOf(",") + 1, tmp);
                IP4 = src.Substring(0, src.IndexOf(","));
                tmp = src.Length - IP4.Length - 1;
                src = src.Substring(src.IndexOf(",") + 1, tmp);
                IP5 = src;

                ;
            }
        }

        public void Randoms()
        {
            Random rnd = new Random();
            List<IPS> ips = new List<IPS>();
            ips.Add(new IPS("198.162.25.0,198.162.69.0,198.162.28.0,198.162.39.64,198.162.56.128"));
            ips.Add(new IPS("152.45.11.0,152.63.26.0,152.55.1.0,152.39.2.0,152.88.3.0"));
            ips.Add(new IPS("164.12.64.0,164.12.64.0,164.12.69.0,164.12.69.0,164.12.61.0"));
            ips.Add(new IPS("192.98.24.0,192.82.15.0,192.100.26.0,192.88.56.0,192.79.21.0"));
            ips.Add(new IPS("201.202.31.0,201.201.39.0,201.196.38.0,201.222.23.0,201.199.12.0"));
            ips.Add(new IPS("120.152.21.0,120.152.48.0,120.152.39.0,120.152.10.0,120.152.16.0"));
            ips.Add(new IPS("141.152.26.0,141.152.100.0,141.152.56.0,141.152.88.0,141.152.63.0"));
            ips.Add(new IPS("170.171.26.0,170.153.99.0,170.168.33.0,170.159.2.0,170.169.9.0"));
            ips.Add(new IPS("154.2.11.0,154.5.23.0,154.9.2.0,154.13.1.0,154.9.2.0"));
            ips.Add(new IPS("123.168.3.0,123.169.6.0,123.175.25.0,123.170.23.0,123.171.22.0"));
            ips.Add(new IPS("120.120.1.0,120.120.1.0,120.120.1.0,120.120.1.0,120.120.1.0"));
            ips.Add(new IPS("154.155.88.0,154.155.89.0,154.155.86.0,154.155.69.0,154.155.70.0"));
            ips.Add(new IPS("156.64.39.0,156.64.123.0,156.64.100.0,156.64.1.0,156.64.9.0"));
            ips.Add(new IPS("121.12.25.4,121.56.23.8,121.44.2.0,121.91.56.0,121.38.25.0"));
            ips.Add(new IPS("156.123.12.0,156.123.13.0,156.123.25.0,156.123.30.0,156.123.9.0"));
            ips.Add(new IPS("10.10.9.128,10.10.9.64,10.10.9.32,10.10.9.192,10.10.9.0"));
            ips.Add(new IPS("45.26.25.0,45.26.39.0,45.26.11.0,45.26.154.0,45.26.59.0"));
            ips.Add(new IPS("194.56.32.128,194.56.32.64,194.56.32.96,194.56.32.32,194.56.32.0"));
            ips.Add(new IPS("140.125.36.0,140.125.38.0,140.125.31.0,140.125.29.0,140.125.40.0"));
            ips.Add(new IPS("174.189.220.0,174.189.222.0,174.189.219.0,174.189.189.0,174.189.211.0"));
            ips.Add(new IPS("159.123.33.0,159.124.39.0,159.131.2.0,159.10.9.0,159.69.6.0"));
            ips.Add(new IPS("140.176.85.128,140.176.31.0,140.176.16.192,140.176.63.128,140.176.34.0"));
            ips.Add(new IPS("198.162.1.32,198.162.1.64,198.162.1.96,198.162.1.128,198.162.1.180"));
            ips.Add(new IPS("150.123.56.0,150.123.93.0,150.123.89.0,150.123.69.0,150.123.71.0"));

            int tmp = rnd.Next(0, ips.Count);
            IPaddr1 = ips[tmp].IP1;
            IPaddr2 = ips[tmp].IP2;
            IPaddr3 = ips[tmp].IP3;
            IPaddr4 = ips[tmp].IP4;
            IPaddr5 = ips[tmp].IP5;


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
        public void final_result()
        {
            string result_bin="";
            string IP_bin1 = IPaddrToBin(IPaddr1);
            string IP_bin2 = IPaddrToBin(IPaddr2);
            string IP_bin3 = IPaddrToBin(IPaddr3);
            string IP_bin4 = IPaddrToBin(IPaddr4);
            string IP_bin5 = IPaddrToBin(IPaddr5);
            for (int i = 0; i< 32; i++)
            {
                if (IP_bin1[i] == IP_bin2[i] && IP_bin2[i] == IP_bin3[i] && IP_bin3[i] == IP_bin4[i] && IP_bin4[i] == IP_bin5[i])
                    result_bin += IP_bin1[i];
                else
                    break;
                
            }
            P = result_bin.Length;
            for (int i = 0; i < 32 - P; i++)
                result_bin += "0";

            result = BinToIPAddr(result_bin);
        }
    }
}
