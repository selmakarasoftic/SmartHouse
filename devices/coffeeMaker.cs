using System;
using SmartHouse.Interface;

namespace SmartHouse.Devices
{
    public class CoffeeMaker : IDevicesBasic, IStatus
    {
        private string deviceName = "Coffee Maker";
        private bool status = false;
        private string coffeeType = "None";

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

        public void MakeCoffee(string type)
        {
            if (!status)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF.");
                return;
            }

            coffeeType = type;
            Console.WriteLine(Name + " is making: " + coffeeType);
            Thread.Sleep(10000);
            Console.WriteLine("Coffee is done! Enjoy your " + coffeeType + "!");
        }

        public string GetStatus()
        {
            return status ? $"{Name} is ON, Making: {coffeeType}" : $"{Name} is OFF.";
        }
    }
}
