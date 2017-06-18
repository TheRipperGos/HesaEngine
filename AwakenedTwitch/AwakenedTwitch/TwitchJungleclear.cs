using HesaEngine.SDK;
using static AwakenedTwitch.AwakenedTwitch;
using static AwakenedTwitch.TwitchMenu;

namespace AwakenedTwitch
{
    public class TwitchJungleclear
    {
        public static void UseJungleclear()
        {
            var wminion = MinionManager.GetMinions(W.Range, MinionTypes.All, MinionTeam.Neutral);

            if (wminion == null) return;

            if (!Main.Get<MenuKeybind>("JT").Active) return;

            if (Main.Get<MenuSlider>("JMana").CurrentValue >= Twitch.ManaPercent) return;

            if (W.IsReady() && Main.Get<MenuCheckbox>("JW").Checked)
            {
                var wcir = W.GetCircularFarmLocation(wminion);
                W.Cast(wcir.Position);
            }
            
            if (!Main.Get<MenuCheckbox>("JE").Checked)
                return;

            var mobs = MinionManager.GetMinions(E.Range, MinionTypes.All, MinionTeam.Neutral);
            if (mobs.Count > 0)
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