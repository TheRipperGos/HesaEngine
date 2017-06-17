using HesaEngine.SDK;
using static AwakenedAhri.AwakenedAhri;
using static AwakenedAhri.AhriMenu;

namespace AwakenedAhri
{
    public class AhriHarass
    {
        public static void UseHarass()
        {
            var qtarg = TargetSelector.GetTarget(880);
            var etarg = TargetSelector.GetTarget(975);

            if (etarg == null) return;
            
            if (!Main.Get<MenuKeybind>("HT").Active) return;
            
            if (Main.Get<MenuSlider>("HMana").CurrentValue >= Ahri.ManaPercent) return;
            
            if (Main.Get<MenuCheckbox>("HE").Checked && E.IsReady())
            {
                var prediction = E.GetPrediction(etarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    E.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("HQ").Checked && Q.IsReady())
            {
                var prediction = Q.GetPrediction(qtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    Q.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("HW").Checked && W.IsReady())
            {
                if (ObjectManager.Player.CountEnemiesInRange(700f) >= 1)
                {
                    W.Cast();
                }
            }
        }
    }
}