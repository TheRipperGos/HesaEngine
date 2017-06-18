using HesaEngine.SDK;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasKillsteal
    {
        public static void UseKillsteal()
        {
            var qtarg = TargetSelector.GetTarget(850);
            var etarg = TargetSelector.GetTarget(600);
            var rtarg = TargetSelector.GetTarget(1000);

            if (etarg == null) return;
            
            if (Main.Get<MenuCheckbox>("KSR").Checked && R.IsReady())
            {
                var prediction = R.GetPrediction(rtarg);
                if (prediction.Hitchance >= HitChance.High && Q.GetDamage(rtarg) >= rtarg.Health)
                {
                    R.Cast(prediction.CastPosition);
                }
            }
            
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