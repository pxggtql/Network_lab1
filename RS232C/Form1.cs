using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)//完成窗口初始化
        {
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(portReceive1);
            serialPort2.DataReceived += new SerialDataReceivedEventHandler(portReceive2);
        }
        private void portReceive1(object sender,SerialDataReceivedEventArgs e)
        {
            InvokeIfRequired1(() =>
           {
               string str = serialPort1.ReadExisting();//字符串方式读
               richTextBox1.Text += str;
           });
        }
        private void InvokeIfRequired1(MethodInvoker _delegate)
        {
            if (richTextBox1.InvokeRequired)
                richTextBox1.BeginInvoke(_delegate);
            else
                _delegate();
        }
        private void portReceive2(object sender, SerialDataReceivedEventArgs e)
        {
            InvokeIfRequired2(() =>
            {
                string str = serialPort2.ReadExisting();//字符串方式读
                richTextBox2.Text += str;
            });
        }
        private void InvokeIfRequired2(MethodInvoker _delegate)
        {
            if (richTextBox2.InvokeRequired)
                richTextBox2.BeginInvoke(_delegate);
            else
                _delegate();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (richTextBox3.Text != "")
                {
                        try
                        {
                            serialPort1.WriteLine(richTextBox3.Text);
                            richTextBox3.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("串口数据写入错误!");
                        }
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = textBox2.Text;
                serialPort1.BaudRate = Convert.ToInt32(textBox3.Text);
                serialPort1.DataBits = Convert.ToInt32(textBox1.Text);
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                serialPort1.Parity = System.IO.Ports.Parity.Even;
                serialPort1.Open();
                button2.Enabled = false;
                button5.Enabled = true;
            }
            catch
            {
                MessageBox.Show("串口错误，请检查串口设置！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button2.Enabled = true;
            button5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort2.PortName = textBox4.Text;
                serialPort2.BaudRate = Convert.ToInt32(textBox3.Text);
                serialPort2.DataBits = Convert.ToInt32(textBox1.Text);
                serialPort2.StopBits = System.IO.Ports.StopBits.One;
                serialPort2.Parity = System.IO.Ports.Parity.Even;
                serialPort2.Open();
                button3.Enabled = false;
                button6.Enabled = true;
            }
            catch
            {
                MessageBox.Show("串口错误，请检查串口设置！");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort2.Close();
            button3.Enabled = true;
            button6.Enabled = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                if (richTextBox4.Text != "")
                {
                    try
                    {
                        serialPort2.WriteLine(richTextBox4.Text);
                        richTextBox4.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("串口数据写入错误!");
                    }
                }
            }
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
