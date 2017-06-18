using HesaEngine.SDK;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasLaneclear
    {
        public static void UseLaneclear()
        {
            var qminion = MinionManager.GetMinions(Q.Range);
            var wminion = MinionManager.GetMinions(350);
            var circular = Q.GetCircularFarmLocation(qminion, 250);

            if (qminion == null) return;

            if (!Main.Get<MenuKeybind>("LT").Active) return;

            if (Main.Get<MenuSlider>("LMana").CurrentValue >= Gragas.ManaPercent) return;

            if (Q.IsReady() && Main.Get<MenuCheckbox>("LQ").Checked)
            {
                if (circular.MinionsHit >= Main.Get<MenuSlider>("LMin").CurrentValue)
                {
                    Q.Cast(circular.Position);
                }
            }

            if (W.IsReady() && Main.Get<MenuCheckbox>("LW").Checked)
            {
                if (wminion.Count >= Main.Get<MenuSlider>("LMin").CurrentValue)
                {
                    W.Cast();
                }
            }
        }
    }
}