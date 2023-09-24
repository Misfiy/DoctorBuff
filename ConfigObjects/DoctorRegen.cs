using System.ComponentModel;

namespace DoctorBuff.ConfigObjects
{
     public class DoctorRegen : IMessage, ICurable
     {
          [Description("Amount of cures before 049-2 instances regenerate near 049")]
          public byte CuresNeeded { get; set; } = 6;

          public string DoctorMessage { get; set; } = "You leveled up! You now gain AHP when zombies are near you!";
          public string ZombieMessage { get; set; } = "049 now gains AHP when near you!";


     }
}
