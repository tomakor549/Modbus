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
    
    struct Frame
    {
        public byte sof;
        public byte adres;
        public byte command;
        public byte[] msg;
        public byte lrc;
        public byte cr;
        public byte lf;

        public Frame(byte sof)
        {
            this.sof = sof;
            this.cr = Encoding.ASCII.GetBytes("\r")[0];
            this.lf = Encoding.ASCII.GetBytes("\n")[0];
            this.adres = Encoding.ASCII.GetBytes("0")[0];
            this.command = Encoding.ASCII.GetBytes("0")[0];
            this.lrc = Encoding.ASCII.GetBytes("0")[0];
            this.msg = null;
        }

        public void clearData()
        {
            this.adres = Encoding.ASCII.GetBytes("0")[0];
            this.command = Encoding.ASCII.GetBytes("0")[0];
            this.msg = null;
            this.lrc = Encoding.ASCII.GetBytes("0")[0];
        }
    }

    public partial class Form1 : Form
    {

        const string broadcastTransaction = "Rozgłoszeniowa";
        const string addressTransaction = "Adresowana";
        Frame frame;

        public Form1()
        {
            InitializeComponent();
            frame = new Frame(Encoding.ASCII.GetBytes(":")[0]);

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

            //zmiana ustawień kontrolek
            richTextBoxMasterReceivedMsg.ReadOnly = true;

            //ustawienia serialPort
            //kodowanie w ASCII
            serialPort.Encoding = Encoding.ASCII;
            //kontrola znaku
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
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

        public static byte calculateLRC(byte[] bytes, byte cr, byte lf)
        {
            byte LRC = 0;
            LRC ^= cr;
            LRC ^= lf;
            for (int i = 0; i < bytes.Length; i++)
            {
                LRC ^= bytes[i];
            }
            return LRC;
        }

        private void buttonMasterDataSend_Click(object sender, EventArgs e)
        {
            StringBuilder str;


            //Tworzenie ramki z wybranych danych
            //wysyłamy to gówno po znaku z ograniczeniem czasowym, stąd chary
            //Encoding.ASCII.GetBytes()
            frame.adres = Encoding.ASCII.GetBytes(numericUpDownTransactionAdres.Value.ToString().ToCharArray())[0];
            frame.command = Encoding.ASCII.GetBytes(comboBoxOrderCode.Text.ToCharArray())[0];
            frame.msg = Encoding.ASCII.GetBytes(richTextBoxMasterSendMsg.Text.ToCharArray());
            frame.lrc = calculateLRC(frame.msg, frame.cr, frame.lf);

            int msgLength = 6 + frame.msg.Length;
            if (frame.msg.Length > 0)
            {
                byte[] bytesToSend = new byte[msgLength];
                bytesToSend[0] = frame.sof;
                bytesToSend[1] = frame.adres;
                bytesToSend[2] = frame.command;
                for (int i = 3; i < msgLength-3; i++)
                {
                    bytesToSend[i] = frame.msg[i-3];
                }
                bytesToSend[msgLength-3] = frame.lrc;
                bytesToSend[msgLength-2] = frame.cr;
                bytesToSend[msgLength-1] = frame.lf;

                try
                {
                    serialPort.Write(bytesToSend, 0, bytesToSend.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
