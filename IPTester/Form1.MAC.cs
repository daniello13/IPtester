using System;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTester
{
    partial class Form1
    {
        byte[] currentMAC = new byte[6];
        bool global_local, unicast_multicast;
        string[] strMACarr = new string[6];
        string MACstr;


        private void genMAC_Click(object sender, EventArgs e)
        { 
            GenMAC();
        }
        void GenMAC()
        {
            mac1.Enabled = true;
            mac2.Enabled = true;
            lockedTab = true;
            timerStart();

            for (int i = 0; i < 6; i++)
            {
                currentMAC[i] = (byte)random.Next(0, 255);
                strMACarr[i] = Convert.ToString(currentMAC[i], 16);
                if (strMACarr[i].Length == 1)
                {
                    strMACarr[i] = "0" + strMACarr[i];
                }
            }
            MACstr = String.Join(":",strMACarr);
            MACText.Text = MACstr.ToUpper();
            setFlags();

            sumbit_mac.Enabled = true;
        }

        void setFlags()
        {
            if ((currentMAC[0] & 0b10) == 0b10)
            {
                global_local = false;
            }
            else
            {
                global_local = true;
            }

            if ((currentMAC[0] & 0b1) == 0b1)
            {
                unicast_multicast = false;
            }
            else
            {
                unicast_multicast = true;
            }
        }

        private void rateMac()
        {
            mac1.Enabled = false;
            mac2.Enabled = false;
            lockedTab = false;
            timerStop();
            sumbit_mac.Enabled = false;
            float rate = 0;
            if (globalUnic.Checked == global_local)
                rate += 1;
            if (unicast.Checked == unicast_multicast)
                rate += 1;
            rateMAC.Text = (int)((rate / 2) * 100) + "%";
        }

        private void sumbit_mac_Click(object sender, EventArgs e)
        {
            rateMac();
        }
    }
}

