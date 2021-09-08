
namespace SocketDev
{
    partial class MQTTForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMqttTest = new System.Windows.Forms.Button();
            this.btnMqttConnect = new System.Windows.Forms.Button();
            this.btnMqttPublish = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMqttTest
            // 
            this.btnMqttTest.Location = new System.Drawing.Point(25, 29);
            this.btnMqttTest.Name = "btnMqttTest";
            this.btnMqttTest.Size = new System.Drawing.Size(92, 52);
            this.btnMqttTest.TabIndex = 0;
            this.btnMqttTest.Text = "MQTT Test";
            this.btnMqttTest.UseVisualStyleBackColor = true;
            this.btnMqttTest.Click += new System.EventHandler(this.btnMqttTest_Click);
            // 
            // btnMqttConnect
            // 
            this.btnMqttConnect.Location = new System.Drawing.Point(311, 35);
            this.btnMqttConnect.Name = "btnMqttConnect";
            this.btnMqttConnect.Size = new System.Drawing.Size(91, 45);
            this.btnMqttConnect.TabIndex = 1;
            this.btnMqttConnect.Text = "Connect";
            this.btnMqttConnect.UseVisualStyleBackColor = true;
            this.btnMqttConnect.Click += new System.EventHandler(this.btnMqttConnect_Click);
            // 
            // btnMqttPublish
            // 
            this.btnMqttPublish.Location = new System.Drawing.Point(311, 114);
            this.btnMqttPublish.Name = "btnMqttPublish";
            this.btnMqttPublish.Size = new System.Drawing.Size(91, 45);
            this.btnMqttPublish.TabIndex = 2;
            this.btnMqttPublish.Text = "Publish";
            this.btnMqttPublish.UseVisualStyleBackColor = true;
            this.btnMqttPublish.Click += new System.EventHandler(this.btnMqttPublish_Click);
            // 
            // MQTTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 269);
            this.Controls.Add(this.btnMqttPublish);
            this.Controls.Add(this.btnMqttConnect);
            this.Controls.Add(this.btnMqttTest);
            this.Name = "MQTTForm";
            this.Text = "MQTTForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MQTTForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MQTTForm_FormClosed);
            this.Load += new System.EventHandler(this.MQTTForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMqttTest;
        private System.Windows.Forms.Button btnMqttConnect;
        private System.Windows.Forms.Button btnMqttPublish;
    }
}