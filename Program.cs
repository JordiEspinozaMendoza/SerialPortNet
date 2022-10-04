using System;
using System.IO.Ports;

namespace SerialPortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String portName = "/dev/tty.usbmodem1101"; // Change this to your port name
            SerialPort mySerialPort = new SerialPort(portName);
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            mySerialPort.DtrEnable = true;
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            mySerialPort.Open();
            Console.ReadKey();
            mySerialPort.Close();
        }

        private static void DataReceivedHandler(
                            object sender,
                            SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
    }
}