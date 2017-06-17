using HesaEngine.SDK;
using static AwakenedAhri.AwakenedAhri;
using static AwakenedAhri.AhriMenu;

namespace AwakenedAhri
{
    public class AhriLaneclear
    {
        public static void UseLaneclear()
        {
            var minion = MinionManager.GetMinions(Q.Range);
            var linear = Q.GetLineFarmLocation(minion);

            if (minion == null) return;

            if (!Main.Get<MenuKeybind>("LT").Active) return;

            if (Main.Get<MenuSlider>("LMana").CurrentValue >= Ahri.ManaPercent) return;

            if (Q.IsReady() && Main.Get<MenuCheckbox>("LQ").Checked)
            {
                if (linear.MinionsHit >= Main.Get<MenuSlider>("LMin").CurrentValue)
                {
                    Q.Cast(linear.Position);
                }
            }

            if (W.IsReady() && Main.Get<MenuCheckbox>("LW").Checked)
            {
                if (minion.Count >= Main.Get<MenuSlider>("LMin").CurrentValue)
                {
                    W.Cast();
                }
            }
        }
    }
}