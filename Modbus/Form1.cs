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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Uzupełnianie comboBox (list rozwijanych) o dane
            comboBoxProtocole.Items.Add("Master");
            comboBoxProtocole.Items.Add("Slave");
            comboBoxTransaction.Items.Add("Rozgłoszeniowa");
            comboBoxTransaction.Items.Add("Adresowana");

            for(int i = 0; i <= 10000; i = i + 100)
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

            //Blokada nieużywanych grup
            groupBoxMaster.Enabled = false;
            groupBoxSlave.Enabled = false;

            //aktywacja lub dezaktywacja kontrolek
            comboBoxProtocole.Enabled = true;
            comboBoxTransaction.Enabled = true;
            textBoxTransactionAdres.Enabled = false;
        }

        private void comboBoxProtocole_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (comboBoxTransaction.Text == "Adresowana")
                textBoxTransactionAdres.Enabled = true;
            else
                textBoxTransactionAdres.Enabled = false;
        }
    }
}
