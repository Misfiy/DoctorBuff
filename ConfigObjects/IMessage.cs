using System.ComponentModel;

namespace DoctorBuff.ConfigObjects
{
     public interface IMessage
     {
          [Description("Message to show to the 049")]
          public string DoctorMessage { get; set; }
          [Description("Message to show to the 049-2 instances")]
          public string ZombieMessage { get; set; }
     }
}
