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
        public ushort CuredZombieCount;
        public void OnFinishingRecall(FinishingRecallEventArgs ev)
        {
            CuredZombieCount++;
            switch (CuredZombieCount)
            {
                case 4:
                    AnnounceLevelup(ev.Player, "You leveled up! Zombies now regenerate near you!", "You now regenerate near 049!");
                    Timing.RunCoroutine(HealBuff(ev.Player));
                    break;
                case 6:
                    AnnounceLevelup(ev.Player, "You leveled up! You now gain AHP when zombies are near you!", "049 now gains AHP when near you!");
                    break;
                case 8:
                    AnnounceLevelup(ev.Player, "You leveled up! You and your zombies have gained speed!", "You have gained speed!");
                    break;
                default:
                    ev.Player.ShowHint($"You have cured {CuredZombieCount} zombie(s)!");
                    break;
            }
            Timing.CallDelayed(0.5f, () =>
            {
                if (CuredZombieCount >= 8)
                {
                    foreach (Player player in Player.List.Where(x => x.IsScp))
                    {
                        if (player.Role.Type == RoleTypeId.Scp0492)
                        {
                            player.EnableEffect(EffectType.MovementBoost);
                            player.ChangeEffectIntensity(EffectType.MovementBoost, 7);
                            continue;
                        }
                        if (player.Role.Type == RoleTypeId.Scp049)
                        {
                            player.EnableEffect(EffectType.MovementBoost);
                            player.ChangeEffectIntensity(EffectType.MovementBoost, 11);
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
        public IEnumerator<float> HealBuff(Player p)
        {
            while (p.Role.Type == RoleTypeId.Scp049)
            {
                foreach (Player ply in Player.List)
                {
                    if (ply.Role.Type == RoleTypeId.Scp0492 && Vector3.Distance(p.Position, ply.Position) <= 4)
                    {
                        ply.Heal(CuredZombieCount - 1);
                        if (CuredZombieCount >= 6 && p.ArtificialHealth < (10 * CuredZombieCount) - 2f)
                        {
                            p.ArtificialHealth += 2f;
                        }
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
        }
    }
}