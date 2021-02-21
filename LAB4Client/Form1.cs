using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace LAB4Client
{
    public partial class Form1 : Form
    {
        void Connect(String server, byte[] message)
        {
            try
            {
                int port = 1001;
                TcpClient client = new TcpClient(server, port);
                NetworkStream stream = client.GetStream();

                stream.Write(message, 0, message.Length);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("ArgumentNullException: " + e.ToString());
            }
            catch (SocketException e1)
            {
                MessageBox.Show("Ошибка соединения: " + e1.ToString());
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Connect(textBox1.Text, new byte[] { colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B});
        }
    }
}