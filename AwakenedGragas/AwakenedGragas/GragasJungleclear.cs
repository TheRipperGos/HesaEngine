using HesaEngine.SDK;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasJungleclear
    {
        public static void UseJungleclear()
        {
            var qminion = MinionManager.GetMinions(Q.Range, MinionTypes.All, MinionTeam.Neutral);
            var wminion = MinionManager.GetMinions(350, MinionTypes.All, MinionTeam.Neutral);
            var eminion = MinionManager.GetMinions(E.Range, MinionTypes.All, MinionTeam.Neutral);

            if (qminion == null) return;

            if (!Main.Get<MenuKeybind>("JT").Active) return;

            if (Main.Get<MenuSlider>("JMana").CurrentValue >= Gragas.ManaPercent) return;

            if (Q.IsReady() && Main.Get<MenuCheckbox>("JQ").Checked)
            {
                var qcir = Q.GetCircularFarmLocation(qminion);
                Q.Cast(qcir.Position);
            }

            if (W.IsReady() && Main.Get<MenuCheckbox>("JW").Checked)
            {
                if (wminion == null) return;
                W.Cast();
            }
        }
    }
}