using System;
using System.Collections.Generic;
using Exiled.API.Interfaces;
using Exiled.API.Enums;
using PlayerRoles;
using YamlDotNet.Serialization;
using Respawning;

namespace DoctorBuffed
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}