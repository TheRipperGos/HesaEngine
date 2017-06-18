using HesaEngine.SDK;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasHarass
    {
        public static void UseHarass()
        {
            var qtarg = TargetSelector.GetTarget(850);

            if (qtarg == null) return;
            
            if (!Main.Get<MenuKeybind>("HT").Active) return;
            
            if (Main.Get<MenuSlider>("HMana").CurrentValue >= Gragas.ManaPercent) return;
            
            if (Main.Get<MenuCheckbox>("HQ").Checked && Q.IsReady())
            {
                var prediction = Q.GetPrediction(qtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    Q.Cast(prediction.CastPosition);
                }
            }
        }
    }
}