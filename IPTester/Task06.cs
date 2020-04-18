using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTester
{
    class Task06
    {
        public double Kp = 0;
        public double Kv = 0;
        public int S; //кількість бітів, які виділені для адресації підмереж;
        public int H; //кількість бітів, які виділені для адресації вузлів
        public int P; //кількість бітів, які виділені для формування префікса підмережі.
        public string classv = "";

        public void Randoms()
        {
            Random rnd = new Random();
            List<double> Kps = new List<double>();
            List<double> KVs = new List<double>();
            Kps.Add(8);
            Kps.Add(10);
            Kps.Add(12);
            Kps.Add(14);
            Kps.Add(16);
            Kps.Add(18);
            Kps.Add(7);
            Kps.Add(9);
            Kps.Add(11);
            Kps.Add(13);
            Kps.Add(15);
            Kps.Add(17);
            Kps.Add(19);
            Kps.Add(20);
            Kps.Add(22);
            Kps.Add(24);
            Kps.Add(26);
            Kps.Add(6);
            Kps.Add(13);
            Kps.Add(14);
            Kps.Add(18);
            Kps.Add(50);
            Kps.Add(100);
            Kps.Add(300);
            Kps.Add(500);
            Kps.Add(700);
            Kps.Add(900);
            Kps.Add(200);
            Kps.Add(400);
            Kps.Add(600);

            KVs.Add(500);
            KVs.Add(1000);
            KVs.Add(1500);
            KVs.Add(2000);
            KVs.Add(2500);
            KVs.Add(3000);
            KVs.Add(350);
            KVs.Add(400);
            KVs.Add(450);
            KVs.Add(500);
            KVs.Add(550);
            KVs.Add(600);
            KVs.Add(650);
            KVs.Add(700);
            KVs.Add(750);
            KVs.Add(750);
            KVs.Add(1250);
            KVs.Add(1750);
            KVs.Add(2250);
            KVs.Add(2750);
            KVs.Add(325);
            KVs.Add(375);
            KVs.Add(425);
            KVs.Add(476);
            KVs.Add(525);
            KVs.Add(575);
            KVs.Add(625);
            KVs.Add(675);
            KVs.Add(725);
            KVs.Add(775);
            int tmp = rnd.Next(0, KVs.Count);
            Kv = KVs[tmp];
            Kp = Kps[tmp];
        }
            public void final_result()
        {
            int Y = Convert.ToInt32(Kp) - 1;
            string Y2 = Convert.ToString(Y, 2);
            S = Y2.Length;
            int X = Convert.ToInt32(Kv) + 2 - 1;
            string X2 = Convert.ToString(X, 2);
            H = X2.Length;
            double Kp1, Kp2, Kp3 = 0;
            double Kdif = 0;
            //находим оптимальный вариант
            int Stmp1 = -1;
            int Stmp2 = -1;
            int Stmp3 = -1;
            int N = 0;
            if ((8 + S + H)<=32)
            {
                Stmp1 = (32 - 8 - H);
                Kp1 = Math.Pow(2, Stmp1);
                Kdif = Kp1-Kp;
                N = 8;
            }
            if ((16 + S + H) <= 32)
            {
                Stmp2 = (32 - 16 - H);
                Kp2 = Math.Pow(2, Stmp2);
                if ((Kp2 - Kp) < Kdif)
                {
                    N = 16;
                    Kdif = Kp2 - Kp;
                }
            }
            if ((24 + S + H) <= 32)
            {
                Stmp3 = (32 - 24 - H);
                Kp3 = Math.Pow(2, Stmp3);
                if ((Kp3 - Kp) < Kdif)
                {
                    Kdif = Kp3 - Kp;
                    N = 24;
                }
            }
            double Soptimal = Math.Log(Kdif+Kp, 2);
            S = (int)Soptimal;
            P = N + S;
            if (N == 8)
                classv = "A";
            if (N == 16)
                classv = "B";
            if (N == 24)
                classv = "C";

        }
    }
}
