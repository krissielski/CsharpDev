using System;
using System.Windows.Forms;



namespace SocketDev
{
    public partial class ComForm : Form
    {

        //Init Serial Port
        private Serial comPort = new Serial();


        public ComForm()
        {
            InitializeComponent();

        }

        private void ComForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("COM Form_Load");
        }

        private void btnComOpen_Click(object sender, EventArgs e)
        {

            bool result = comPort.OpenSerial(3, 115200);

            if( !result)
            {
                Console.WriteLine(" Could Not Open Serial Port");
                return;
            }

            timer1.Interval = 100;
            timer1.Start();

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            byte[] txdata = { 0x55, 0x66, 0x77, 0x88 };

            Console.WriteLine("TxLength = " + txdata.Length);

            comPort.SendSerial(txdata, txdata.Length);

        }

        private void btnRead_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            comPort.CloseSerial();
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            int rxdata=0;

            Console.Write(".");
            if(  comPort.CheckSerial(ref rxdata) )
            {
                Console.WriteLine(">> {0:X}", rxdata);
            }


        }
    }
}
