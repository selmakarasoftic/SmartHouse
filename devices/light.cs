/*light will have an option to turn it on and off, 
if it is turned on - it should allow user to set the brightness, change color.
user can see the the current status of the light if wanted*/

using System

namespace SmartHouse.devices
{
    public classs light
    {
    private string Name;
    private bool Status;
    private interface Brightness;
    private String Color;

    public Light(string name, int brightness, string color)
    {
        Name = name;
        Brightness = brightness;
        Color = color;
        Status = false;
    }

    //giving the user option to turn on the light/change the status of light
    public void TurnOn()
    {
        Status = true;
        Console.WriteLine(Name + " is turned ON.")
    }
    public void TurnOff()
    {
        Status = false;
        Console.WriteLine(Name + " is turned OFF.")
        }

    //if the light is on user can change brightness and color 
    public void AdjustBrightness(int level)
    {
        if (Status == false)
        {
            Console.WriteLine(" Device: " + Name + " is currently OFF");
            return;
        }

        if (level > 100) level = 100;
        if (level < 0) level = 0;

        Brightness = level
        Console.WriteLine(Name + " has the brightness: " + Brightness)
    }

    public void ChangeColor(string ChangedColor)
    {
        if (Status == false)
        {
            Console.WriteLine(" Device: " + Name + " is currently OFF");
            return;
        }

        Color = ChangedColor;
        Console.WriteLine("Color of " + Name + " is now: " + Color);
    }
    public void ShowStatus()
    {
        Console.WriteLine(Name + " - " + (Status ? "ON" : "OFF") + ", Brightness: " + Brightness + "%, Color: " + Color);
    }
}
}