namespace Modbus
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxProtocole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxMaster = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxMasterPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRetransNumber = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTimeLimit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMasterDisconnect = new System.Windows.Forms.Button();
            this.buttonMasterConnect = new System.Windows.Forms.Button();
            this.comboBoxFrameCharSpace = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxMasterReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.buttonMasterDataSend = new System.Windows.Forms.Button();
            this.groupBoxFrame = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxMasterSendMsg = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOrderCode = new System.Windows.Forms.ComboBox();
            this.numericUpDownTransactionAdres = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTransaction = new System.Windows.Forms.ComboBox();
            this.groupBoxSlave = new System.Windows.Forms.GroupBox();
            this.numericUpDownSlaveAdress = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSlaveConnect = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxSlaveSend = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBoxSlavePort = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxMaster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransactionAdres)).BeginInit();
            this.groupBoxSlave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveAdress)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxProtocole
            // 
            this.comboBoxProtocole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocole.FormattingEnabled = true;
            this.comboBoxProtocole.Location = new System.Drawing.Point(15, 25);
            this.comboBoxProtocole.Name = "comboBoxProtocole";
            this.comboBoxProtocole.Size = new System.Drawing.Size(99, 21);
            this.comboBoxProtocole.TabIndex = 0;
            this.comboBoxProtocole.SelectedIndexChanged += new System.EventHandler(this.comboBoxProtocole_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rodzaj stacji protokołu Modbus";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBoxMaster
            // 
            this.groupBoxMaster.Controls.Add(this.label11);
            this.groupBoxMaster.Controls.Add(this.comboBoxMasterPort);
            this.groupBoxMaster.Controls.Add(this.label7);
            this.groupBoxMaster.Controls.Add(this.groupBox1);
            this.groupBoxMaster.Controls.Add(this.buttonMasterDisconnect);
            this.groupBoxMaster.Controls.Add(this.buttonMasterConnect);
            this.groupBoxMaster.Controls.Add(this.comboBoxFrameCharSpace);
            this.groupBoxMaster.Controls.Add(this.label6);
            this.groupBoxMaster.Controls.Add(this.label10);
            this.groupBoxMaster.Controls.Add(this.richTextBoxMasterReceivedMsg);
            this.groupBoxMaster.Controls.Add(this.buttonMasterDataSend);
            this.groupBoxMaster.Controls.Add(this.groupBoxFrame);
            this.groupBoxMaster.Location = new System.Drawing.Point(15, 68);
            this.groupBoxMaster.Name = "groupBoxMaster";
            this.groupBoxMaster.Size = new System.Drawing.Size(374, 376);
            this.groupBoxMaster.TabIndex = 2;
            this.groupBoxMaster.TabStop = false;
            this.groupBoxMaster.Text = "Master";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Port";
            // 
            // comboBoxMasterPort
            // 
            this.comboBoxMasterPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasterPort.FormattingEnabled = true;
            this.comboBoxMasterPort.Location = new System.Drawing.Point(18, 35);
            this.comboBoxMasterPort.Name = "comboBoxMasterPort";
            this.comboBoxMasterPort.Size = new System.Drawing.Size(64, 21);
            this.comboBoxMasterPort.TabIndex = 4;
            this.comboBoxMasterPort.SelectedIndexChanged += new System.EventHandler(this.comboBoxPort_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxRetransNumber);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxTimeLimit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(184, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 99);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontrola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ograniczenie Czasowe";
            // 
            // comboBoxRetransNumber
            // 
            this.comboBoxRetransNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRetransNumber.FormattingEnabled = true;
            this.comboBoxRetransNumber.Location = new System.Drawing.Point(6, 69);
            this.comboBoxRetransNumber.Name = "comboBoxRetransNumber";
            this.comboBoxRetransNumber.Size = new System.Drawing.Size(89, 21);
            this.comboBoxRetransNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Liczba retransmisji";
            // 
            // comboBoxTimeLimit
            // 
            this.comboBoxTimeLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeLimit.FormattingEnabled = true;
            this.comboBoxTimeLimit.Location = new System.Drawing.Point(6, 29);
            this.comboBoxTimeLimit.Name = "comboBoxTimeLimit";
            this.comboBoxTimeLimit.Size = new System.Drawing.Size(118, 21);
            this.comboBoxTimeLimit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ms";
            // 
            // buttonMasterDisconnect
            // 
            this.buttonMasterDisconnect.Location = new System.Drawing.Point(286, 168);
            this.buttonMasterDisconnect.Name = "buttonMasterDisconnect";
            this.buttonMasterDisconnect.Size = new System.Drawing.Size(82, 73);
            this.buttonMasterDisconnect.TabIndex = 14;
            this.buttonMasterDisconnect.Text = "Rozłącz";
            this.buttonMasterDisconnect.UseVisualStyleBackColor = true;
            this.buttonMasterDisconnect.Click += new System.EventHandler(this.buttonMasterDisconnected_Click);
            // 
            // buttonMasterConnect
            // 
            this.buttonMasterConnect.Location = new System.Drawing.Point(201, 168);
            this.buttonMasterConnect.Name = "buttonMasterConnect";
            this.buttonMasterConnect.Size = new System.Drawing.Size(78, 73);
            this.buttonMasterConnect.TabIndex = 6;
            this.buttonMasterConnect.Text = "Połącz";
            this.buttonMasterConnect.UseVisualStyleBackColor = true;
            this.buttonMasterConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxFrameCharSpace
            // 
            this.comboBoxFrameCharSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameCharSpace.FormattingEnabled = true;
            this.comboBoxFrameCharSpace.Location = new System.Drawing.Point(219, 317);
            this.comboBoxFrameCharSpace.Name = "comboBoxFrameCharSpace";
            this.comboBoxFrameCharSpace.Size = new System.Drawing.Size(118, 21);
            this.comboBoxFrameCharSpace.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Odstęp pomiędzy znakami ramki";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tekst odebrany";
            // 
            // richTextBoxMasterReceivedMsg
            // 
            this.richTextBoxMasterReceivedMsg.Location = new System.Drawing.Point(12, 302);
            this.richTextBoxMasterReceivedMsg.Name = "richTextBoxMasterReceivedMsg";
            this.richTextBoxMasterReceivedMsg.Size = new System.Drawing.Size(201, 68);
            this.richTextBoxMasterReceivedMsg.TabIndex = 9;
            this.richTextBoxMasterReceivedMsg.Text = "";
            this.richTextBoxMasterReceivedMsg.TextChanged += new System.EventHandler(this.richTextBoxMasterReceivedMsg_TextChanged);
            // 
            // buttonMasterDataSend
            // 
            this.buttonMasterDataSend.Location = new System.Drawing.Point(202, 247);
            this.buttonMasterDataSend.Name = "buttonMasterDataSend";
            this.buttonMasterDataSend.Size = new System.Drawing.Size(166, 34);
            this.buttonMasterDataSend.TabIndex = 2;
            this.buttonMasterDataSend.Text = "Wyślij";
            this.buttonMasterDataSend.UseVisualStyleBackColor = true;
            this.buttonMasterDataSend.Click += new System.EventHandler(this.buttonMasterDataSend_Click);
            // 
            // groupBoxFrame
            // 
            this.groupBoxFrame.Controls.Add(this.label16);
            this.groupBoxFrame.Controls.Add(this.comboBoxTransaction);
            this.groupBoxFrame.Controls.Add(this.numericUpDownTransactionAdres);
            this.groupBoxFrame.Controls.Add(this.label2);
            this.groupBoxFrame.Controls.Add(this.label9);
            this.groupBoxFrame.Controls.Add(this.richTextBoxMasterSendMsg);
            this.groupBoxFrame.Controls.Add(this.label8);
            this.groupBoxFrame.Controls.Add(this.comboBoxOrderCode);
            this.groupBoxFrame.Location = new System.Drawing.Point(12, 109);
            this.groupBoxFrame.Name = "groupBoxFrame";
            this.groupBoxFrame.Size = new System.Drawing.Size(183, 175);
            this.groupBoxFrame.TabIndex = 1;
            this.groupBoxFrame.TabStop = false;
            this.groupBoxFrame.Text = "Utwórz ramkę";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tekst do wysłania";
            // 
            // richTextBoxMasterSendMsg
            // 
            this.richTextBoxMasterSendMsg.Location = new System.Drawing.Point(6, 79);
            this.richTextBoxMasterSendMsg.Name = "richTextBoxMasterSendMsg";
            this.richTextBoxMasterSendMsg.Size = new System.Drawing.Size(168, 28);
            this.richTextBoxMasterSendMsg.TabIndex = 7;
            this.richTextBoxMasterSendMsg.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Kod rozkazu";
            // 
            // comboBoxOrderCode
            // 
            this.comboBoxOrderCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderCode.FormattingEnabled = true;
            this.comboBoxOrderCode.Location = new System.Drawing.Point(6, 38);
            this.comboBoxOrderCode.Name = "comboBoxOrderCode";
            this.comboBoxOrderCode.Size = new System.Drawing.Size(72, 21);
            this.comboBoxOrderCode.TabIndex = 4;
            this.comboBoxOrderCode.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderCode_SelectedIndexChanged);
            // 
            // numericUpDownTransactionAdres
            // 
            this.numericUpDownTransactionAdres.Location = new System.Drawing.Point(98, 38);
            this.numericUpDownTransactionAdres.Name = "numericUpDownTransactionAdres";
            this.numericUpDownTransactionAdres.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownTransactionAdres.TabIndex = 6;
            this.numericUpDownTransactionAdres.ValueChanged += new System.EventHandler(this.numericUpDownTransactionAdres_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adres docelowy";
            // 
            // comboBoxTransaction
            // 
            this.comboBoxTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransaction.FormattingEnabled = true;
            this.comboBoxTransaction.Location = new System.Drawing.Point(9, 137);
            this.comboBoxTransaction.Name = "comboBoxTransaction";
            this.comboBoxTransaction.Size = new System.Drawing.Size(118, 21);
            this.comboBoxTransaction.TabIndex = 3;
            this.comboBoxTransaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransaction_SelectedIndexChanged);
            // 
            // groupBoxSlave
            // 
            this.groupBoxSlave.Controls.Add(this.numericUpDownSlaveAdress);
            this.groupBoxSlave.Controls.Add(this.label15);
            this.groupBoxSlave.Controls.Add(this.buttonSlaveConnect);
            this.groupBoxSlave.Controls.Add(this.label14);
            this.groupBoxSlave.Controls.Add(this.richTextBoxSlaveSend);
            this.groupBoxSlave.Controls.Add(this.label13);
            this.groupBoxSlave.Controls.Add(this.label12);
            this.groupBoxSlave.Controls.Add(this.richTextBox1);
            this.groupBoxSlave.Controls.Add(this.comboBoxSlavePort);
            this.groupBoxSlave.Location = new System.Drawing.Point(395, 68);
            this.groupBoxSlave.Name = "groupBoxSlave";
            this.groupBoxSlave.Size = new System.Drawing.Size(384, 376);
            this.groupBoxSlave.TabIndex = 3;
            this.groupBoxSlave.TabStop = false;
            this.groupBoxSlave.Text = "Slave";
            // 
            // numericUpDownSlaveAdress
            // 
            this.numericUpDownSlaveAdress.Location = new System.Drawing.Point(39, 109);
            this.numericUpDownSlaveAdress.Name = "numericUpDownSlaveAdress";
            this.numericUpDownSlaveAdress.Size = new System.Drawing.Size(118, 20);
            this.numericUpDownSlaveAdress.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Adres";
            // 
            // buttonSlaveConnect
            // 
            this.buttonSlaveConnect.Location = new System.Drawing.Point(268, 171);
            this.buttonSlaveConnect.Name = "buttonSlaveConnect";
            this.buttonSlaveConnect.Size = new System.Drawing.Size(78, 73);
            this.buttonSlaveConnect.TabIndex = 15;
            this.buttonSlaveConnect.Text = "Połącz";
            this.buttonSlaveConnect.UseVisualStyleBackColor = true;
            this.buttonSlaveConnect.Click += new System.EventHandler(this.buttonSlaveConnect_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(45, 152);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Tekst do wysłania";
            // 
            // richTextBoxSlaveSend
            // 
            this.richTextBoxSlaveSend.Location = new System.Drawing.Point(39, 168);
            this.richTextBoxSlaveSend.Name = "richTextBoxSlaveSend";
            this.richTextBoxSlaveSend.Size = new System.Drawing.Size(201, 68);
            this.richTextBoxSlaveSend.TabIndex = 18;
            this.richTextBoxSlaveSend.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Tekst odebrany";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Port";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(39, 265);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(201, 68);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // comboBoxSlavePort
            // 
            this.comboBoxSlavePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlavePort.FormattingEnabled = true;
            this.comboBoxSlavePort.Location = new System.Drawing.Point(6, 35);
            this.comboBoxSlavePort.Name = "comboBoxSlavePort";
            this.comboBoxSlavePort.Size = new System.Drawing.Size(64, 21);
            this.comboBoxSlavePort.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Transakcja";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxSlave);
            this.Controls.Add(this.groupBoxMaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProtocole);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMaster.ResumeLayout(false);
            this.groupBoxMaster.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxFrame.ResumeLayout(false);
            this.groupBoxFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTransactionAdres)).EndInit();
            this.groupBoxSlave.ResumeLayout(false);
            this.groupBoxSlave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveAdress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProtocole;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.GroupBox groupBoxMaster;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTransaction;
        private System.Windows.Forms.GroupBox groupBoxSlave;
        private System.Windows.Forms.GroupBox groupBoxFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTimeLimit;
        private System.Windows.Forms.Button buttonMasterDataSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxRetransNumber;
        private System.Windows.Forms.ComboBox comboBoxFrameCharSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxOrderCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxMasterReceivedMsg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxMasterSendMsg;
        private System.Windows.Forms.ComboBox comboBoxMasterPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownTransactionAdres;
        private System.Windows.Forms.Button buttonMasterConnect;
        private System.Windows.Forms.Button buttonMasterDisconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBoxSlavePort;
        private System.Windows.Forms.Timer transactionTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBoxSlaveSend;
        private System.Windows.Forms.Button buttonSlaveConnect;
        private System.Windows.Forms.NumericUpDown numericUpDownSlaveAdress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

