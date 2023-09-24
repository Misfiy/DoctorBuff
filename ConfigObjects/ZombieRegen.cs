using Exiled.API.Enums;
using System.ComponentModel;

namespace DoctorBuff.ConfigObjects
{
     public class ZombieRegen : IMessage, ICurable
     {
          [Description("Amount of cures before 049-2 instances regenerate near 049")]
          public byte CuresNeeded { get; set; } = 4;

          public string DoctorMessage { get; set; } = "You leveled up! Zombies now regenerate near you!";
          public string ZombieMessage { get; set; } = "You now regenerate near 049!";
     }
}
