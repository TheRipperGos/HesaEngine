using HesaEngine.SDK;
using static AwakenedTwitch.AwakenedTwitch;
using static AwakenedTwitch.TwitchMenu;

namespace AwakenedTwitch
{
    public class TwitchCombo
    {
        public static void UseCombo()
        {
            var wtarg = TargetSelector.GetTarget(950);
            var etarg = TargetSelector.GetTarget(1200);
            var rtarg = TargetSelector.GetTarget(850);

            if (wtarg == null) return;
            
            if (Main.Get<MenuCheckbox>("CE").Checked && E.IsReady())
            {
                if (etarg.HasBuff("TwitchDeadlyVenom") && E.GetDamage(etarg) >= etarg.Health)
                {
                    E.Cast();
                }
            }

            if (Main.Get<MenuCheckbox>("CW").Checked && W.IsReady())
            {
                var prediction = W.GetPrediction(wtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    W.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("CR").Checked &&R.IsReady())
            {
                if (Twitch.GetAutoAttackDamage(rtarg) * 4 > rtarg.Health)
                {
                    R.Cast();
                }
            }
        }
    }
}