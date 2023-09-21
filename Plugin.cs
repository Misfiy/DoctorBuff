namespace DoctorBuffed
{
    using Exiled.API.Features;
    using Exiled.API.Enums;
    using DoctorBuffed.Events;
    using MEC;

    public class Plugin : Plugin<Config>
    {
        public override string Name => "Scp049Buff";
        public override string Prefix => "DoctorBuff";
        public override string Author => "@misfiy";
        public override Version Version => new(1, 1, 2);
        public override Version RequiredExiledVersion => new(8, 2, 1);

        private Handler handler;
        public static Plugin Instance;
        public override void OnEnabled()
        {
            Instance = this;

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