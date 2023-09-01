namespace DoctorBuffed
{
     using Exiled.API.Features;
     using Exiled.API.Enums;
     using DoctorBuffed.Events;
     using MEC;

     public class Plugin : Plugin<Config>
     {
          public override string Name => "049Buff";
          public override string Prefix => "DocBuff";
          public override string Author => "@misfiy";
          public override PluginPriority Priority => PluginPriority.Default;
          private Handler handler;
          public static Plugin Instance;
          private Config config;
          public override void OnEnabled()
          {
               Instance = this;
               config = Instance.Config;

               RegisterEvents();
               base.OnEnabled();
          }

          public override void OnDisabled()
          {
               UnregisterEvents();
               Instance = null!;
               base.OnDisabled();
          }
          public void RegisterEvents()
          {
               handler = new Handler();
               Exiled.Events.Handlers.Scp049.FinishingRecall += handler.OnFinishingRecall;
               Exiled.Events.Handlers.Server.WaitingForPlayers += handler.OnWaitingForPlayers;
               Log.Debug("Events have been registered!");
          }
          public void UnregisterEvents()
          {
               Exiled.Events.Handlers.Scp049.FinishingRecall -= handler.OnFinishingRecall;
               Exiled.Events.Handlers.Server.WaitingForPlayers -= handler.OnWaitingForPlayers;
               handler = null!;
               Timing.KillCoroutines();
          }
     }
}

// player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);