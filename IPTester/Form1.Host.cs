using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTester
{
    partial class Form1
    {
        int hostMaxRate = 11;

        uint numHosts;

        int[] netAddrHost = new int[4];
        int[] hostAddrHost = new int[4];
        int prefixHost;

        void genHosts()
        {
            numHosts = 0;
            unblockBox();
            lockedTab = true;
            timerStart();
            clearBox();

            int minPrefix = 0, maxPrefix = 0;
            int nextPrefix = 0;

            if (checkBox11.Checked)
            {
                minPrefix = 0;
                maxPrefix = 30;

                nextPrefix = 1;
            }
            else
            {
                minPrefix = 1;
                maxPrefix = 4;

                nextPrefix = 8;
            }
            prefixHost = random.Next(minPrefix, maxPrefix);
            if (!checkBox11.Checked)
            {
                prefixHost *= 8;

                if (prefixHost == 8)
                    textBox12.AccessibleName = "A";
                if (prefixHost == 16)
                    textBox12.AccessibleName = "B";
                if (prefixHost == 24)
                    textBox12.AccessibleName = "C";
            }

            uint minValue = (uint)(Math.Pow(2, 32 - (prefixHost + nextPrefix))-2);
            if (prefixHost == 24)
            {
                minValue = 1;
            }
            uint maxValue = (uint)(Math.Pow(2, 32 - prefixHost)-2);

            minValue = (minValue / 2);
            maxValue = (maxValue / 2);

            numHosts = (uint)random.Next((int)(minValue), (int)(maxValue))*2;

            textBox4.AccessibleName = prefixHost.ToString();

            textBox10.AccessibleName = Convert.ToUInt32(Math.Pow(2, 32 - prefixHost) - 2).ToString();

            sumbit_host.Enabled = true;
            numHosts += (uint)random.Next(0, 2);

            numHostText.Text = numHosts + "";
        }

        void blockBox()
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
        }

        void unblockBox()
        {
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
        }

        void clearBox()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
        }

        void setCorrectMask()
        {
            textBox2.AccessibleName = String.Join(".", getByteMask(getStrMask(prefixHost)));
            textBox3.AccessibleName = String.Join(".", getByteMask(invertStringBits(getStrMask(prefixHost))));
        }

        int[] getBroadcastAddres(int[] ipAddr)
        {
            short[] max = getByteMask(invertStringBits(getStrMask(prefixHost)));

            int[] broadAddr = new int[4];

            for (int i = 0; i < 4; i++)
            {
                broadAddr[i] = max[i] | ipAddr[i];
            }

            return broadAddr;
        }

        int[] getMinAddres(int[] ipAddr)
        {
            int[] temp = new int[4];
            ipAddr.CopyTo(temp, 0);
            
            temp[3] += 1;
            return temp;
        }

        int[] getMaxAddres(int[] broadAddr)
        {
            broadAddr[3] -= 1;
            return broadAddr;
        }
        
        bool validatorHostAddr()
        {
            return validatorNetHostAddr(textBox6.Text, getByteMask(getStrMask(prefixHost)), false);
        }

        bool validatorNetAddr()
        {
            return validatorNetHostAddr(textBox5.Text, getByteMask(getStrMask(prefixHost)), true);
        }

        bool validatorNetHostAddr(string Addr, short[] mask, bool invert)
        {
            int[] addr = new int[4];
            string[] addrStr = Addr.Split('.');
            for (int i = 0; i < 4; i++)
            {
                if(addrStr.Length - 1 >= i)
                {
                    if (!Int32.TryParse(addrStr[i], out addr[i]))
                    {
                        return false;
                    }
                }
                if (invert)
                {
                    if (addr[i] > 255)
                        return false;
                }
                else
                {
                    if(i == 3)
                    {
                        if (addr[i] > 254 || addr[i] < 1)
                            return false;
                    }else
                    if (addr[i] > 255)
                        return false;
                }
            }
            bool isValid = validNetAddr(addr, mask, invert);
            if (isValid)
            {
                if (invert)
                {
                    netAddrHost = addr;
                    textBox5.AccessibleName = textBox5.Text;
                }
                else
                {
                    hostAddrHost = addr;
                    textBox6.AccessibleName = textBox6.Text;
                }
            }else
            {
                if (invert)
                {
                    textBox5.AccessibleName = "!@#$%^&lzksuvr*()";
                }
                else
                {
                    textBox6.AccessibleName = "!@#jgyzvk$%^&*()";
                }
            }
            return isValid;
        }

        bool validNetAddr(int[] addr, short[] mask, bool invert)
        {
            for (int i = 0; i < mask.Length; i++)
            {
                if (invert)
                {
                    if (((~mask[i]) & addr[i]) != 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (((mask[i]) & addr[i]) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        
    }
}
