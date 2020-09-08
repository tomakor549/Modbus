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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBoxMaster = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxTransaction = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTransactionAdres = new System.Windows.Forms.TextBox();
            this.groupBoxSlave = new System.Windows.Forms.GroupBox();
            this.groupBoxFrame = new System.Windows.Forms.GroupBox();
            this.buttonMasterDataSend = new System.Windows.Forms.Button();
            this.comboBoxTimeLimit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRetransAdres = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFrameCharSpace = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxMaster.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxProtocole
            // 
            this.comboBoxProtocole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProtocole.FormattingEnabled = true;
            this.comboBoxProtocole.Location = new System.Drawing.Point(15, 25);
            this.comboBoxProtocole.Name = "comboBoxProtocole";
            this.comboBoxProtocole.Size = new System.Drawing.Size(154, 21);
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
            // groupBoxMaster
            // 
            this.groupBoxMaster.Controls.Add(this.label7);
            this.groupBoxMaster.Controls.Add(this.comboBoxFrameCharSpace);
            this.groupBoxMaster.Controls.Add(this.label6);
            this.groupBoxMaster.Controls.Add(this.label5);
            this.groupBoxMaster.Controls.Add(this.comboBoxRetransAdres);
            this.groupBoxMaster.Controls.Add(this.label4);
            this.groupBoxMaster.Controls.Add(this.label3);
            this.groupBoxMaster.Controls.Add(this.comboBoxTimeLimit);
            this.groupBoxMaster.Controls.Add(this.buttonMasterDataSend);
            this.groupBoxMaster.Controls.Add(this.groupBoxFrame);
            this.groupBoxMaster.Controls.Add(this.groupBox2);
            this.groupBoxMaster.Location = new System.Drawing.Point(15, 68);
            this.groupBoxMaster.Name = "groupBoxMaster";
            this.groupBoxMaster.Size = new System.Drawing.Size(374, 370);
            this.groupBoxMaster.TabIndex = 2;
            this.groupBoxMaster.TabStop = false;
            this.groupBoxMaster.Text = "Master";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxTransactionAdres);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxTransaction);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 116);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rodzaj Transakcji";
            // 
            // comboBoxTransaction
            // 
            this.comboBoxTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransaction.FormattingEnabled = true;
            this.comboBoxTransaction.Location = new System.Drawing.Point(6, 29);
            this.comboBoxTransaction.Name = "comboBoxTransaction";
            this.comboBoxTransaction.Size = new System.Drawing.Size(118, 21);
            this.comboBoxTransaction.TabIndex = 3;
            this.comboBoxTransaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxTransaction_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adres";
            // 
            // textBoxTransactionAdres
            // 
            this.textBoxTransactionAdres.Location = new System.Drawing.Point(6, 79);
            this.textBoxTransactionAdres.Name = "textBoxTransactionAdres";
            this.textBoxTransactionAdres.Size = new System.Drawing.Size(188, 20);
            this.textBoxTransactionAdres.TabIndex = 5;
            // 
            // groupBoxSlave
            // 
            this.groupBoxSlave.Location = new System.Drawing.Point(471, 68);
            this.groupBoxSlave.Name = "groupBoxSlave";
            this.groupBoxSlave.Size = new System.Drawing.Size(200, 100);
            this.groupBoxSlave.TabIndex = 3;
            this.groupBoxSlave.TabStop = false;
            this.groupBoxSlave.Text = "Slave";
            // 
            // groupBoxFrame
            // 
            this.groupBoxFrame.Location = new System.Drawing.Point(12, 142);
            this.groupBoxFrame.Name = "groupBoxFrame";
            this.groupBoxFrame.Size = new System.Drawing.Size(356, 120);
            this.groupBoxFrame.TabIndex = 1;
            this.groupBoxFrame.TabStop = false;
            this.groupBoxFrame.Text = "Utwórz ramkę";
            // 
            // buttonMasterDataSend
            // 
            this.buttonMasterDataSend.Location = new System.Drawing.Point(213, 20);
            this.buttonMasterDataSend.Name = "buttonMasterDataSend";
            this.buttonMasterDataSend.Size = new System.Drawing.Size(155, 116);
            this.buttonMasterDataSend.TabIndex = 2;
            this.buttonMasterDataSend.Text = "Wyślij";
            this.buttonMasterDataSend.UseVisualStyleBackColor = true;
            // 
            // comboBoxTimeLimit
            // 
            this.comboBoxTimeLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeLimit.FormattingEnabled = true;
            this.comboBoxTimeLimit.Location = new System.Drawing.Point(6, 280);
            this.comboBoxTimeLimit.Name = "comboBoxTimeLimit";
            this.comboBoxTimeLimit.Size = new System.Drawing.Size(118, 21);
            this.comboBoxTimeLimit.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ograniczenie Czasowe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ms";
            // 
            // comboBoxRetransAdres
            // 
            this.comboBoxRetransAdres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRetransAdres.FormattingEnabled = true;
            this.comboBoxRetransAdres.Location = new System.Drawing.Point(179, 280);
            this.comboBoxRetransAdres.Name = "comboBoxRetransAdres";
            this.comboBoxRetransAdres.Size = new System.Drawing.Size(118, 21);
            this.comboBoxRetransAdres.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Liczba retransmisji";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Odstęp pomiędzy znakami ramki";
            // 
            // comboBoxFrameCharSpace
            // 
            this.comboBoxFrameCharSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameCharSpace.FormattingEnabled = true;
            this.comboBoxFrameCharSpace.Location = new System.Drawing.Point(6, 336);
            this.comboBoxFrameCharSpace.Name = "comboBoxFrameCharSpace";
            this.comboBoxFrameCharSpace.Size = new System.Drawing.Size(158, 21);
            this.comboBoxFrameCharSpace.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(170, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ms";
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMaster.ResumeLayout(false);
            this.groupBoxMaster.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxProtocole;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBoxMaster;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxTransactionAdres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTransaction;
        private System.Windows.Forms.GroupBox groupBoxSlave;
        private System.Windows.Forms.GroupBox groupBoxFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTimeLimit;
        private System.Windows.Forms.Button buttonMasterDataSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxRetransAdres;
        private System.Windows.Forms.ComboBox comboBoxFrameCharSpace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

