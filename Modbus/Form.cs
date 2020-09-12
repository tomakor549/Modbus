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
using System.Globalization;

/*
 * Do zrobienia:
1. dodać sprawdzenie otrzymanych danych (LRC)
2. uzupełnić unfoldFrame

*/

namespace Modbus
{
    public partial class Form : System.Windows.Forms.Form
    {

        private string frame;

        //Dane do Mastera
        private int retransmission;
        private Stopwatch frameTime = new Stopwatch();
        private System.Timers.Timer transactionTimeout = new System.Timers.Timer();
        private OutFunctions outFunctions = new OutFunctions();

        //Dane do Slave'a
        byte slaveStationAdress;

        const string broadcastTransaction = "Rozgłoszeniowa";
        const string addressTransaction = "Adresowana";
        const string master = "Master";
        string protocole;
        string frameSpace;
        string slaveReply;

        public Form()
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
            numericUpDownSlaveAdress.Maximum = numericUpDownTransactionAdres.Maximum = 247;    //stąd, aby się nie przemęczać ograniczamy maksymalną ilość danych do posłania
            numericUpDownSlaveAdress.Minimum = numericUpDownTransactionAdres.Minimum = 1;

            //odczytanie dostępnych portów wraz z wpisanie ich do rozwijanej listy
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            for (int i = 100; i <= 10000; i = i + 100)
            {
                comboBoxMasterTimeLimit.Items.Add(i);
                comboBoxModbusFrameCharSpace.Items.Add(i / 10); //Master
                comboBoxSlaveFrameCharSpace.Items.Add(i / 10);  //Slave
            }
            for (int i = 0; i <= 5; i++)
            {
                comboBoxRetransNumber.Items.Add(i);
            }


            //ustawianie startowej wartości
            if (comboBoxTransaction.Items.Count > 0)
                comboBoxTransaction.SelectedIndex = 0;
            if (comboBoxMasterTimeLimit.Items.Count > 0)
                comboBoxMasterTimeLimit.SelectedIndex = 0;
            if (comboBoxRetransNumber.Items.Count > 0)
                comboBoxRetransNumber.SelectedIndex = 0;
            if (comboBoxModbusFrameCharSpace.Items.Count > 0)
                comboBoxModbusFrameCharSpace.SelectedIndex = 0;
            if (comboBoxOrderCode.Items.Count > 0)
                comboBoxOrderCode.SelectedIndex = 0;
            if (comboBoxPort.Items.Count > 0)
                comboBoxPort.SelectedIndex = 0;
            if (comboBoxSlaveFrameCharSpace.Items.Count > 0)
                comboBoxSlaveFrameCharSpace.SelectedIndex = 0;

