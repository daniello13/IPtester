using System;
using System.Drawing;
using System.Windows.Forms;

namespace IPTester
{
    public partial class Form1 : Form
    {
        const int TIME = 2700;

        const int LEN4 = 4;
        const int LEN6 = 6;
        const string tmp = "00000000000000000000000000000000";

        int maxRate = 10;
        int Rate;

        int currentTime;

        int TabPageIndex = 1;
        bool lockedTab = false;

        Random random = new Random(DateTime.Now.Millisecond);

        uint[] currentIPv4 = new uint[4];
        string ipClass;
        string ipNetmask;
        string ipInverseMask;
        string netAddr;
        string netAddrBin;
        string hostAddr;
        int prefix;
        uint numberOfHosts;
        string minAddr;
        string maxAddr;
        string broadcastingAddr;

        public Form1()
        {
            InitializeComponent();
            
            /*GenIPv4();
            GenMAC();
            genHosts();*/

        }

        void GenIPv4()
        {
            textBoxIp.Enabled = true;
            lockedTab = true;
            clearTextBox();
            timerStart();

            ip_text.Text = "";
            int max_num;

            if (checkBoxClass.Checked)
                max_num = 223;
            else
                max_num = 255;

            do
            {
                currentIPv4[0] = (uint)random.Next(1, max_num);
            } while (currentIPv4[0] == 127);

            ip_text.Text += '.' + currentIPv4[0].ToString();
            for (int i = 1; i < 3; i++)
            {
                currentIPv4[i] = (uint)random.Next(0, 255);
                ip_text.Text += '.' + currentIPv4[i].ToString();

            }
            currentIPv4[3] = (uint)random.Next(1, 254);
            ip_text.Text += '.' + currentIPv4[3].ToString();

            GetIpClass();
            if (!checkBoxClass.Checked)
            {
                prefix = random.Next(0, 30);
                ipPrefix.Text = '/' + prefix.ToString();
            }
            numberOfHosts = Convert.ToUInt32(Math.Pow(2, 32 - prefix) - 2);
            ip_text.Text = ip_text.Text.Substring(1);

            GetNetMask();
            sumbit.Enabled = true;
        }
        
        void clearTextBox()
        {
            ipClassText.Text = "";
            netmaskText.Text = "";
            inverseMaskText.Text = "";
            ipPrefix.Text = "";
            netAddrText.Text = "";
            hostAddrText.Text = "";
            minAddrText.Text = "";
            maxAddrText.Text = "";
            broadAddrText.Text = "";
            numOfHostText.Text = "";

            ipClassText.ForeColor = SystemColors.WindowText;
            netmaskText.ForeColor = SystemColors.WindowText;
            inverseMaskText.ForeColor = SystemColors.WindowText;
            ipPrefix.ForeColor = SystemColors.WindowText;
            netAddrText.ForeColor = SystemColors.WindowText;
            hostAddrText.ForeColor = SystemColors.WindowText;
            minAddrText.ForeColor = SystemColors.WindowText;
            maxAddrText.ForeColor = SystemColors.WindowText;
            broadAddrText.ForeColor = SystemColors.WindowText;
            numOfHostText.ForeColor = SystemColors.WindowText;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            clearTextBox();

            if (checkBoxClass.Checked)
            {
                checkBoxClass.Text = "Класова IP-адресація";
                ipClassText.ReadOnly = false;
                ipPrefix.ReadOnly = false;
                ipPrefix.Text = "";
                ipClassText.Enabled = true;
                checkBox1.Enabled = true;
                checkBox1.Checked = true;

                checkBox4.Checked = true;
                checkBox4.Enabled = true;

                ipPrefixLabel.Text = "Класовий префікс мережі";
                netmaskLabel.Text = "Пряма класова маска мережі";
                inverseMaskLabel.Text = "Інверсна класова маска мережі";
            }
            else
            {
                checkBoxClass.Text = "Безкласова IP-адресація";
                ipClassText.ReadOnly = true;
                ipPrefix.ReadOnly = true;
                ipPrefixLabel.Text = "Префікс мережі";
                ipPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
                ipClassText.Text = "";
                ipClassText.Enabled = false;
                checkBox1.Enabled = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox4.Enabled = false;

                netmaskLabel.Text = "Пряма маска мережі";
                inverseMaskLabel.Text = "Інверсна маска мережі";
            }
            GenIPv4();
        }

