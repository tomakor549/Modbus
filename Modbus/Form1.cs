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
            //Uzupełnianie comboBox (list rozwijanych) o dane
            comboBoxProtocole.Items.Add("Master");
            comboBoxProtocole.Items.Add("Slave");
            comboBoxTransaction.Items.Add(broadcastTransaction);
            comboBoxTransaction.Items.Add(addressTransaction);
            comboBoxOrderCode.Items.Add(1);
            comboBoxOrderCode.Items.Add(2);
            numericUpDownTransactionAdres.Maximum = 247;
            numericUpDownTransactionAdres.Minimum = 1;

            //odczytanie dostępnych portów wraz z wpisanie ich do rozwijanej listy
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            for (int i = 0; i <= 10000; i = i + 100)
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

            //Blokada nieużywanych elementów
            groupBoxMaster.Enabled = false;
            groupBoxSlave.Enabled = false;
            buttonConnect.Enabled = false;

            //aktywacja lub dezaktywacja kontrolek
            comboBoxProtocole.Enabled = true;
            comboBoxTransaction.Enabled = true;
            numericUpDownTransactionAdres.Enabled = false;
        }

        private void comboBoxProtocole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Wybór stacji Mster lub Slave
            if (comboBoxProtocole.Text != "" && comboBoxPort.Text != "")
                buttonConnect.Enabled = true;

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
            char sof = ':';
            char[] adres = numericUpDownTransactionAdres.Value.ToString().ToCharArray();
            char[] rozkaz = comboBoxOrderCode.Text.ToCharArray();
            char[] msg = richTextBoxMasterSendMsg.Text.ToCharArray();
            char[] lrc = calculateLRC(Encoding.ASCII.GetBytes(richTextBoxMasterSendMsg.Text.ToString())).ToString().ToCharArray();
            char[] endMaker = "/r/n".ToCharArray();

            string frame = sof.ToString() + adres.ToString() + rozkaz.ToString() + msg.ToString() + lrc.ToString() + endMaker.ToString(); ;

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(comboBoxProtocole.Text == "Master")
            {
                groupBoxMaster.Enabled = true;
                groupBoxSlave.Enabled = false;
            }
            else
            {
                groupBoxMaster.Enabled = false;
                groupBoxSlave.Enabled = true;
            }

            try
            {
                serialPort.PortName = comboBoxPort.Text;                                    //ustawianie portu
                serialPort.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
