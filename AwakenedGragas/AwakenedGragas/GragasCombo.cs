using HesaEngine.SDK;
using HesaEngine.SDK.GameObjects;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasCombo
    {
        public static void UseCombo()
        {
            var qtarg = TargetSelector.GetTarget(850);
            var etarg = TargetSelector.GetTarget(600);
            var rtarg = TargetSelector.GetTarget(850);

            if (rtarg == null) return;

            if (Main.Get<MenuCheckbox>("CR").Checked && R.IsReady() && GetComboDamage(rtarg) >= rtarg.Health)
            {
                R.Cast(rtarg.Position.Extend(Gragas, - 200f));
            }
            
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
            
            if (Main.Get<MenuCheckbox>("CW").Checked && W.IsReady() && !E.IsReady())
            {
                if (ObjectManager.Player.CountEnemiesInRange(300f) >= 1)
                {
                    W.Cast();
                }
            }
        }
        
        private static int GetComboDamage(Obj_AI_Base rtarg)
        {
            var damage = 0;
            if (Q.IsReady())
            {
                damage += (int)Q.GetDamage(rtarg);
            }
            if (E.IsReady())
            {
                damage += (int)E.GetDamage(rtarg);
            }
            if (R.IsReady())
            {
                damage += (int)R.GetDamage(rtarg);
            }
            return damage;
        }
    }
}