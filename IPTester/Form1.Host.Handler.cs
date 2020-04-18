using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTester
{
    partial class Form1
    {

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Enabled = checkBox22.Checked;
            if (textBox12.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            textBox11.Enabled = checkBox21.Checked;
            if (textBox11.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }
        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.Enabled = checkBox20.Checked;
            if(textBox10.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            textBox9.Enabled = checkBox19.Checked;
            if (textBox9.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            textBox8.Enabled = checkBox18.Checked;
            if (textBox8.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.Enabled = checkBox17.Checked;
            if (textBox7.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            textBox6.Enabled = checkBox16.Checked;
            if (textBox6.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = checkBox15.Checked;
            if (textBox5.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = checkBox14.Checked;
            if (textBox4.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = checkBox13.Checked;
            if (textBox3.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox12.Checked;
            if (textBox2.Enabled)
            {
                hostMaxRate++;
            }
            else
            {
                hostMaxRate--;
            }
        }

        //Класова - безкласова flag
        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            genHosts();
            if (!checkBox11.Checked)
            {
                checkBox11.Text = "Класова IP-адресація";
                checkBox22.Checked = true;
                checkBox22.Enabled = true;
            }
            else
            {
                checkBox11.Text = "Безкласова IP-адресація";
                checkBox22.Checked = false;
                checkBox22.Enabled = false;
            }
        }

        bool validationBox(ref TextBox box)
        {
            if (box.Text == box.AccessibleName)
                return true;
            return false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            setCorrectMask();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            setCorrectMask();
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            validatorNetAddr();
            setIpAddrValid();

            setMinMaxBroadAddr();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            validatorHostAddr();
            setIpAddrValid();

            setMinMaxBroadAddr();

        }

        void setIpAddrValid()
        {
            int[] ipAddr = new int[4];

            for (int i = 0; i < ipAddr.Length; i++)
            {
                ipAddr[i] = netAddrHost[i] + hostAddrHost[i];
            }
            textBox11.AccessibleName = String.Join(".", ipAddr);
        }

        void setMinMaxBroadAddr()
        {
            textBox7.AccessibleName = String.Join(".", getMinAddres(netAddrHost));
            textBox9.AccessibleName = String.Join(".", getBroadcastAddres(netAddrHost));
            textBox8.AccessibleName = String.Join(".", getMaxAddres(getBroadcastAddres(netAddrHost)));
        }

        private void rateHostMeth()
        {
            blockBox();
            lockedTab = false;
            timerStop();
            sumbit_host.Enabled = false;
            float Rate = 0;
            if (checkBox12.Checked && validationBox(ref textBox2))
                Rate += 1;
            if (checkBox13.Checked && validationBox(ref textBox3))
                Rate += 1;
            if (checkBox14.Checked && validationBox(ref textBox4))
                Rate += 1;
            if (checkBox15.Checked && validationBox(ref textBox5))
                Rate += 1;
            if (checkBox16.Checked && validationBox(ref textBox6))
                Rate += 1;
            if (checkBox20.Checked && validationBox(ref textBox10))
                Rate += 1;

            if (validationBox(ref textBox5) && validationBox(ref textBox6))
            {
                if (checkBox21.Checked && validationBox(ref textBox11))
                    Rate += 1;
            }

            if (validationBox(ref textBox5))
            {
                if (checkBox17.Checked && validationBox(ref textBox7))
                    Rate += 1;
                if (checkBox18.Checked && validationBox(ref textBox8))
                    Rate += 1;
                if (checkBox19.Checked && validationBox(ref textBox9))
                    Rate += 1;
            }

            if (checkBox22.Checked && validationBox(ref textBox12))
                Rate += 1;

            rateHost.Text = (int)((Rate / hostMaxRate) * 100) + "%";
        }

        private void sumbit_host_Click(object sender, EventArgs e)
        {
            rateHostMeth();
        }
    }
}
