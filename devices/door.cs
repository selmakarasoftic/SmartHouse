using System;
using SmartHouse.Interface;
namespace SmartHouse.Devices
{
    public class Door : IStatus, IDevicesBasic
    {
        private string deviceName = "Door";
        private bool status = false; //here the status would represent weather the door is closed-false  or open-true
        private bool locked = true;

        public string Name
        {
            get { return deviceName; }
        }

        //the user can open and close the doors 
        public void TurnOn()
        {
            if (locked)
            {
                Console.WriteLine(Name + " is locked, can not open.");
                return;
            }
            status = true;
            Console.WriteLine(Name + " is opened.");
        }

        public void TurnOff()
        {
            status = false;
            Console.WriteLine(Name + " is closed.");
        }

        //user can lock and unlock the door 
        public void UnlockDoor()
        {
            locked = false;
            Console.WriteLine(Name + " is unlocked.");
        }
        public void LockDoor()
        {
            if (status)
            {
                Console.WriteLine(Name + " is opened, can not lock them.");
                return;
            }
            locked = true;
            Console.WriteLine(Name + " is locked.");
        }

        public string GetStatus()
        {
            return $"{Name} is {(status ? "OPEN" : "CLOSED")}, and it is {(locked ? "LOCKED" : "UNLOCKED")}.";
        }
    }
}