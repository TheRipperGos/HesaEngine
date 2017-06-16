using System;
using HesaEngine.SDK;
using SharpDX;
using static AwakenedAhri.AwakenedAhri;
using static AwakenedAhri.AhriMenu;

namespace AwakenedAhri
{
    public class AhriDrawings
    {
        public static void SetDrawings()
        {
            Drawing.OnDraw += Ondrawing;
        }

        private static void Ondrawing(EventArgs args)
        {
            if (Main.Get<MenuCheckbox>("DrawQ").Checked && Q.IsReady())
            {
                Drawing.DrawCircle(ObjectManager.Player.Position,Q.Range, Color.Magenta);
            }

            if (Main.Get<MenuCheckbox>("DrawE").Checked && E.IsReady())
            {
                Drawing.DrawCircle(ObjectManager.Player.Position, E.Range, Color.Cyan);
            }
        }
    }
}