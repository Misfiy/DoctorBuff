using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DoctorBuffed
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Amount of cures before 049-2 instances regenerate near 049")]
        public byte ZombieRegenCures { get; set; } = 4;
        [Description("Amount of cures before 049 gains AHP near 049-2 instances")]
        public byte DoctorRegenCures { get; set; } = 6;
        [Description("Amount of cures needed before 049-2 instances and 049 gain speed")]
        public byte SpeedBoostCures { get; set; } = 8;
        [Description("Amount of speed in % that the doctor will gain on SpeedBoostCures")]
        public byte SpeedBoostDoctor { get; set; } = 11;
        [Description("Amount of speed in % that the zombies will gain on SpeedBoostCures")]
        public byte SpeedBoostZombie { get; set; } = 11;
    }
}