using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;


/*
 * Poprawić odbiór odowiedzi do mastera
 * 
 * */
namespace Modbus
{
    class FrameMainData
    {
        public byte adress;
        public byte code;
        public string msg;

        public FrameMainData(FrameMainData data)
        {
            adress = data.adress;
            code = data.code;
            msg = data.msg;
        }
        public FrameMainData(byte adress, byte code, string msg)
        {
            this.adress = adress;
            this.code = code;
            this.msg = msg;
        }
    }

    class OutFunctions
    {
        public byte convertLRC(byte transactionAdres, byte orderCode, string StringData)
        {
            //tworzenie LRC
            byte LRC = 0;
            LRC ^= transactionAdres;
            LRC ^= orderCode;

            if (!string.IsNullOrEmpty(StringData))
            {
                foreach (var bytesData in StringData)
                {
                    LRC ^= (byte)bytesData;
                }
            }
            return LRC;
        }

        public string createFrame(byte transactionAdres, byte orderCode, string stringData)
        {
            //tworzenie LRC
            byte LRC = convertLRC(transactionAdres, orderCode, stringData);

            //tworzenie ramki - dane w {0:X2} formacie HEX bo poza znakami specjalnymi zajmuje bo 2 bajty pamięci na znak
            //dzięki temu nie musimy się martwić różnymi rozmiarami znaków
            //i mamy od razu wiadomość w hex do wypisania w oknie (polecenie)
            string msg = ":" + string.Format("{0:X2}", transactionAdres) + string.Format("{0:X2}", orderCode);

            if (!string.IsNullOrEmpty(stringData))
            {
                foreach (var bytesData in stringData)
                {
                    msg += string.Format("{0:X2}", (byte)bytesData);
                }
            }

            msg += string.Format("{0:X2}", (byte)LRC);
            msg += "\r\n";

            return msg;
        }

        public FrameMainData returnFrameData(string message, byte stationAdress)
        {
            
            if (message.Length > 9)
            {
                if (string.IsNullOrEmpty(message) || message[0] != ':')
                    return null;

                byte adress = byte.Parse(message.Substring(1, 2), NumberStyles.HexNumber);
                if(adress != (byte)0)
                    if (stationAdress != adress)
                        return null;

                byte code = byte.Parse(message.Substring(3, 2), NumberStyles.HexNumber);
                byte lrc = byte.Parse(message.Substring(message.Length - 4, 2), NumberStyles.HexNumber);

                string msg = message.Substring(5, message.Length - 5 - 4);
                if (lrc != convertLRC((byte)adress, (byte)code, hexToString(msg)))
                    return null;


                FrameMainData frameMainData = new FrameMainData(adress, code, msg);
                return frameMainData;
            }

            return null;
        }

        public string returnFrameData(string frame)
        {

            if (frame.Length > 9)
            {
                if (string.IsNullOrEmpty(frame) || frame[0] != ':')
                    return null;

                byte adress = byte.Parse(frame.Substring(1, 2), NumberStyles.HexNumber);
                byte code = byte.Parse(frame.Substring(3, 2), NumberStyles.HexNumber);

                byte lrc = byte.Parse(frame.Substring(frame.Length - 4, 2), NumberStyles.HexNumber);

                if (lrc != convertLRC(adress, code, frame.Substring(5, frame.Length - 5)))
                    return null;

                string msg = frame.Substring(5, frame.Length - 5);

                return msg;
            }

            return null;
        }

        public string hexToString(string hexString)
        {
            try
            {
                string ascii = string.Empty;

                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;

                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;

                }

                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;

        }
    }
}
