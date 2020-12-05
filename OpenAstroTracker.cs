using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace OATControlWPF
{
    class OpenAstroTracker
    {
        SerialPort _serial;

        public OpenAstroTracker(String comPort)
        {
            _serial = new SerialPort();
            _serial.PortName = comPort;
            _serial.BaudRate = 57600;
            _serial.DataBits = 8;
            _serial.StopBits = StopBits.One;
            _serial.Parity = Parity.None;
            _serial.Handshake = Handshake.None;
            _serial.ReadTimeout = 500;
            _serial.WriteTimeout = 500;
            _serial.Open();
        }

        public String SendCommand(String command)
        {
            _serial.Write(":" + command + "#");
            String response = "";
            try
            {
                while (true)
                {
                    int c = _serial.ReadChar();
                    if (c == '#')
                        break;
                    response += (Char)c;
                }
            }
            catch (TimeoutException)
            {
                response += "<timeout>"; // Return what we have
            }
            return response;
        }
    }
}
