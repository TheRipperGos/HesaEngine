using HesaEngine.SDK;
using static AwakenedTwitch.AwakenedTwitch;
using static AwakenedTwitch.TwitchMenu;

namespace AwakenedTwitch
{
    public class TwitchKillsteal
    {
        public static void UseKillsteal()
        {
            var etarg = TargetSelector.GetTarget(1200);

            if (etarg == null) return;
            
            if (Main.Get<MenuCheckbox>("KSE").Checked && E.IsReady())
            {
                if (etarg.HasBuff("TwitchDeadlyVenom") && E.GetDamage(etarg) >= etarg.Health)
                {
                    E.Cast();
                }
            }
        }
    }
}