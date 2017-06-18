using HesaEngine.SDK;
using static AwakenedTwitch.AwakenedTwitch;
using static AwakenedTwitch.TwitchMenu;

namespace AwakenedTwitch
{
    public class TwitchHarass
    {
        public static void UseHarass()
        {
            var wtarg = TargetSelector.GetTarget(950);

            if (wtarg == null) return;
            
            if (!Main.Get<MenuKeybind>("HT").Active) return;
            
            if (Main.Get<MenuSlider>("HMana").CurrentValue >= Twitch.ManaPercent) return;
            
            if (Main.Get<MenuCheckbox>("HW").Checked && W.IsReady())
            {
                var prediction = W.GetPrediction(wtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    W.Cast(prediction.CastPosition);
                }
            }
        }
    }
}