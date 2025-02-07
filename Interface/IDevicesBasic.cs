using System;
namespace SmartHouse.Interface
{
 public interface IDevicesBasic{
    string Name{get;}
    void TurnOff();
    void TurnOn();
 }
}