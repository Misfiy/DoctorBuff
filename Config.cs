using DoctorBuff.ConfigObjects;
using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DoctorBuffed
{
     public sealed class Config : IConfig
     {
          public bool IsEnabled { get; set; } = true;
          public bool Debug { get; set; } = false;

          public ZombieRegen ZombieRegen { get; set; } = new();

          public ZombieRegen DoctorRegen { get; set; } = new();

          public SpeedBoost SpeedBoost { get; set; } = new();
     }
}