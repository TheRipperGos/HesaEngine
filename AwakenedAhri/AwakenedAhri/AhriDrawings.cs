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
            
            Vector2 screenPosition = Drawing.WorldToScreen(Ahri.Position);
            Vector2 lanetextPosition = new Vector2(screenPosition.X - 45, screenPosition.Y + 60);
            
            if (Main.Get<MenuCheckbox>("DrawLT").Checked && Main.Get<MenuKeybind>("LT").Active)
            {
                Drawing.DrawText(lanetextPosition, Color.LimeGreen, "Laneclear: On");
            }
            
            if (Main.Get<MenuCheckbox>("DrawLT").Checked && !Main.Get<MenuKeybind>("LT").Active)
            {
                Drawing.DrawText(lanetextPosition, Color.Red, "Laneclear: Off");
            }
            
            Vector2 harasstextPosition = new Vector2(screenPosition.X - 38, screenPosition.Y + 75);
            
            if (Main.Get<MenuCheckbox>("DrawHT").Checked && Main.Get<MenuKeybind>("HT").Active)
            {
                Drawing.DrawText(harasstextPosition, Color.LimeGreen, "Harass: On");
            }
            
            if (Main.Get<MenuCheckbox>("DrawHT").Checked && !Main.Get<MenuKeybind>("HT").Active)
            {
                Drawing.DrawText(harasstextPosition, Color.Red, "Harass: Off");
            }
        }
    }
}