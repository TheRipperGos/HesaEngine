using HesaEngine.SDK;
using SharpDX.DirectInput;

namespace AwakenedGragas
{
    public class GragasMenu
    {
        public static Menu Main;

        public static void SetMenu()
        {
            Main = Menu.AddMenu("Awakened Gragas");

            var combo = Main.AddSubMenu("Combo Settings");
            combo.Add(new MenuCheckbox("CQ", "[Q] Barrel Roll", true));
            combo.Add(new MenuCheckbox("CW", "[W] Drunken Rage", true));
            combo.Add(new MenuCheckbox("CE", "[E] Body Slam", true));
            combo.Add(new MenuCheckbox("CR", "[R] Explosive Cask", true));
            combo.Add(new MenuSeparator("Smart [R] Combo when Killable"));
            
            var laneClear = Main.AddSubMenu("Laneclear Settings");
            laneClear.Add(new MenuKeybind("LT", "Hotkey Toggle", Key.A, MenuKeybindType.Toggle));
            laneClear.Add(new MenuCheckbox("LQ", "[Q] Barrel Roll", true));
            laneClear.Add(new MenuCheckbox("LW", "[W] Drunken Rage", true));
            laneClear.Add(new MenuSlider("LMin", "Min Minions to Clear", 1, 7, 5));
            laneClear.Add(new MenuSlider("LMana", "Min Mana [%] to Laneclear", 0, 100, 40));

            var jungleClear = Main.AddSubMenu("Jungleclear Settings");
            jungleClear.Add(new MenuKeybind("JT", "Hotkey Toggle", Key.J, MenuKeybindType.Toggle));
            jungleClear.Add(new MenuCheckbox("JQ", "[Q] Barrel Roll", true));
            jungleClear.Add(new MenuCheckbox("JW", "[W] Drunken Rage", true));
            jungleClear.Add(new MenuSlider("JMana", "Min Mana [%] to Laneclear", 0, 100, 40));
            
            var harass = Main.AddSubMenu("Harass Settings");
            harass.Add(new MenuKeybind("HT", "Hotkey Toggle", Key.S, MenuKeybindType.Toggle));
            harass.Add(new MenuCheckbox("HQ", "[Q] Barrel Roll", true));
            harass.Add(new MenuSlider("HMana", "Min Mana [%] to Harass", 0, 100, 60));

            var killsteal = Main.AddSubMenu("Killsteal Settings");
            killsteal.Add(new MenuCheckbox("KSQ", "[Q] Barrel Roll", true));
            killsteal.Add(new MenuCheckbox("KSE", "[E] Body Slam", true));
            killsteal.Add(new MenuCheckbox("KSR", "[R] Explosive Cask", true));
            
            var insec = Main.AddSubMenu("Insec Settings");
            insec.Add(new MenuKeybind("IK", "Insec Key", Key.T));
            insec.Add(new MenuCheckbox("IR", "Enable [R] Insec"));
            
            var draw = Main.AddSubMenu("Draw Settings");
            draw.Add(new MenuCheckbox("DrawQ", "Draw [Q] Range", true));
            draw.Add(new MenuCheckbox("DrawE", "Draw [E] Range", true));
            draw.Add(new MenuCheckbox("DrawR", "Draw [R] Range", true));
            draw.Add(new MenuCheckbox("DrawLT", "Draw Laneclear Toggle", true));
            draw.Add(new MenuCheckbox("DrawJT", "Draw Jungleclear Toggle", true));
            draw.Add(new MenuCheckbox("DrawHT", "Draw Harass Toggle", true));
        }
    }
}