using System;
using System.Collections.Generic;
using System.IO.Ports;

namespace NeuroToSpiderDataVisualization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COM - порт, на котором расположен паук:");
            SerialPort spiderPort = new SerialPort(Console.ReadLine());
            spiderPort.Open();

            Console.WriteLine("COM - порт, на котором расположен нейроинтерфейс: ");
            SerialPort neurointerfacePort = new SerialPort(Console.ReadLine());
            neurointerfacePort.Open();

            try
            {
                while (true)
                {
                    int sync1, sync2;
                    do
                    {
                        sync1 = neurointerfacePort.ReadByte();
                        sync2 = neurointerfacePort.ReadByte();
                    } while (sync1 != 170 && sync2 != 170);
                    
                    int pLength = neurointerfacePort.ReadByte();
                    
                    byte[] bytes = new byte[pLength];
                    neurointerfacePort.Read(bytes, 0, pLength);

                    foreach (byte val in bytes) Console.Write(val + " ");
                    Console.WriteLine();

                    int checkSum = neurointerfacePort.ReadByte();

                    List<byte> spiderData = new List<byte>();
                    spiderData.Add(Convert.ToByte(sync1));
                    spiderData.Add(Convert.ToByte(sync2));
                    spiderData.Add(Convert.ToByte(pLength));
                    foreach (byte val in bytes) spiderData.Add(val);
                    spiderData.Add(Convert.ToByte(checkSum));

                    spiderPort.Write(spiderData.ToArray(), 0, spiderData.Count);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine("(ОШИБКА ВО ВРЕМЯ РАБОТЫ!) " + exp.Message);
            }

            spiderPort.Close();
            neurointerfacePort.Close();
        }
    }
}
