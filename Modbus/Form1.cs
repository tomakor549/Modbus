using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus
{
    public partial class Form1 : Form
    {
        const string broadcastTransaction = "Rozgłoszeniowa";
        const string addressTransaction = "Adresowana";
        string frame;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Uzupełnianie komponentów o dane
            comboBoxProtocole.Items.Add("Master");
            comboBoxProtocole.Items.Add("Slave");
            comboBoxTransaction.Items.Add(broadcastTransaction);
            comboBoxTransaction.Items.Add(addressTransaction);
            comboBoxOrderCode.Items.Add(1);
            comboBoxOrderCode.Items.Add(2);
            numericUpDownTransactionAdres.Maximum = 247;
            numericUpDownTransactionAdres.Minimum = 1;

            //ograniczenie textboxa wysyłającego dane
            richTextBoxMasterSendMsg.MaxLength = 252;

            //odczytanie dostępnych portów wraz z wpisanie ich do rozwijanej listy
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            comboBoxFrameCharSpace.Items.Add(0);

            for (int i = 100; i <= 10000; i = i + 100)
            {
                comboBoxTimeLimit.Items.Add(i);
                comboBoxFrameCharSpace.Items.Add(i / 10);
            }
            for (int i = 0; i <= 5; i++)
            {
                comboBoxRetransAdres.Items.Add(i);
            }

            //ustawianie startowej wartości
            comboBoxTransaction.SelectedIndex = 0;
            comboBoxTimeLimit.SelectedIndex = 0;
            comboBoxRetransAdres.SelectedIndex = 0;
            comboBoxFrameCharSpace.SelectedIndex = 0;
            comboBoxOrderCode.SelectedIndex = 0;
            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;

            //sortowanie
            comboBoxPort.Sorted = true;

            //aktywacja lub dezaktywacja kontrolek
            comboBoxProtocole.Enabled = true;
            comboBoxTransaction.Enabled = true;
            numericUpDownTransactionAdres.Enabled = false;
            groupBoxMaster.Enabled = false;
            groupBoxSlave.Enabled = false;
            buttonMasterConnect.Enabled = true;
            buttonMasterDataSend.Enabled = false;
            buttonMasterDisconnect.Enabled = false;

            //zmiana ustawień kontrolek
            richTextBoxMasterReceivedMsg.ReadOnly = true;
        }

        private void comboBoxProtocole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Wybór stacji Mster lub Slave
            if (comboBoxProtocole.Text == "Master" && comboBoxPort.Text != "")
            {
                groupBoxMaster.Enabled = true;
                groupBoxSlave.Enabled = false;
            }
            else
            {
                groupBoxMaster.Enabled = false;
                groupBoxSlave.Enabled = true;
            }

        }

        private void comboBoxTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kontrola poprawności danych
            if (comboBoxTransaction.Text == broadcastTransaction)
            {
                numericUpDownTransactionAdres.Enabled = false;
                comboBoxOrderCode.SelectedIndex = 0;
            }
            else
                numericUpDownTransactionAdres.Enabled = true;
        }

        private void comboBoxOrderCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kontrola poprawności danych
            if (comboBoxOrderCode.Text=="2" && comboBoxTransaction.Text == broadcastTransaction)
            {
                comboBoxOrderCode.SelectedIndex = 0;
            }
        }

        private void numericUpDownTransactionAdres_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //zamykanie portu po wyłączeniu programu
            if (serialPort.IsOpen)      
                serialPort.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadExisting();
        }

        public static byte calculateLRC(byte[] bytes)
        {
            byte LRC = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return LRC;
        }

        private void buttonMasterDataSend_Click(object sender, EventArgs e)
        {
            //Tworzenie ramki z wybranych danych
            //wysyłamy to gówno po znaku z ograniczeniem czasowym, stąd chary
            char[] sof = { ':' };
            char[] adres = numericUpDownTransactionAdres.Value.ToString().ToCharArray();
            char[] rozkaz = comboBoxOrderCode.Text.ToCharArray();
            char[] msg = richTextBoxMasterSendMsg.Text.ToCharArray();
            char[] lrc = calculateLRC(Encoding.ASCII.GetBytes(richTextBoxMasterSendMsg.Text.ToString())).ToString().ToCharArray();
            char[] endMaker = "/r/n".ToCharArray();

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {   //ustawianie portu - wymaga wielu zmian
                serialPort.PortName = comboBoxPort.Text;
                //ograniczenie czasowe wysłania danych
                serialPort.ReadTimeout = Convert.ToInt32(comboBoxTimeLimit.Text);  //albo WriteTimeout, nie wiem które

                serialPort.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonMasterDataSend.Enabled = true;
            buttonMasterConnect.Enabled = false;
            buttonMasterDisconnect.Enabled = true;
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Wybór stacji Master lub Slave
            if (comboBoxProtocole.Text == "Master" && comboBoxPort.Text != "")
            {
                groupBoxMaster.Enabled = true;
                groupBoxSlave.Enabled = false;
            }
            else
            {
                groupBoxMaster.Enabled = false;
                groupBoxSlave.Enabled = true;
            }
        }

        private void buttonMasterDisconnected_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonMasterDisconnect.Enabled = false;
            buttonMasterConnect.Enabled = true;
            buttonMasterDataSend.Enabled = false;
        }
    }
}
