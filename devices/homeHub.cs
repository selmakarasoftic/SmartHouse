using System;
using System.Collections.Generic;
using SmartHouse.Devices;
using SmartHouse.Interface;
//homeHub will have the list of all devices and will let the user chose which device to control 
namespace SmartHouse.Devices
{
    public class HomeHub
    {
        private Dictionary<string, IStatus> devices = new Dictionary<string, IStatus>();
        public HomeHub()
        {
            devices["Light"] = new Light();
            devices["Door"] = new Door();
        }

        public void ShowDevices()
        {
            Console.WriteLine("Devices: ");
            foreach (var device in devices.Keys)
            {
                Console.WriteLine($"- {device}");
            }
        }
        public IStatus GetDevice(string name)
        {
            return devices.ContainsKey(name) ? devices[name] : null;
        }
    }
}