using System;
using System.IO.Ports;

namespace NeuroToSpiderDataVisualization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("COM - порт, на котором расположен паук:");
            string spiderComPort = Console.ReadLine();

            Console.WriteLine("COM - порт, на котором расположен нейроинтерфейс: ");
            string neurointerfaceComPort = Console.ReadLine();

            SerialPort spiderPort = new SerialPort(spiderComPort);
            //TODO: Можно попробовать подключить мой изначальный класс из проекта NeuroVR для считывания данных с нейроинтерфейса.
            SerialPort neurointerfacePort = new SerialPort(neurointerfaceComPort);

            //TODO: Настроить COM - порты.

            spiderPort.Open();
            neurointerfacePort.Open();

            try
            {
                while (true)
                {
                    //TODO: Реализовать считывание с нейроинтерфейса.
                    Console.WriteLine("Здесь выводятся данные с нейроинтерфейса!");
                    //TODO: Реализовать отправку данных на паука.
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
