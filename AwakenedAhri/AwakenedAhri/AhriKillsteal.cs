using HesaEngine.SDK;
using static AwakenedAhri.AwakenedAhri;
using static AwakenedAhri.AhriMenu;

namespace AwakenedAhri
{
    public class AhriKillsteal
    {
        public static void UseKillsteal()
        {
            var qtarg = TargetSelector.GetTarget(880);
            var etarg = TargetSelector.GetTarget(975);

            if (etarg == null) return;
            
            if (Main.Get<MenuCheckbox>("KSE").Checked && E.IsReady())
            {
                var prediction = E.GetPrediction(etarg);
                if (prediction.Hitchance >= HitChance.High && E.GetDamage(etarg) >= etarg.Health)
                {
                    E.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("KSQ").Checked && Q.IsReady())
            {
                var prediction = Q.GetPrediction(qtarg);
                if (prediction.Hitchance >= HitChance.High && Q.GetDamage(qtarg) >= qtarg.Health)
                {
                    Q.Cast(prediction.CastPosition);
                }
            }
        }
    }
}