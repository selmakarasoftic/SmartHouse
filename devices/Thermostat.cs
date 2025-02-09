using System;
using SmartHouse.Interface;

namespace SmartHouse.Devices
{
    public class Thermostat : IDevicesBasic, IStatus
    {
        private string deviceName = "Thermostat";
        private bool status = false;
        private int temperature = 22;  

        public string Name
        {
            get { return deviceName; }
        }

        public void TurnOn()
        {
            status = true;
            Console.WriteLine(Name + " is turned ON.");
        }

        public void TurnOff()
        {
            status = false;
            Console.WriteLine(Name + " is turned OFF.");
        }

        public void SetTemperature(int temp)
        {
            if (!status)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF.");
                return;
            }

            if (temp < 16) temp = 16;  
            if (temp > 30) temp = 30;  

            temperature = temp;
            Console.WriteLine(Name + " temperature set to " + temperature + "°C.");
        }

        public string GetStatus()
        {
            return status ? $"{Name} is ON, Temperature: {temperature}°C." : $"{Name} is OFF.";
        }
    }
}
