using System;
namespace SmartHouse.Interface
{
 public interface DevicesBasic{
    string Name{get;}
    void TurnOff();
    void TurnOn();
    string GetStatus();
 }
}