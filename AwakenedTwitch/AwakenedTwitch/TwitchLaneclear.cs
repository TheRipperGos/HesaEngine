using HesaEngine.SDK;
using static AwakenedTwitch.AwakenedTwitch;
using static AwakenedTwitch.TwitchMenu;

namespace AwakenedTwitch
{
    public class TwitchLaneclear
    {
        public static void UseLaneclear()
        {
            var wminion = MinionManager.GetMinions(W.Range);
            var circular = W.GetCircularFarmLocation(wminion, 250);

            if (wminion == null) return;

            if (!Main.Get<MenuKeybind>("LT").Active) return;

            if (Main.Get<MenuSlider>("LMana").CurrentValue >= Twitch.ManaPercent) return;

            if (W.IsReady() && Main.Get<MenuCheckbox>("LW").Checked)
            {
                if (circular.MinionsHit >= Main.Get<MenuSlider>("LMin").CurrentValue)
                {
                    W.Cast(circular.Position);
                }
            }
            
            var mobs = MinionManager.GetMinions(E.Range);
            if (mobs.Count >= Main.Get<MenuSlider>("LMin").CurrentValue)
            {
                var mob = mobs[0];
                if (E.IsKillable(mob))
                {
                    E.Cast();
                }
            }
        }
    }
}