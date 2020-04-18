using System;
using System.Drawing;
using System.Windows.Forms;

namespace IPTester
{
    public partial class Form1
    {

        //Блок перевірки
        /*

        private void ipClassText_TextChanged(object sender, EventArgs e)
        {
            if (ipClassText.Text == ipClass)
            {
                ipClassText.ForeColor = Color.Green;
            }
            else
            {
                ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void netmaskText_TextChanged(object sender, EventArgs e)
        {
            if (netmaskText.Text == ipNetmask)
            {
                netmaskText.ForeColor = Color.Green;
            }
            else
            {
                netmaskText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void inverseMaskText_TextChanged(object sender, EventArgs e)
        {
            if (inverseMaskText.Text == ipInverseMask)
            {
                inverseMaskText.ForeColor = Color.Green;
            }
            else
            {
                inverseMaskText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void ipPrefix_TextChanged(object sender, EventArgs e)
        {
            if (ipPrefix.Text == prefix.ToString())
            {
                ipPrefix.ForeColor = Color.Green;
            }
            else
            {
                ipPrefix.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void netAddrText_TextChanged(object sender, EventArgs e)
        {
            if (netAddrText.Text == netAddr)
            {
                netAddrText.ForeColor = Color.Green;
            }
            else
            {
                netAddrText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void hostAddrText_TextChanged(object sender, EventArgs e)
        {
            if (hostAddrText.Text == hostAddr)
            {
                hostAddrText.ForeColor = Color.Green;
            }
            else
            {
                hostAddrText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void minAddrText_TextChanged(object sender, EventArgs e)
        {
            if (minAddrText.Text == minAddr)
            {
                minAddrText.ForeColor = Color.Green;
            }
            else
            {
                minAddrText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void maxAddrText_TextChanged(object sender, EventArgs e)
        {
            if (maxAddrText.Text == maxAddr)
            {
                maxAddrText.ForeColor = Color.Green;
            }
            else
            {
                maxAddrText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void broadAddrText_TextChanged(object sender, EventArgs e)
        {
            if (broadAddrText.Text == broadcastingAddr)
            {
                broadAddrText.ForeColor = Color.Green;
            }
            else
            {
                broadAddrText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void numOfHostText_TextChanged(object sender, EventArgs e)
        {
            if (numOfHostText.Text == numberOfHosts.ToString())
            {
                numOfHostText.ForeColor = Color.Green;
            }
            else
            {
                numOfHostText.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }*/

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ipClassText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                ipClassText.Text = "";
                ipClassText.Enabled = false;
                maxRate -= 1;
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                netmaskText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                netmaskText.Text = "";
                netmaskText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                inverseMaskText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                inverseMaskText.Text = "";
                inverseMaskText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                ipPrefix.Enabled = true;
                maxRate += 1;
            }
            else
            {
                ipPrefix.Text = "";
                ipPrefix.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                netAddrText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                netAddrText.Text = "";
                netAddrText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                hostAddrText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                hostAddrText.Text = "";
                hostAddrText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                minAddrText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                minAddrText.Text = "";
                minAddrText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                maxAddrText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                maxAddrText.Text = "";
                maxAddrText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                broadAddrText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                broadAddrText.Text = "";
                broadAddrText.Enabled = false;
                maxRate -= 1;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                numOfHostText.Enabled = true;
                maxRate += 1;
            }
            else
            {
                numOfHostText.Text = "";
                numOfHostText.Enabled = false;
                maxRate -= 1;
            }
        }

        /*private void sumbit_Click(object sender, EventArgs e)
        {
            RateIp();

        }*/

        private void RateIp()
        {
            textBoxIp.Enabled = false;
            lockedTab = false;
            timerStop();
            sumbit.Enabled = false;
            Rate = 0;
            if (checkBox1.Checked)
            {
                if (ipClassText.Text == ipClass)
                {
                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //ipClassText.ForeColor = Color.Red;
                }
            }
            if (checkBox2.Checked)
            {
                if (netmaskText.Text == ipNetmask)
                {
                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //netmaskText.ForeColor = Color.Red;
                }
            }
            if (checkBox3.Checked)
            {
                if (inverseMaskText.Text == ipInverseMask)
                {
                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //inverseMaskText.ForeColor = Color.Red;
                }
            }
            if (checkBox4.Checked)
            {
                if (ipPrefix.Text == prefix.ToString())
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //ipPrefix.ForeColor = Color.Red;
                }
            }

            if (checkBox5.Checked)
            {
                if (netAddrText.Text == netAddr)
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //netAddrText.ForeColor = Color.Red;
                }
            }
            if (checkBox6.Checked)
            {
                if (hostAddrText.Text == hostAddr)
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //hostAddrText.ForeColor = Color.Red;
                }
            }
            if (checkBox7.Checked)
            {
                if (minAddrText.Text == minAddr)
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //minAddrText.ForeColor = Color.Red;
                }
            }
            if (checkBox8.Checked)
            {
                if (maxAddrText.Text == maxAddr)
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //maxAddrText.ForeColor = Color.Red;
                }
            }
            if (checkBox9.Checked)
            {
                if (broadAddrText.Text == broadcastingAddr)
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //broadAddrText.ForeColor = Color.Red;
                }
            }

            if (checkBox10.Checked)
            {
                if (numOfHostText.Text == numberOfHosts.ToString())
                {

                    //ipClassText.ForeColor = System.Drawing.SystemColors.WindowText;
                    Rate++;
                }
                else
                {
                    //numOfHostText.ForeColor = Color.Red;
                }
            }

            rateLabel.Text = Convert.ToInt16(((float)Rate / (float)maxRate) * 100) + "%";
        }
    }
}
