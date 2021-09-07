using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SocketDev
{
    public partial class Form1 : Form
    {

        ClientSocket cs = new ClientSocket();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Form1_Load");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Test Button");

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            cs.OpenSocket("127.0.0.1", 4000);
        }

        private void bthClose_Click(object sender, EventArgs e)
        {
            cs.CloseSocket();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            byte[] txdata = new byte[] { 0x01, 0x02, 0x03, 0x04 };


            cs.SendSocket(txdata,4);
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            //cs.ReadSocket();

            ////Single
            //byte rxdata=0;
            //if( cs.ReadSocket(ref rxdata) )
            //{
            //    Console.WriteLine(">> {0:X}", rxdata);
            //}

            //Multiple
            byte[] rxdata = new byte[1024];
            int recBytes = cs.ReadSocket(rxdata);
            if (recBytes > 0)
            {
                Console.WriteLine(">> Echoed test = {0}", Encoding.ASCII.GetString(rxdata, 0, recBytes));
            }


        }


    }
}
