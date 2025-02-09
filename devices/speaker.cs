using System;
using SmartHouse.Interface;

namespace SmartHouse.Devices
{
    public class Speaker : IDevicesBasic, IStatus
    {
        private string deviceName = "Speaker";
        private bool status = false;
        private int volume = 50;
        private string current = "No song playing";

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

        public void SetVolume(int level)
        {
            if (!status)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF.");
                return;
            }

            if (level < 0) level = 0;
            if (level > 100) level = 100;

            volume = level;
            Console.WriteLine(Name + " volume set to " + volume + "%.");
        }

        public void PlayMusic(string song)
        {
            if (!status)
            {
                Console.WriteLine(" Device: " + Name + " is currently OFF.");
                return;
            }

            current = song;
            Console.WriteLine(Name + " is now playing: " + current);
        }

        public string GetStatus()
        {
            return status ? $"{Name} is ON, Volume: {volume}%, Playing: {current}" : $"{Name} is OFF.";
        }
    }
}
