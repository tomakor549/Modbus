using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

/*
 * Do zrobienia:
1. dodać sprawdzenie otrzymanych danych (LRC)
2. uzupełnić unfoldFrame

*/

namespace Modbus
{
    public partial class Form1 : Form
    {

        private string frame;
        private int retransmission;
        private Stopwatch frameTime = new Stopwatch();
        private System.Timers.Timer transactionTimeout = new System.Timers.Timer();

        const string broadcastTransaction = "Rozgłoszeniowa";
        const string addressTransaction = "Adresowana";

        public Form1()
        {
            InitializeComponent();

        }


        public static string createFrame(byte transactionAdres, byte orderCode, string StringData)
        {
            //tworzenie LRC
            byte LRC = 0;
            LRC ^= transactionAdres;
            LRC ^= orderCode;

            //tworzenie ramki
            string msg = ":" + string.Format("{0:X2}", transactionAdres) + string.Format("{0:X2}", orderCode);

            if (!string.IsNullOrEmpty(StringData))
            {
                foreach (var bytesData in StringData)
                {
                    byte data = (byte)bytesData;
                    LRC ^= data;
                    msg += string.Format("{0:X2}", data);
                }
            }

            msg += string.Format("{0:X2}", LRC);
            msg += "\r\n";

            return msg;
        }

        public static string unfoldFrame(string data)
        {
            return data;
        }

        private void sendFrame()
        {
            frame = createFrame((byte)Convert.ToByte(numericUpDownTransactionAdres.Value.ToString()), (byte)Convert.ToByte(comboBoxOrderCode.Text), richTextBoxMasterSendMsg.Text);

            try
            {
                if (serialPort.IsOpen)
                {
                    //wysłanie bufora na łącze
                    serialPort.Write(frame);

                    richTextBoxMasterSendMsg.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void timeReceive()
        {
            //Reakcja na minięcie czasu wykonania transakcji
            retransmission--;
            //sprawdzić, czy yrzeba wykonać retransmisję
            if (retransmission <= 0)
            {
                MessageBox.Show("Brakodpowiedzi od stacji Slave");
                return;
            }

            sendFrame(); //jeśli trzeba retransmitować te dane, to wywołujemy tą funkcję
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
            //SerialPort.WriteBufferSize na start ma 2048 bitów (Właściwość ignoruje wszelkie wartości mniejsze niż 2048 czyli 256 B)
            numericUpDownTransactionAdres.Maximum = 247;    //stąd, aby się nie przemęczać ograniczamy maksymalną ilość danych do posłania
            numericUpDownTransactionAdres.Minimum = 1;

            //odczytanie dostępnych portów wraz z wpisanie ich do rozwijanej listy
            comboBoxMasterPort.Items.AddRange(SerialPort.GetPortNames());

            comboBoxFrameCharSpace.Items.Add(0);

            for (int i = 100; i <= 10000; i = i + 100)
            {
                comboBoxTimeLimit.Items.Add(i);
                comboBoxFrameCharSpace.Items.Add(i / 10);
            }
            for (int i = 0; i <= 5; i++)
            {
                comboBoxRetransNumber.Items.Add(i);
            }

            //ustawianie startowej wartości
            comboBoxTransaction.SelectedIndex = 0;
            comboBoxTimeLimit.SelectedIndex = 0;
            comboBoxRetransNumber.SelectedIndex = 0;
            comboBoxFrameCharSpace.SelectedIndex = 0;
            comboBoxOrderCode.SelectedIndex = 0;
            if (comboBoxMasterPort.Items.Count > 0)
                comboBoxMasterPort.SelectedIndex = 0;

            //sortowanie
            comboBoxMasterPort.Sorted = true;

            //aktywacja lub dezaktywacja kontrolek
            comboBoxProtocole.Enabled = true;
            comboBoxTransaction.Enabled = true;
            numericUpDownTransactionAdres.Enabled = false;
            groupBoxMaster.Enabled = false;
            groupBoxSlave.Enabled = false;
            buttonMasterConnect.Enabled = true;
            buttonMasterDataSend.Enabled = false;
            buttonMasterDisconnect.Enabled = false; 
            comboBoxMasterPort.Enabled = true;
            richTextBoxMasterReceivedMsg.ReadOnly = true;

            //zmiana ustawień kontrolek
            richTextBoxMasterReceivedMsg.ReadOnly = true;

            //ustawienia serialPort
            //kodowanie w ASCII
            serialPort.Encoding = Encoding.ASCII;
            //kontrola znaku
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.DtrEnable = true;
            serialPort.NewLine = "\r\n";

            //ustawianie czasu
            transactionTimeout.AutoReset = false;
            transactionTimeout.Elapsed += delegate { timeReceive(); };
        }

        private void comboBoxProtocole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Wybór stacji Mster lub Slave
            if (comboBoxProtocole.Text == "Master")
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
            try
            {
                transactionTimeout.Stop();
                frameTime.Restart();    //odliczamy czas wczytywania ramki
                //wczytanie lini z serial portu do napotkania \n bez wczytania \n
                string data = serialPort.ReadLine() + "\n"; //\n dodajemy ręcznie, żeby data.Length nie był 0
                frameTime.Stop();       //zatrzymujemy odliczanie wczytywania ramki
                //frameTime zwracamy w milisekundach i przeliczamy na ile milisekund przypada 1 znak z wczytanej ramki
                //po czym sprawdzamy czy nie przekracza ograniczeniea czasowego na odstęp pomiędzy znakami ramki
                if (frameTime.ElapsedMilliseconds / data.Length > Convert.ToInt32(comboBoxFrameCharSpace.Text))
                {
                    transactionTimeout.Start();
                    return;
                }
                
                richTextBoxMasterReceivedMsg.Text = unfoldFrame(data);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMasterDataSend_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBoxOrderCode.Text) == 2)
                transactionTimeout.Start();
            sendFrame();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                buttonMasterDataSend.Enabled = true;
                buttonMasterConnect.Enabled = false;
                buttonMasterDisconnect.Enabled = true;
                comboBoxFrameCharSpace.Enabled = false;
                comboBoxRetransNumber.Enabled = false;

                //Ustawienie czasu oczekiwania na znak życia od slave'a
                transactionTimeout.Interval = Convert.ToInt32(comboBoxTimeLimit.Text);

                //ustawienie ilości retransmisji
                retransmission = Convert.ToInt32(comboBoxRetransNumber.Text);

                //ustawianie portu
                serialPort.PortName = comboBoxMasterPort.Text;

                //ograniczenie czasowe wysłania danych
                //serialPort.WriteTimeout = Convert.ToInt32(comboBoxTimeLimit.Text);
               // serialPort.ReadTimeout = Convert.ToInt32(comboBoxFrameCharSpace.Text);

                serialPort.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonMasterDisconnected_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
                buttonMasterDisconnect.Enabled = false;
                buttonMasterConnect.Enabled = true;
                buttonMasterDataSend.Enabled = false;
                comboBoxFrameCharSpace.Enabled = true;
                comboBoxRetransNumber.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBoxMasterReceivedMsg_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
