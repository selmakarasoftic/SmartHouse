﻿using System;
using SmartHouse.Interface;
using SmartHouse.Devices;

class Program
{
    static void Main()
    {
        Console.WriteLine(" Hello user :) ");
        HomeHub homeHub = new HomeHub();

        while (true)
        {
            Console.WriteLine("Welcome to your Smart Home Hub! ");
            homeHub.ShowDevices();
            Console.WriteLine("Choose the device or type exit to close the app: ");
            string deviceName = Console.ReadLine() ?? "";
            if (deviceName.ToLower() == "exit") break;

            IStatus selected = homeHub.GetDevice(deviceName);
            if (selected == null)
            {
                Console.WriteLine(" No device with name: " + deviceName + ". Enter the device that is on the list.");
                continue;
            }
            ControlDevice(selected);
        }
    }

    static void ControlDevice(IStatus device)
    {
        while (true)
        {
            Console.WriteLine($"\n{device.GetStatus()}");

            if (device is Door)
            {
                Console.WriteLine("Option 1: Open Door");
                Console.WriteLine("Option 2: Close Door");
                Console.WriteLine("Option 3: Lock Door");
                Console.WriteLine("Option 4: Unlock Door");
            }
            else if (device is IDevicesBasic)
            {
                Console.WriteLine("Option 1: Turn ON");
                Console.WriteLine("Option 2: Turn OFF");

                if (device is Light)
                {
                    Console.WriteLine("Option 3: Change Brightness");
                    Console.WriteLine("Option 4: Change Color");
                }
                if (device is Thermostat)
                {
                    Console.WriteLine("Option 3: Set Temperature");
                }
                if (device is Speaker)
                {
                    Console.WriteLine("Option 3: Set Volume");
                    Console.WriteLine("Option 4: Play Music");
                }
                if (device is CoffeeMaker)
                {
                    Console.WriteLine("Option 3: Make Coffee");
                }
            }

            Console.WriteLine("Option 10: HomeHub Menu");
            Console.WriteLine("Write the number of option:");
            string choice = Console.ReadLine();

            if (device is Door door)
            {
                switch (choice)
                {
                    case "1":
                        door.TurnOn();
                        break;
                    case "2":
                        door.TurnOff();
                        break;
                    case "3":
                        door.LockDoor();
                        break;
                    case "4":
                        door.UnlockDoor();
                        break;
                }
            }
            else if (device is IDevicesBasic basicDevice)
            {
                switch (choice)
                {
                    case "1":
                        basicDevice.TurnOn();
                        break;
                    case "2":
                        basicDevice.TurnOff();
                        break;
                }

                if (device is Light light)
                {
                    switch (choice)
                    {
                        case "3":
                            Console.WriteLine("Enter brightness (between 0 and 100): ");
                            if (int.TryParse(Console.ReadLine(), out int brightness))
                            {
                                light.AdjustBrightness(brightness);
                            }
                            break;
                        case "4":
                            Console.WriteLine("Enter color: ");
                            string color = Console.ReadLine() ?? "White";
                            light.ChangeColor(color);
                            break;
                    }
                }

                if (device is Thermostat thermostat)
                {
                    switch (choice)
                    {
                        case "3":
                            Console.Write("Enter temperature (16-30°C): ");
                            if (int.TryParse(Console.ReadLine(), out int temp))
                            {
                                thermostat.SetTemperature(temp);
                            }
                            break;
                    }
                }
            }

            if (device is Speaker speaker)
            {
                switch (choice)
                {
                    case "3":
                        Console.Write("Enter volume (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int volume))
                        {
                            speaker.SetVolume(volume);
                        }
                        break;
                    case "4":
                        Console.Write("Enter song name: ");
                        string song = Console.ReadLine() ?? "No song";
                        speaker.PlayMusic(song);
                        break;
                }
            }

            if (device is CoffeeMaker coffeeMaker)
            {
                switch (choice)
                {
                    case "3":
                        Console.WriteLine("Choose coffee type:");
                        Console.WriteLine("1 - Espresso");
                        Console.WriteLine("2 - Espresso with Milk");
                        Console.WriteLine("3 - Cappuccino");

                        Console.Write("Enter your choice (1-3): ");
                        string coffeeChoice = Console.ReadLine() ?? "";
                        string coffeeType = "Unknown";

                        if (coffeeChoice == "1")
                        {
                            coffeeType = "Espresso";
                        }
                        else if (coffeeChoice == "2")
                        {
                            coffeeType = "Espresso with Milk";
                        }
                        else if (coffeeChoice == "3")
                        {
                            coffeeType = "Cappuccino";
                        }

                        if (coffeeType != "Unknown")
                        {
                            coffeeMaker.MakeCoffee(coffeeType);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice! Please select a number between 1 and 3.");
                        }
                        break;
                }
            }

            if (choice == "10") return;
        }
    }
}
