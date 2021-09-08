using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// including the M2Mqtt Library
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Security.Cryptography.X509Certificates;

namespace SocketDev
{

    public partial class MQTTForm : Form
    {

        //Members

        // create client instance 

        private const string awsEndpoint = "*********.iot.us-east-1.amazonaws.com";
        private const int awsPort = 8883;

        private static readonly X509Certificate2 clientCert = new X509Certificate2(@"csharpdev.pfx", "");
        private static readonly X509Certificate  caCert = X509Certificate.CreateFromSignedFile(@"AmazonRootCA1.pem");

        //The Old way
        //private MqttClient client = new MqttClient("test.mosquitto.org");

        //The AWS Way
        private MqttClient client = new MqttClient(
            awsEndpoint,
            awsPort,
            true,
            caCert,
            clientCert,
            MqttSslProtocols.TLSv1_2);




        public MQTTForm()
        {
            InitializeComponent();
        }

        private void MQTTForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("MQTTForm_Load");
        }

        private void btnMqttTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine("MQTT Test Button");
        }

        private void MQTTForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("MQTT Form Closed");
        }

        private void MQTTForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("MQTT Form Closing");


            client.Disconnect();
        }

 
        //*************************************************************************************


       private void btnMqttConnect_Click(object sender, EventArgs e)
        {

            // create client instance 
            //private MqttClient client = new MqttClient("test.mosquitto.org");


            //Subscribe
            string[] subscribeTopics = { "kris/test/#" };
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };

            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived; //Add Event

            client.Subscribe(subscribeTopics, qosLevels);

            //Then, Connect...
            try
            {
                client.Connect("CsharpDev");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Unexpected exception : {0}", ex.ToString());
                Console.WriteLine("Unexpected exception MQTT Connect");
            }



            Console.WriteLine("MQTT Connecting.....");

            if( client.IsConnected )
            {
                Console.WriteLine("    SUCCESS!!!");
            }
            else
            {
                Console.WriteLine("    Failed!");
            }

        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        { 
            Console.WriteLine("Topic: " + e.Topic );
            Console.WriteLine("Msg:   " + Encoding.UTF8.GetString(e.Message) );
        }

        private void btnMqttPublish_Click(object sender, EventArgs e)
        {

            string topic = "kris/test/test2";
            string message = "Hello Kris from Home!!!!!";

            client.Publish(topic, Encoding.UTF8.GetBytes(message));

            Console.WriteLine("MQTT Publish");

        }



    }
}
