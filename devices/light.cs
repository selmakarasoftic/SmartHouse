/*light will have an option to turn it on and off, 
if it is turned on - it should allow user to set the brightness, change color.
user can see the the current status of the light if wanted*/

using System;
using SmartHouse.Interface;

namespace SmartHouse.Devices
{
    public class Light : IDevicesBasic, IStatus
    {
        private string deviceName = "Light";
        private bool status = false;
        private int brightness = 100;
        private string color = "White";

        public string Name
        {
            get { return deviceName; }
        }

        //giving the user option to turn on the light/change the status of light
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

        //if the light is on user can change brightness and color 
        public void AdjustBrightness(int level)
        {
            if (status == false)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF");
                return;
            }

            if (level > 100) level = 100;
            if (level < 0) level = 0;

            brightness = level;
            Console.WriteLine(Name + " has the brightness: " + brightness);
        }

        //user can change the color of smart light
        public void ChangeColor(string changedColor)
        {
            if (status == false)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF");
                return;
            }

            color = changedColor;
            Console.WriteLine("Color of " + Name + " is now: " + color);
        }

        //user can see the current status of the device 
        public string GetStatus()
        {
            return status ? $"{Name} is ON, Brightness: {brightness}%, Color: {color}" : $"{Name} is OFF";
        }
    }
}