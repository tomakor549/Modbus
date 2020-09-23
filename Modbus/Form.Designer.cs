namespace Modbus
{
    partial class Form
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
            this.label18 = new System.Windows.Forms.Label();
            this.richTextBoxMasterReceiveFrame = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxRetransNumber = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMasterTimeLimit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonMasterDisconnect = new System.Windows.Forms.Button();
            this.buttonMasterConnect = new System.Windows.Forms.Button();
            this.comboBoxModbusFrameCharSpace = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxMasterReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.groupBoxFrame = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxTransaction = new System.Windows.Forms.ComboBox();
            this.numericUpDownTransactionAdres = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBoxMasterSendMsg = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOrderCode = new System.Windows.Forms.ComboBox();
            this.buttonMasterDataSend = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.groupBoxSlave = new System.Windows.Forms.GroupBox();
            this.buttonSlaveClear = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBoxSlaveReceiveFrame = new System.Windows.Forms.RichTextBox();
            this.buttonSlaveDisconnect = new System.Windows.Forms.Button();
            this.numericUpDownSlaveAdress = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.buttonSlaveConnect = new System.Windows.Forms.Button();
            this.comboBoxSlaveFrameCharSpace = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.richTextBoxSlaveSend = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.richTextBoxSlaveReceivedMsg = new System.Windows.Forms.RichTextBox();
            this.buttonMasterClear = new System.Windows.Forms.Button();
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
            this.groupBoxMaster.Controls.Add(this.buttonMasterClear);
            this.groupBoxMaster.Controls.Add(this.label18);
            this.groupBoxMaster.Controls.Add(this.richTextBoxMasterReceiveFrame);
            this.groupBoxMaster.Controls.Add(this.label7);
            this.groupBoxMaster.Controls.Add(this.groupBox1);
            this.groupBoxMaster.Controls.Add(this.buttonMasterDisconnect);
            this.groupBoxMaster.Controls.Add(this.buttonMasterConnect);
            this.groupBoxMaster.Controls.Add(this.comboBoxModbusFrameCharSpace);
            this.groupBoxMaster.Controls.Add(this.label6);
            this.groupBoxMaster.Controls.Add(this.label10);
            this.groupBoxMaster.Controls.Add(this.richTextBoxMasterReceivedMsg);
            this.groupBoxMaster.Controls.Add(this.groupBoxFrame);
            this.groupBoxMaster.Location = new System.Drawing.Point(15, 68);
            this.groupBoxMaster.Name = "groupBoxMaster";
            this.groupBoxMaster.Size = new System.Drawing.Size(374, 376);
            this.groupBoxMaster.TabIndex = 2;
            this.groupBoxMaster.TabStop = false;
            this.groupBoxMaster.Text = "Master";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 316);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Odebrana ramka";
            // 
            // richTextBoxMasterReceiveFrame
            // 
            this.richTextBoxMasterReceiveFrame.Location = new System.Drawing.Point(6, 332);
            this.richTextBoxMasterReceiveFrame.Name = "richTextBoxMasterReceiveFrame";
            this.richTextBoxMasterReceiveFrame.Size = new System.Drawing.Size(207, 44);
            this.richTextBoxMasterReceiveFrame.TabIndex = 15;
            this.richTextBoxMasterReceiveFrame.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 271);
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
            this.groupBox1.Controls.Add(this.comboBoxMasterTimeLimit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(7, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 62);
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
            this.comboBoxRetransNumber.Location = new System.Drawing.Point(168, 29);
            this.comboBoxRetransNumber.Name = "comboBoxRetransNumber";
            this.comboBoxRetransNumber.Size = new System.Drawing.Size(89, 21);
            this.comboBoxRetransNumber.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Liczba retransmisji";
            // 
            // comboBoxMasterTimeLimit
            // 
            this.comboBoxMasterTimeLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasterTimeLimit.FormattingEnabled = true;
            this.comboBoxMasterTimeLimit.Location = new System.Drawing.Point(6, 29);
            this.comboBoxMasterTimeLimit.Name = "comboBoxMasterTimeLimit";
            this.comboBoxMasterTimeLimit.Size = new System.Drawing.Size(118, 21);
            this.comboBoxMasterTimeLimit.TabIndex = 6;
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
            this.buttonMasterDisconnect.Location = new System.Drawing.Point(219, 295);
            this.buttonMasterDisconnect.Name = "buttonMasterDisconnect";
            this.buttonMasterDisconnect.Size = new System.Drawing.Size(63, 46);
            this.buttonMasterDisconnect.TabIndex = 14;
            this.buttonMasterDisconnect.Text = "Rozłącz";
            this.buttonMasterDisconnect.UseVisualStyleBackColor = true;
            this.buttonMasterDisconnect.Click += new System.EventHandler(this.buttonMasterDisconnected_Click);
            // 
            // buttonMasterConnect
            // 
            this.buttonMasterConnect.Location = new System.Drawing.Point(288, 295);
            this.buttonMasterConnect.Name = "buttonMasterConnect";
            this.buttonMasterConnect.Size = new System.Drawing.Size(75, 75);
            this.buttonMasterConnect.TabIndex = 6;
            this.buttonMasterConnect.Text = "Połącz";
            this.buttonMasterConnect.UseVisualStyleBackColor = true;
            this.buttonMasterConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxModbusFrameCharSpace
            // 
            this.comboBoxModbusFrameCharSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModbusFrameCharSpace.FormattingEnabled = true;
            this.comboBoxModbusFrameCharSpace.Location = new System.Drawing.Point(219, 268);
            this.comboBoxModbusFrameCharSpace.Name = "comboBoxModbusFrameCharSpace";
            this.comboBoxModbusFrameCharSpace.Size = new System.Drawing.Size(118, 21);
            this.comboBoxModbusFrameCharSpace.TabIndex = 12;
            this.comboBoxModbusFrameCharSpace.SelectedIndexChanged += new System.EventHandler(this.comboBoxModbusFrameCharSpace_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Odstęp pomiędzy znakami ramki";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tekst odebrany";
            // 
            // richTextBoxMasterReceivedMsg
            // 
            this.richTextBoxMasterReceivedMsg.Location = new System.Drawing.Point(6, 265);
            this.richTextBoxMasterReceivedMsg.Name = "richTextBoxMasterReceivedMsg";
            this.richTextBoxMasterReceivedMsg.Size = new System.Drawing.Size(207, 48);
            this.richTextBoxMasterReceivedMsg.TabIndex = 9;
            this.richTextBoxMasterReceivedMsg.Text = "";
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
            this.groupBoxFrame.Controls.Add(this.buttonMasterDataSend);
            this.groupBoxFrame.Location = new System.Drawing.Point(6, 16);
            this.groupBoxFrame.Name = "groupBoxFrame";
            this.groupBoxFrame.Size = new System.Drawing.Size(357, 160);
            this.groupBoxFrame.TabIndex = 1;
            this.groupBoxFrame.TabStop = false;
            this.groupBoxFrame.Text = "Utwórz ramkę";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(111, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Transakcja";
            // 
            // comboBoxTransaction
            // 
            this.comboBoxTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransaction.FormattingEnabled = true;
            this.comboBoxTransaction.Location = new System.Drawing.Point(114, 37);
            this.comboBoxTransaction.Name = "comboBoxTransaction";
            this.comboBoxTransaction.Size = new System.Drawing.Size(118, 21);
            this.comboBoxTransaction.TabIndex = 3;
            this.comboBoxTransaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransaction_SelectedIndexChanged);
            // 
            // numericUpDownTransactionAdres
            // 
            this.numericUpDownTransactionAdres.Location = new System.Drawing.Point(266, 38);
            this.numericUpDownTransactionAdres.Name = "numericUpDownTransactionAdres";
            this.numericUpDownTransactionAdres.Size = new System.Drawing.Size(76, 20);
            this.numericUpDownTransactionAdres.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adres docelowy";
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
            this.richTextBoxMasterSendMsg.Size = new System.Drawing.Size(241, 67);
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
            // buttonMasterDataSend
            // 
            this.buttonMasterDataSend.Location = new System.Drawing.Point(252, 79);
            this.buttonMasterDataSend.Name = "buttonMasterDataSend";
            this.buttonMasterDataSend.Size = new System.Drawing.Size(90, 67);
            this.buttonMasterDataSend.TabIndex = 2;
            this.buttonMasterDataSend.Text = "Wyślij";
            this.buttonMasterDataSend.UseVisualStyleBackColor = true;
            this.buttonMasterDataSend.Click += new System.EventHandler(this.buttonMasterDataSend_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Port";
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(189, 25);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(64, 21);
            this.comboBoxPort.TabIndex = 4;
            // 
            // groupBoxSlave
            // 
            this.groupBoxSlave.Controls.Add(this.buttonSlaveClear);
            this.groupBoxSlave.Controls.Add(this.label19);
            this.groupBoxSlave.Controls.Add(this.label12);
            this.groupBoxSlave.Controls.Add(this.richTextBoxSlaveReceiveFrame);
            this.groupBoxSlave.Controls.Add(this.buttonSlaveDisconnect);
            this.groupBoxSlave.Controls.Add(this.numericUpDownSlaveAdress);
            this.groupBoxSlave.Controls.Add(this.label15);
            this.groupBoxSlave.Controls.Add(this.buttonSlaveConnect);
            this.groupBoxSlave.Controls.Add(this.comboBoxSlaveFrameCharSpace);
            this.groupBoxSlave.Controls.Add(this.label17);
            this.groupBoxSlave.Controls.Add(this.label14);
            this.groupBoxSlave.Controls.Add(this.richTextBoxSlaveSend);
            this.groupBoxSlave.Controls.Add(this.label13);
            this.groupBoxSlave.Controls.Add(this.richTextBoxSlaveReceivedMsg);
            this.groupBoxSlave.Location = new System.Drawing.Point(395, 68);
            this.groupBoxSlave.Name = "groupBoxSlave";
            this.groupBoxSlave.Size = new System.Drawing.Size(384, 376);
            this.groupBoxSlave.TabIndex = 3;
            this.groupBoxSlave.TabStop = false;
            this.groupBoxSlave.Text = "Slave";
            // 
            // buttonSlaveClear
            // 
            this.buttonSlaveClear.Location = new System.Drawing.Point(268, 334);
            this.buttonSlaveClear.Name = "buttonSlaveClear";
            this.buttonSlaveClear.Size = new System.Drawing.Size(75, 36);
            this.buttonSlaveClear.TabIndex = 21;
            this.buttonSlaveClear.Text = "Wyczyść";
            this.buttonSlaveClear.UseVisualStyleBackColor = true;
            this.buttonSlaveClear.Click += new System.EventHandler(this.buttonSlaveClear_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(40, 316);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Odebrana ramka";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Odstęp pomiędzy znakami ramki";
            // 
            // richTextBoxSlaveReceiveFrame
            // 
            this.richTextBoxSlaveReceiveFrame.Location = new System.Drawing.Point(39, 332);
            this.richTextBoxSlaveReceiveFrame.Name = "richTextBoxSlaveReceiveFrame";
            this.richTextBoxSlaveReceiveFrame.Size = new System.Drawing.Size(207, 44);
            this.richTextBoxSlaveReceiveFrame.TabIndex = 17;
            this.richTextBoxSlaveReceiveFrame.Text = "";
            // 
            // buttonSlaveDisconnect
            // 
            this.buttonSlaveDisconnect.Location = new System.Drawing.Point(268, 253);
            this.buttonSlaveDisconnect.Name = "buttonSlaveDisconnect";
            this.buttonSlaveDisconnect.Size = new System.Drawing.Size(78, 73);
            this.buttonSlaveDisconnect.TabIndex = 19;
            this.buttonSlaveDisconnect.Text = "Rozłącz";
            this.buttonSlaveDisconnect.UseVisualStyleBackColor = true;
            this.buttonSlaveDisconnect.Click += new System.EventHandler(this.buttonSlaveDisconnect_Click);
            // 
            // numericUpDownSlaveAdress
            // 
            this.numericUpDownSlaveAdress.Location = new System.Drawing.Point(18, 56);
            this.numericUpDownSlaveAdress.Name = "numericUpDownSlaveAdress";
            this.numericUpDownSlaveAdress.Size = new System.Drawing.Size(118, 20);
            this.numericUpDownSlaveAdress.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Adres Stacji";
            // 
            // buttonSlaveConnect
            // 
            this.buttonSlaveConnect.Location = new System.Drawing.Point(18, 92);
            this.buttonSlaveConnect.Name = "buttonSlaveConnect";
            this.buttonSlaveConnect.Size = new System.Drawing.Size(78, 73);
            this.buttonSlaveConnect.TabIndex = 15;
            this.buttonSlaveConnect.Text = "Połącz";
            this.buttonSlaveConnect.UseVisualStyleBackColor = true;
            this.buttonSlaveConnect.Click += new System.EventHandler(this.buttonSlaveConnect_Click);
            // 
            // comboBoxSlaveFrameCharSpace
            // 
            this.comboBoxSlaveFrameCharSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlaveFrameCharSpace.FormattingEnabled = true;
            this.comboBoxSlaveFrameCharSpace.Location = new System.Drawing.Point(39, 223);
            this.comboBoxSlaveFrameCharSpace.Name = "comboBoxSlaveFrameCharSpace";
            this.comboBoxSlaveFrameCharSpace.Size = new System.Drawing.Size(118, 21);
            this.comboBoxSlaveFrameCharSpace.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(163, 226);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "ms";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(162, 22);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Tekst do wysłania";
            // 
            // richTextBoxSlaveSend
            // 
            this.richTextBoxSlaveSend.Location = new System.Drawing.Point(156, 38);
            this.richTextBoxSlaveSend.Name = "richTextBoxSlaveSend";
            this.richTextBoxSlaveSend.Size = new System.Drawing.Size(201, 127);
            this.richTextBoxSlaveSend.TabIndex = 18;
            this.richTextBoxSlaveSend.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Tekst odebrany";
            // 
            // richTextBoxSlaveReceivedMsg
            // 
            this.richTextBoxSlaveReceivedMsg.Location = new System.Drawing.Point(39, 265);
            this.richTextBoxSlaveReceivedMsg.Name = "richTextBoxSlaveReceivedMsg";
            this.richTextBoxSlaveReceivedMsg.Size = new System.Drawing.Size(201, 48);
            this.richTextBoxSlaveReceivedMsg.TabIndex = 16;
            this.richTextBoxSlaveReceivedMsg.Text = "";
            // 
            // buttonMasterClear
            // 
            this.buttonMasterClear.Location = new System.Drawing.Point(219, 347);
            this.buttonMasterClear.Name = "buttonMasterClear";
            this.buttonMasterClear.Size = new System.Drawing.Size(63, 23);
            this.buttonMasterClear.TabIndex = 17;
            this.buttonMasterClear.Text = "Czyść pola";
            this.buttonMasterClear.UseVisualStyleBackColor = true;
            this.buttonMasterClear.Click += new System.EventHandler(this.buttonMasterClear_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBoxSlave);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.groupBoxMaster);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxProtocole);
            this.Name = "Form";
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
        private System.Windows.Forms.ComboBox comboBoxMasterTimeLimit;
        private System.Windows.Forms.Button buttonMasterDataSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxRetransNumber;
        private System.Windows.Forms.ComboBox comboBoxModbusFrameCharSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxOrderCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox richTextBoxMasterReceivedMsg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBoxMasterSendMsg;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDownTransactionAdres;
        private System.Windows.Forms.Button buttonMasterConnect;
        private System.Windows.Forms.Button buttonMasterDisconnect;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBoxSlaveReceivedMsg;
        private System.Windows.Forms.Timer transactionTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox richTextBoxSlaveSend;
        private System.Windows.Forms.Button buttonSlaveConnect;
        private System.Windows.Forms.NumericUpDown numericUpDownSlaveAdress;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxSlaveFrameCharSpace;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSlaveDisconnect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox richTextBoxMasterReceiveFrame;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RichTextBox richTextBoxSlaveReceiveFrame;
        private System.Windows.Forms.Button buttonSlaveClear;
        private System.Windows.Forms.Button buttonMasterClear;
    }
}

