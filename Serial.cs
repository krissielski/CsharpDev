using System;

using System.IO.Ports;



/// <summary>
/// Class Serial
///   Serial Com Port Wrapper  
///   Written by Kris Sielski
///   9/9/2021
/// </summary>
namespace SocketDev
{
    class Serial
    {

        //Members
        private SerialPort comPort;

        //Constructor
        public Serial()
        {
        }

        public bool OpenSerial(int portNum, int baudrate)
        {

            string strPortNum = "COM" + portNum.ToString();

            try
            {
                comPort = new SerialPort(strPortNum, baudrate, Parity.None, 8, StopBits.One);
                comPort.Open();

                // Set the read/write timeouts
                comPort.ReadTimeout = 0;
                comPort.WriteTimeout = 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open Error: {0}", ex);
                return false;
            }
            return true;
        }

        public void CloseSerial()
        {
            comPort.Close();
        }

        public bool IsSerialOpen()
        {
            return comPort.IsOpen;
        }

        public void SendSerial( byte[] data, int size)
        {
            comPort.Write(data, 0, size);
        }

        //CheckSerial:
        // return TRUE with rx in data byte when data available
        public bool CheckSerial(ref int data)
        {

            //Check if data available and read it
            if (comPort.BytesToRead > 0)
            {
                data = comPort.ReadByte();
                return true;
            }

            data = 0x00;
            return false;
        }




    }
}