            //aktywacja lub dezaktywacja kontrolek
            comboBoxProtocole.Enabled = true;
            comboBoxTransaction.Enabled = true;
            //numericUpDownSlaveAdress.Enabled = numericUpDownTransactionAdres.Enabled = false;
            groupBoxMaster.Enabled = false;
            groupBoxSlave.Enabled = false;
            buttonMasterConnect.Enabled = true;
            buttonMasterDataSend.Enabled = false;
            buttonMasterDisconnect.Enabled = false; 
            comboBoxPort.Enabled = true;
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
                protocole = master;
                groupBoxMaster.Enabled = true;
                groupBoxSlave.Enabled = false;
            }
            else
            {
                protocole = "Slave";
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
                if (protocole == master)
                    masterReceive();
                else
                    slaveReceive();
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
            sendMasterFrame();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                componentMasterState(false);

                //Ustawienie czasu oczekiwania na znak życia od slave'a
                transactionTimeout.Interval = Convert.ToInt32(comboBoxMasterTimeLimit.Text);

                //ustawienie ilości retransmisji
                retransmission = Convert.ToInt32(comboBoxRetransNumber.Text);

                //ustawianie portu
                serialPort.PortName = comboBoxPort.Text;

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

        private void buttonMasterDisconnected_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.Close();
                componentMasterState(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSlaveConnect_Click(object sender, EventArgs e)
        {
            try
            {
                componentMasterState(false);
                slaveStationAdress = Convert.ToByte(numericUpDownSlaveAdress.Value);

                //ustawianie portu
                serialPort.PortName = comboBoxPort.Text;

                //ograniczenie czasowe wysłania danych
                //serialPort.WriteTimeout = Convert.ToInt32(comboBoxTimeLimit.Text);
                // serialPort.ReadTimeout = Convert.ToInt32(comboBoxFrameCharSpace.Text);
                slaveReply = richTextBoxSlaveSend.Text;
                serialPort.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void componentMasterState(bool enabled)
        {
            comboBoxOrderCode.Enabled = enabled;
            comboBoxTransaction.Enabled = enabled;
            numericUpDownTransactionAdres.Enabled = enabled;
            comboBoxMasterTimeLimit.Enabled = enabled;
            comboBoxRetransNumber.Enabled = enabled;
            comboBoxModbusFrameCharSpace.Enabled = enabled;
            buttonMasterConnect.Enabled = enabled;
            buttonMasterDataSend.Enabled = !enabled;
            buttonMasterDisconnect.Enabled = !enabled;
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

            sendMasterFrame(); //jeśli trzeba retransmitować te dane, to wywołujemy tą funkcję
        }

        private void sendMasterFrame()
        {
            if (comboBoxTransaction.Text == broadcastTransaction)
                frame = outFunctions.createFrame((byte)0, (byte)Convert.ToByte(comboBoxOrderCode.Text), richTextBoxMasterSendMsg.Text);
            else
                frame = outFunctions.createFrame((byte)Convert.ToByte(numericUpDownTransactionAdres.Value.ToString()), (byte)Convert.ToByte(comboBoxOrderCode.Text), richTextBoxMasterSendMsg.Text);

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

        private void sendSlaveFrame()
        {
            if(slaveReply != "")
            {
                frame = outFunctions.createFrame((byte)0, (byte)0, slaveReply);
            }
            MessageBox.Show("Master prosi o odpowiedź, a twoja odpowiedź jest pusta!");

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

        public void masterReceive()
        {
            transactionTimeout.Stop();
            frameTime.Restart();    //odliczamy czas wczytywania ramki

            //wczytanie lini z serial portu do napotkania \n bez wczytania \n
            string msg = serialPort.ReadExisting() + "\n"; //\n dodajemy ręcznie, żeby data.Length nie był 0

            frameTime.Stop();       //zatrzymujemy odliczanie wczytywania ramki

            /*frameTime zwracamy w milisekundach i przeliczamy na ile milisekund przypada 1 znak z wczytanej ramki
            po czym sprawdzamy czy nie przekracza ograniczeniea czasowego na odstęp pomiędzy znakami ramki*/
            if (frameTime.ElapsedMilliseconds / msg.Length > Convert.ToInt32(frameSpace))
            {
                transactionTimeout.Start();
                return;
            }

            msg = outFunctions.returnFrameData(msg);

            if(msg!=null)
                MasterReceiveTxt(msg);
        }

        public void slaveReceive()
        {
            frameTime.Restart();    //odliczamy czas wczytywania ramki

            //wczytanie lini z serial portu do napotkania \n bez wczytania \n
            string msg = serialPort.ReadLine() + "\r\n"; //\n dodajemy ręcznie, żeby data.Length nie był 0

            frameTime.Stop();       //zatrzymujemy odliczanie wczytywania ramki

            /*frameTime zwracamy w milisekundach i przeliczamy na ile milisekund przypada 1 znak z wczytanej ramki
            po czym sprawdzamy czy nie przekracza ograniczeniea czasowego na odstęp pomiędzy znakami ramki*/
            if (frameTime.ElapsedMilliseconds / msg.Length > Convert.ToInt32(frameSpace))
            {
                MessageBox.Show("Przekroczono ograniczenie czasowe na odstęp pomiędzi znakami ramki");
                return;
            }

            FrameMainData frameData = outFunctions.returnFrameData(msg, slaveStationAdress);

            if (frameData == null)
                return;

            if (frameData.adress == 0)
            {
                slaveReceiveTxt(msg);
                return;
            }
            else
            {
                if(slaveStationAdress != frameData.adress)
                {
                    return;
                }
                else
                {
                    if (frameData.code == (byte)1)
                    {
                        slaveReceiveTxt(msg);
                    }
                    else
                    if (frameData.code == (byte)2)
                    {
                        sendSlaveFrame();
                    }
                    else
                        MessageBox.Show("Zła wartość rozkazu");
                }
            }
        }
        void slaveReceiveTxt(string txt)
        {
            //sprawdzenie czy komponent gdzie wypisywane są odebrane dane jest w tym samym wątku co odbiór danych
            if (richTextBoxSlaveReceivedMsg.InvokeRequired)
            {
                //utworzenie delegata (wskaźnika do mikro funkcji) metody do wpisywania danych w komponencie z bufora odbioru danych
                Action act = () => richTextBoxSlaveReceivedMsg.Text += txt;

                //wykonanie delegata dla wątku głównego
                Invoke(act);   //wywołanie delegata
            }
            else
            {
                //jeżeli jest w tym samym wątku przepisz normalnie dane z bufora do komponentu
                richTextBoxSlaveReceivedMsg.Text += txt;
            }
        }

        void MasterReceiveTxt(string txt)
        {
            //sprawdzenie czy komponent gdzie wypisywane są odebrane dane jest w tym samym wątku co odbiór danych
            if (richTextBoxMasterReceivedMsg.InvokeRequired)
            {
                //utworzenie delegata (wskaźnika do mikro funkcji) metody do wpisywania danych w komponencie z bufora odbioru danych
                Action act = () => richTextBoxMasterReceivedMsg.Text += txt;

                //wykonanie delegata dla wątku głównego
                Invoke(act);   //wywołanie delegata
            }
            else
            {
                //jeżeli jest w tym samym wątku przepisz normalnie dane z bufora do komponentu
                richTextBoxMasterReceivedMsg.Text += txt;
            }
        }

        private void comboBoxModbusFrameCharSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            frameSpace = comboBoxModbusFrameCharSpace.Text;
        }
    }
}
