using Exiled.Events.EventArgs.Player;
using Exiled.API.Enums;
using PlayerRoles;
using Respawning;
using Exiled.API.Features;
using MEC;
using UnityEngine;
using Exiled.Events.EventArgs.Scp049;

namespace DoctorBuffed.Events
{
    public sealed class Handler
    {
        Config config = Plugin.Instance.Config;
        public ushort CuredZombieCount;
        public void OnFinishingRecall(FinishingRecallEventArgs ev)
        {
            CuredZombieCount++;
            if(CuredZombieCount == config.ZombieRegenCures)
            {
                AnnounceLevelup(ev.Player, "You leveled up! Zombies now regenerate near you!", "You now regenerate near 049!");
                Timing.RunCoroutine(ZombieRegen(ev.Player));
            }
            if(CuredZombieCount == config.DoctorRegenCures)
            {
                AnnounceLevelup(ev.Player, "You leveled up! You now gain AHP when zombies are near you!", "049 now gains AHP when near you!");
                Timing.RunCoroutine(DoctorAHPGain(ev.Player));
            }
            Timing.CallDelayed(0.5f, () =>
            {
                if (CuredZombieCount >= config.SpeedBoostCures)
                {
                    foreach (Player player in Player.List.Where(x => x.IsScp))
                    {
                        if (player.Role.Type == RoleTypeId.Scp0492)
                        {
                            player.EnableEffect(EffectType.MovementBoost);
                            player.ChangeEffectIntensity(EffectType.MovementBoost, config.SpeedBoostZombie);
                            continue;
                        }
                        if (player.Role.Type == RoleTypeId.Scp049)
                        {
                            player.EnableEffect(EffectType.MovementBoost);
                            player.ChangeEffectIntensity(EffectType.MovementBoost, config.SpeedBoostDoctor);
                        }
                    }
                }
            });
        }
        public void OnWaitingForPlayers()
        {
            CuredZombieCount = 0;
        }
        private static void AnnounceLevelup(Player doctor, string doctorMessage, string zombieMessage)
        {
            doctor.ShowHint(doctorMessage, 6);
            foreach (Player ply in Player.List.Where(x => x.Role.Type == RoleTypeId.Scp0492))
            {
                ply.ShowHint(zombieMessage, 6);
            }
        }
        public IEnumerator<float> ZombieRegen(Player p)
        {
            while (p.Role.Type == RoleTypeId.Scp049)
            {
                foreach (Player ply in Player.List)
                {
                    if (ply.Role.Type == RoleTypeId.Scp0492 && Vector3.Distance(p.Position, ply.Position) <= 4)
                    {
                        ply.Heal(CuredZombieCount - 1);
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
        public IEnumerator<float> DoctorAHPGain(Player p)
        {
            while (p.Role.Type == RoleTypeId.Scp049)
            {
                foreach(Player ply in Player.List.Where(p => p.Role.Type == RoleTypeId.Scp0492))
                {
                    if(Vector3.Distance(p.Position, ply.Position) <= 4 && p.ArtificialHealth < (10 * CuredZombieCount) - 2f) p.ArtificialHealth += 2f;
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
    }
}