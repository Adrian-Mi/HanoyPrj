using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HanoyPrj
{
    public partial class Form1 : Form
    {
        Control topControlA;
        Control topControlB;
        Control topControlC;

        int topA;
        int topB;
        int topC;
        Stack<Control> myStackA = new Stack<Control>();
        Stack<Control> myStackB = new Stack<Control>();
        Stack<Control> myStackC = new Stack<Control>();

        int src, des;
        int totalDisk;
        string direction = "up";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            for (int i = 1; i <= 10; i++)
            {
                comboBox1.Items.Add(i);
            }          
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            clearDisk();
            totalDisk = int.Parse(comboBox1.Text);
            foreach (Control c in Controls)
            {
                if (c is Label && int.TryParse(c.Name.Substring(1), out a))
                {
                    if (int.Parse(c.Name.Substring(1)) >= 1 && int.Parse(c.Name.Substring(1)) <= totalDisk)
                    {
                        c.Visible = true;
                    }
                }
            }
            for (int i = 1; i <=totalDisk; i++)
            {
                foreach (Control c in Controls)
                {
                    if (c is Label && c.Name == "L" + i)
                    {
                        myStackA.Push(c);
                        break;
                    }
                }
            }          

            foreach (Control c in Controls)
            {
                if (c.Name == "L" + totalDisk)
                {
                    topControlA = c;
                    topControlB = null;
                    topControlC = null;
                    break;
                }

            }
            topA = 464 - totalDisk * 20;
            topB = 464;
            topC = 464;
            btnStart.Enabled = true;
        }

        private void clearDisk()
        {
            L1.Visible = false;
            L2.Visible = false;
            L3.Visible = false;
            L4.Visible = false;
            L5.Visible = false;
            L6.Visible = false;
            L7.Visible = false;
            L8.Visible = false;
            L9.Visible = false;
            L10.Visible = false;

            L1.Left = 70;
            L2.Left = 75;
            L3.Left = 80;
            L4.Left = 85;
            L5.Left = 90;
            L6.Left = 95;
            L7.Left = 100;
            L8.Left = 105;
            L9.Left = 110;
            L10.Left = 115;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            int n = int.Parse(comboBox1.Text);
            hanoyTower(n,1,2,3);
        }

        private void hanoyTower(int n, int v1, int v2, int v3)
        {
            if (n == 1)
                moveDisk(v1, v3);
            else
            {
                hanoyTower(n - 1, v1, v3, v2);
                moveDisk(v1,v3);
                hanoyTower(n - 1, v2, v1, v3);
            }
        }

        
        private void Transfer(int src,int des)
        {
            while (true)
            {
                if (src == 1 && des == 2)
                {
                    if (direction == "up")
                    {
                        topControlA.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Top < 80)
                        {
                            direction = "right";
                        }
                    }
                    else if (direction == "right")
                    {
                        topControlA.Left += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Left > LB.Left + 10 - (topControlA.Width / 2))
                        {
                            topControlA.Left = LB.Left + 10 - (topControlA.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlA.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Top > topB - 20)
                        {
                            topControlA.Top = topB - 20;
                            topControlB = topControlA;
                            myStackB.Push(myStackA.Pop());
                            if (myStackA.Count == 0)
                                topControlA = null;
                            else
                                topControlA = myStackA.Peek();
                            direction = "up";
                            topA += 20;
                            topB -= 20;                            
                            break;
                        }
                    }
                }
                else if (src == 1 && des == 3)
                {
                    if (direction == "up")
                    {
                        topControlA.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Top < 80)
                        {
                            direction = "right";
                        }
                    }
                    else if (direction == "right")
                    {
                        topControlA.Left += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Left > LC.Left + 10 - (topControlA.Width / 2))
                        {
                            topControlA.Left = LC.Left + 10 - (topControlA.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlA.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlA.Top > topC - 20)
                        {
                            topControlA.Top = topC - 20;
                            topControlC = topControlA;
                            myStackC.Push(myStackA.Pop());
                            if (myStackA.Count == 0)
                                topControlA = null;
                            else
                                topControlA = myStackA.Peek();
                            direction = "up";
                            topA += 20;
                            topC -= 20;                            
                            break;
                        }
                    }
                }
                else if (src == 2 && des == 1)
                {
                    if (direction == "up")
                    {
                        topControlB.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Top < 80)
                        {
                            direction = "left";
                        }
                    }
                    else if (direction == "left")
                    {
                        topControlB.Left -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Left < LA.Left + 10 - (topControlB.Width / 2))
                        {
                            topControlB.Left = LA.Left + 10 - (topControlB.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlB.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Top > topA - 20)
                        {
                            topControlB.Top = topA - 20;
                            topControlA = topControlB;
                            myStackA.Push(myStackB.Pop());
                            if (myStackB.Count == 0)
                                topControlB = null;
                            else
                                topControlB = myStackB.Peek();
                            direction = "up";
                            topB += 20;
                            topA -= 20;                            
                            break;
                        }
                    }
                }
                else if (src == 2 && des == 3)
                {
                    if (direction == "up")
                    {
                        topControlB.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Top < 80)
                        {
                            direction = "right";
                        }
                    }
                    else if (direction == "right")
                    {
                        topControlB.Left += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Left > LC.Left + 10 - (topControlB.Width / 2))
                        {
                            topControlB.Left = LC.Left + 10 - (topControlB.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlB.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlB.Top > topC - 20)
                        {
                            topControlB.Top = topC - 20;
                            topControlC = topControlB;
                            myStackC.Push(myStackB.Pop());
                            if (myStackB.Count == 0)
                                topControlB = null;
                            else
                                topControlB = myStackB.Peek();
                            direction = "up";
                            topB += 20;
                            topC -= 20;                            
                            break;
                        }
                    }
                }
                else if (src == 3 && des == 1)
                {
                    if (direction == "up")
                    {
                        topControlC.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Top < 80)
                        {
                            direction = "left";
                        }
                    }
                    else if (direction == "left")
                    {
                        topControlC.Left -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Left < LA.Left + 10 - (topControlC.Width / 2))
                        {
                            topControlC.Left = LA.Left + 10 - (topControlC.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlC.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Top > topA - 20)
                        {
                            topControlC.Top = topA - 20;
                            topControlA = topControlC;
                            myStackA.Push(myStackC.Pop());
                            if (myStackC.Count == 0)
                                topControlC = null;
                            else
                                topControlC = myStackC.Peek();
                            direction = "up";
                            topA -= 20;
                            topC += 20;                           
                            break;
                        }
                    }
                }
                else if (src == 3 && des == 2)
                {
                    if (direction == "up")
                    {
                        topControlC.Top -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Top < 80)
                        {
                            direction = "left";
                        }
                    }
                    else if (direction == "left")
                    {
                        topControlC.Left -= 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Left < LB.Left + 10 - (topControlC.Width / 2))
                        {
                            topControlC.Left = LB.Left + 10 - (topControlC.Width / 2);
                            direction = "down";
                        }
                    }
                    else if (direction == "down")
                    {
                        topControlC.Top += 15;
                        this.Refresh();
                        System.Threading.Thread.Sleep(20);
                        if (topControlC.Top > topB - 20)
                        {
                            topControlC.Top = topB - 20;
                            topControlB = topControlC;
                            myStackB.Push(myStackC.Pop());
                            if (myStackC.Count == 0)
                                topControlC = null;
                            else
                                topControlC = myStackC.Peek();
                            direction = "up";
                            topC += 20;
                            topB -= 20;                            
                            break;
                        }
                    }
                }
            }            
        }
        

        private void moveDisk(int v1, int v3)
        {
            
            if(v1==1 && v3==2)
            {
                src = 1;
                des = 2;
            }
            else if(v1==1 && v3 == 3)
            {
                src = 1;
                des = 3;
            }
            else if (v1 == 2 && v3 == 1)
            {
                src = 2;
                des = 1;
            }
            else if (v1 == 2 && v3 == 3)
            {
                src = 2;
                des = 3;
            }
            else if (v1 == 3 && v3 == 1)
            {
                src = 3;
                des = 1;
            }
            else if (v1 == 3 && v3 == 2)
            {
                src = 3;
                des = 2;
            }
            Transfer(src, des);
        }
    }
}
