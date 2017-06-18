using HesaEngine.SDK;
using static AwakenedGragas.AwakenedGragas;
using static AwakenedGragas.GragasMenu;

namespace AwakenedGragas
{
    public class GragasInsec
    {
        public static void UseInsec()
        {
            var rtarg = TargetSelector.GetTarget(850);

            if (rtarg == null) return;
            
            if (!Main.Get<MenuKeybind>("IK").Active) return;

            if (Main.Get<MenuCheckbox>("IR").Checked && R.IsReady())
            {
                R.Cast(rtarg.Position.Extend(Gragas, - 200f));
            }
        }
    }
}