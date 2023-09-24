using System.ComponentModel;

namespace DoctorBuff.ConfigObjects
{
     public class SpeedBoost : IMessage, ICurable
     {
          [Description("Amount of cures before 049-2 instances regenerate near 049")]
          public byte CuresNeeded { get; set; } = 8;

          public string DoctorMessage { get; set; } = "You leveled up! You have gained speed!";
          public string ZombieMessage { get; set; } = "Your speed has increased speed!";

          [Description("Amount of speed in % that the doctor will gain")]
          public byte SpeedBoostDoctor { get; set; } = 11;
          [Description("Amount of speed in % that the zombies will gain")]
          public byte SpeedBoostZombie { get; set; } = 11;
     }
}
