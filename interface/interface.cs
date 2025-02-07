namespace SmartHouse.interface
{
 public interface devicesBasic{
    string Name{get;}
    void TurnOff();
    void TurnOn();
    string GetStatus();
 }
}