        private void genip_Click(object sender, EventArgs e)
        {
            GenIPv4();
        }

        void GetIpClass()
        {
            if (currentIPv4[0] >= 1 && currentIPv4[0] <= 126)
            {
                ipClass = "A";
                prefix = 8;
            }
            if (currentIPv4[0] >= 128 && currentIPv4[0] <= 191)
            {
                ipClass = "B";
                prefix = 16;
            }
            if (currentIPv4[0] >= 192 && currentIPv4[0] <= 223)
            {
                ipClass = "C";
                prefix = 24;
            }
            if (currentIPv4[0] >= 224 && currentIPv4[0] <= 239)
            {
                ipClass = "D";
            }
            if (currentIPv4[0] >= 240 && currentIPv4[0] <= 247)
            {
                ipClass = "E";
            }
        }

        string getStrMask(int prefix)
        {
            string tmpMask = "";
            for (int i = 0; i < prefix; i++)
            {
                tmpMask += '1';
            }
            return (tmpMask + tmp).Substring(0, 32);
        }

        short[] getByteMask(string mask)
        {
            string[] maskArr = new string[4];
            short[] maskByte = new short[4];
            for (int i = 0; i < 4; i++)
            {
                maskArr[i] = mask.Substring(i * 8, 8);
                maskByte[i] = Convert.ToInt16(maskArr[i], 2);
            }
            return maskByte;
        }

        void GetNetMask()
        {
            ipNetmask = "";
            ipInverseMask = "";
            netAddr = "";
            hostAddr = "";
            netAddrBin = "";


            string tmpMask = getStrMask(prefix);
            string tmpInvertMask = invertStringBits(tmpMask);

            short[] maskByte = getByteMask(tmpMask);
            short[] inverseMaskByte = getByteMask(tmpInvertMask);

            int[] netAddrShort = new int[4];
            int[] hostAddrShort = new int[4];
            for (int i = 0; i < 4; i++)
            { 
                netAddrShort[i] = (int)(maskByte[i] & currentIPv4[i]);
                hostAddrShort[i] = (int)(inverseMaskByte[i] & currentIPv4[i]);

                string ipPart = Convert.ToString(currentIPv4[i], 2);
                string dop = "";
                for (int j = 0; j < 8 - ipPart.Length; j++)
                {
                    dop += '0';
                }
                netAddrBin += dop + ipPart;
            }

            ipNetmask = String.Join(".", maskByte);
            ipInverseMask = String.Join(".", inverseMaskByte);
            netAddr = String.Join(".", netAddrShort);
            hostAddr = String.Join(".", hostAddrShort);

            Console.WriteLine("CurrentIpAddr" + String.Join(".", currentIPv4));
            if (checkBoxClass.Checked) Console.WriteLine("class: " + ipClass);
            Console.WriteLine("netmask: " + ipNetmask);
            Console.WriteLine("inverse: " + ipInverseMask);
            Console.WriteLine("prefix: /" + prefix);
            Console.WriteLine("netaddr: " + netAddr);
            Console.WriteLine("hostAddr: " + hostAddr);

            GetMinMaxAddr();

            Console.WriteLine("num of host: " + numberOfHosts.ToString());
        }

        void GetMinMaxAddr()
        {
            string str = "";
            int len = 32 - prefix - 1;
            for (int i = 0; i < len; i++)
            {
                str += '0';
            }
            str += '1';


            netAddrBin = netAddrBin.Substring(0, prefix);
            netAddrBin += str;
            minAddr = bin2decAddr(netAddrBin);


            str = invertStringBits(str);
            netAddrBin = netAddrBin.Substring(0, prefix);
            netAddrBin += str;
            maxAddr = bin2decAddr(netAddrBin);

            str = str.Replace('0', '1');
            netAddrBin = netAddrBin.Substring(0, prefix);
            netAddrBin += str;
            broadcastingAddr = bin2decAddr(netAddrBin);

            Console.WriteLine("MinAddr: " + minAddr);
            Console.WriteLine("MaxAddr: " + maxAddr);
            Console.WriteLine("broadcastingAddr: " + broadcastingAddr);
        }

        string bin2decAddr(string bin)
        {
            uint[] arrInt = new uint[4];

            for (int i = 0; i < bin.Length / 8; i++)
            {
                arrInt[i] = Convert.ToUInt32(bin.Substring(i * 8, 8), 2);
            }
            return String.Join(".", arrInt);
        }

