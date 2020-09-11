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

/*
 * Do zrobienia:
2. wysyłanie i odbieranie danych na masterze
3. Obsługę wewnętrzną slava
4. W stacji MASTER i w stacji SLAVE należy umożliwić podgląd ramek wysłanej oraz
odebranej w kodzie heksadecymalnym.
*/

namespace Modbus
{
    public partial class Form1 : Form
    {

        private string frame;
        private string receivedData;

        const string broadcastTransaction = "Rozgłoszeniowa";
        const string addressTransaction = "Adresowana";

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
            //SerialPort.WriteBufferSize na start ma 2048 bitów (Właściwość ignoruje wszelkie wartości mniejsze niż 2048 czyli 256 B)
            numericUpDownTransactionAdres.Maximum = 247;    //stąd, aby się nie przemęczać ograniczamy maksymalną ilość danych do posłania
            numericUpDownTransactionAdres.Minimum = 1;

            //ograniczenie textboxa wysyłającego dane
            richTextBoxMasterSendMsg.MaxLength = 252;

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
                comboBoxRetransAdres.Items.Add(i);
            }

            //ustawianie startowej wartości
            comboBoxTransaction.SelectedIndex = 0;
            comboBoxTimeLimit.SelectedIndex = 0;
            comboBoxRetransAdres.SelectedIndex = 0;
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
            string data = serialPort.ReadExisting();
            try
            {
                byte[] readValBytes = new byte[((SerialPort)sender).BytesToRead];
                int iResult = ((SerialPort)sender).Read(readValBytes, 0, ((SerialPort)sender).BytesToRead);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void buttonMasterDataSend_Click(object sender, EventArgs e)
        {
            frame = createFrame((byte)Convert.ToByte(numericUpDownTransactionAdres.Value), (byte)Convert.ToByte(comboBoxOrderCode.Text), richTextBoxMasterSendMsg.Text);

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

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                buttonMasterDataSend.Enabled = true;
                buttonMasterConnect.Enabled = false;
                buttonMasterDisconnect.Enabled = true;
                comboBoxFrameCharSpace.Enabled = false;

                //ustawianie portu
                serialPort.PortName = comboBoxMasterPort.Text;

                //ograniczenie czasowe wysłania danych
                serialPort.WriteTimeout = Convert.ToInt32(comboBoxTimeLimit.Text);
                serialPort.ReadTimeout = Convert.ToInt32(comboBoxFrameCharSpace.Text);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sendData()
        {

        }

        private void serialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
           
        }

        private void richTextBoxMasterReceivedMsg_TextChanged(object sender, EventArgs e)
        {
            string data = serialPort.ReadExisting();

            //sprawdzenie czy komponent gdzie wypisywane są odebrane dane jest w tym samym wątku co odbiór danych
            if (richTextBoxMasterReceivedMsg.InvokeRequired)
            {
                //utworzenie delegata (wskaźnika do mikro funkcji) metody do wpisywania danych w komponencie z bufora odbioru danych
                Action act = () => richTextBoxMasterReceivedMsg.Text += data;

                //wykonanie delegata dla wątku głównego
                Invoke(act);   //wywołanie delegata
            }
            else
            {
                //jeżeli jest w tym samym wątku przepisz normalnie dane z bufora do komponentu
                richTextBoxMasterReceivedMsg.Text += data;
            }
        }

    }
}
