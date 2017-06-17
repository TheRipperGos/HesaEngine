using HesaEngine.SDK;
using SharpDX.DirectInput;

namespace AwakenedAhri
{
    public class AhriMenu
    {
        public static Menu Main;

        public static void SetMenu()
        {
            Main = Menu.AddMenu("Awakened Ahri");

            var combo = Main.AddSubMenu("Combo Settings");
            combo.Add(new MenuCheckbox("CQ", "[Q] Orb of Deception", true));
            combo.Add(new MenuCheckbox("CW", "[W] Fox-Fire", true));
            combo.Add(new MenuCheckbox("CE", "[E] Charm", true));
            combo.Add(new MenuCheckbox("CR", "[R] Spirit Rush", true));
            combo.Add(new MenuSeparator("Manual [R] Start"));
            combo.Add(new MenuSeparator("Improvements Soon™"));
            
            var laneClear = Main.AddSubMenu("Laneclear Settings");
            laneClear.Add(new MenuKeybind("LT", "Hotkey Toggle", Key.A, MenuKeybindType.Toggle));
            laneClear.Add(new MenuCheckbox("LQ", "[Q] Orb of Deception", true));
            laneClear.Add(new MenuCheckbox("LW", "[W] Fox-Fire", true));
            laneClear.Add(new MenuSlider("LMin", "Min Minions to Clear", 1, 7, 5));
            laneClear.Add(new MenuSlider("LMana", "Min Mana [%] to Laneclear", 0, 100, 40));
            
            var harass = Main.AddSubMenu("Harass Settings");
            harass.Add(new MenuKeybind("HT", "Hotkey Toggle", Key.S, MenuKeybindType.Toggle));
            harass.Add(new MenuCheckbox("HQ", "[Q] Orb of Deception", true));
            harass.Add(new MenuCheckbox("HW", "[W] Fox-Fire", true));
            harass.Add(new MenuCheckbox("HE", "[E] Charm", true));
            harass.Add(new MenuSlider("HMana", "Min Mana [%] to Harass", 0, 100, 60));

            var killsteal = Main.AddSubMenu("Killsteal Settings");
            killsteal.Add(new MenuCheckbox("KSQ", "[Q] Orb of Deception", true));
            killsteal.Add(new MenuCheckbox("KSE", "[E] Charm", true));
            
            var draw = Main.AddSubMenu("Draw Settings");
            draw.Add(new MenuCheckbox("DrawQ", "Draw [Q] Range", true));
            draw.Add(new MenuCheckbox("DrawE", "Draw [E] Range", true));
            draw.Add(new MenuCheckbox("DrawLT", "Draw Laneclear Toggle", true));
            draw.Add(new MenuCheckbox("DrawHT", "Draw Harass Toggle", true));
        }
    }
}