        string invertStringBits(string str)
        {
            string inverted = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str.Substring(i, 1) == "1")
                    inverted += "0";
                else
                    inverted += "1";
            }
            return inverted;
        }

        private void timerStart()
        {
            currentTime = TIME;
            timer1.Start();
        }

        private void timerStop()
        {
            currentTime = TIME;
            timer1.Stop();

            timeIp.Text = "Час";
            timeHost.Text = "Час";
            timeMac.Text = "Час";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime--;

            string textTime = ((int)(currentTime / 60)).ToString() + ":" + (currentTime % 60).ToString();

            timeIp.Text = textTime;
            timeHost.Text = textTime;
            timeMac.Text = textTime;

            if (currentTime == 0)
            {
                timerStop();

                if (TabPageIndex == 0)
                {
                    RateIp();
                }
                if (TabPageIndex == 1)
                {
                    rateHostMeth();
                }
                if (TabPageIndex == 2)
                {
                    rateMac();
                }
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (lockedTab)
            {
                e.Cancel = true;
            }
            TabPageIndex = e.TabPageIndex;
        }

        private void sumbit_Click(object sender, EventArgs e)
        {

        }

        private void sumbit_Click_1(object sender, EventArgs e)
        {
            RateIp();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        

        private void genHostBtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tt1 = "Для заданої IP-адреси мережі a та маски b визначити кількість IP-підмереж, що входять у дану IP-мережу, та кількість вузлів (IP-адрес вузлів) однієї підмережі.";
            Task01 t1 = new Task01();
            t1.Randoms();
            tt1 = tt1.Replace("a", t1.IPaddr);
            tt1 = tt1.Replace("b", t1.mask);
            label19.Text = tt1;

            string tt2 = "IP-мережу a необхідно розбити на b однакових підмереж, у кожній з яких застосовується максимальна кількість вузлів.\nВизначити префікс та маску підмережі, кількість вузлів(IP-адрес вузлів), які входять в одну підмережу та загальну кількість вузлів(IP - адрес вузлів) у всіх підмережах.";
            Task02 t2 = new Task02();
            t2.Randoms();
            tt2 = tt2.Replace("a", t2.IPaddr);
            tt2 = tt2.Replace("b", Convert.ToString(t2.Ks));
            label24.Text = tt2;

            string tt3 = "IP-мережу a необхідно розбити на підмережі, що у кожній з них функціонує b вузлів. Визначити префікс та маску підмережі, \nкількість підмереж, точну кількість вузлів(IP-адрес вузлів), які входять в одну підмережу та загальну кількість вузлів(IP - адрес вузлів) у всіх підмережах.";
            Task03 t3 = new Task03();
            t3.Randoms();
            tt3 = tt3.Replace("a", t3.IPaddr);
            tt3 = tt3.Replace("b", Convert.ToString(t3.Kh));
            label31.Text = tt3;

            string tt4 = "IP-мережа a розбивається на підмережі з використанням методу CIDR за умови, що CIDR-маска дорівнює b, а маска підмережі c . Визначити CIDR-префікс, \n префікс підмережі та маску, кількість IP-підмереж, кількість вузлів(IP-адрес вузлів), які входять в одну підмережу та загальну кількість вузлів(IP - адрес вузлів) у всіх підмережах.";
            Task04 t4 = new Task04();
            t4.Randoms();
            tt4 = tt4.Replace("a", t4.IPaddr);
            tt4 = tt4.Replace("b", Convert.ToString(t4.CIDRmask));
            tt4 = tt4.Replace("c", Convert.ToString(t4.mask));
            label38.Text = tt4;

            string tt5 = "IP-мережу a розбити на підмережі, у кожній з яких функціонує b вузлів. Визначити такі параметри для останньої підмережі: IP-адресу підмережі, \nмінімальну і максимальну IP-адреси діапазону, що можуть використовуватися для адресації вузлів; широкомовну IP-адресу; префікс та маску підмережі.";
            Task05 t5 = new Task05();
            t5.Randoms();
            tt5 = tt5.Replace("a", t5.IPaddr);
            tt5 = tt5.Replace("b", Convert.ToString(t5.Kv));
            label46.Text = tt5;
        }
    }
}
