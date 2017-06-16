using HesaEngine.SDK;
using static AwakenedAhri.AwakenedAhri;
using static AwakenedAhri.AhriMenu;

namespace AwakenedAhri
{
    public class AhriCombo
    {
        public static void UseCombo()
        {
            var qtarg = TargetSelector.GetTarget(880);
            var etarg = TargetSelector.GetTarget(975);

            if (etarg == null) return;
            
            if (Main.Get<MenuCheckbox>("CE").Checked && E.IsReady())
            {
                var prediction = E.GetPrediction(etarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    E.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("CQ").Checked && Q.IsReady())
            {
                var prediction = Q.GetPrediction(qtarg);
                if (prediction.Hitchance >= HitChance.High)
                {
                    Q.Cast(prediction.CastPosition);
                }
            }
            
            if (Main.Get<MenuCheckbox>("CW").Checked && W.IsReady())
            {
                if (ObjectManager.Player.CountEnemiesInRange(700f) >= 1)
                {
                    W.Cast();
                }
            }

            if (Main.Get<MenuCheckbox>("CR").Checked && R.IsReady())
            {
                if (ObjectManager.Player.CountEnemiesInRange(750f) >= 1 && IsRActive())
                {
                    R.Cast(Game.CursorPosition);
                }
            }
            
            bool IsRActive()
            {
                return ObjectManager.Player.HasBuff("AhriTumble");
            }
        }
    }
}