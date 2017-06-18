using HesaEngine.SDK;
using SharpDX.DirectInput;

namespace AwakenedTwitch
{
    public class TwitchMenu
    {
        public static Menu Main;

        public static void SetMenu()
        {
            Main = Menu.AddMenu("Awakened Twitch");

            var combo = Main.AddSubMenu("Combo Settings");
            combo.Add(new MenuCheckbox("CQ", "[Q] Ambush", true));
            combo.Add(new MenuCheckbox("CW", "[W] Venom Cask", true));
            combo.Add(new MenuCheckbox("CE", "[E] Contaminate", true));
            combo.Add(new MenuCheckbox("CR", "[R] Spray And Pray", true));
            
            var laneClear = Main.AddSubMenu("Laneclear Settings");
            laneClear.Add(new MenuKeybind("LT", "Hotkey Toggle", Key.A, MenuKeybindType.Toggle));
            laneClear.Add(new MenuCheckbox("LW", "[W] Venom Cask", true));
            laneClear.Add(new MenuCheckbox("LE", "[E] Contaminate", true));
            laneClear.Add(new MenuSlider("LMin", "Min Minions to Clear", 1, 7, 5));
            laneClear.Add(new MenuSlider("LMana", "Min Mana [%] to Laneclear", 0, 100, 40));

            var jungleClear = Main.AddSubMenu("Jungleclear Settings");
            jungleClear.Add(new MenuKeybind("JT", "Hotkey Toggle", Key.J, MenuKeybindType.Toggle));
            jungleClear.Add(new MenuCheckbox("JW", "[W] Venom Cask", true));
            jungleClear.Add(new MenuCheckbox("JE", "[E] Contaminate", true));
            jungleClear.Add(new MenuSlider("JMana", "Min Mana [%] to Laneclear", 0, 100, 40));
            
            var harass = Main.AddSubMenu("Harass Settings");
            harass.Add(new MenuKeybind("HT", "Hotkey Toggle", Key.S, MenuKeybindType.Toggle));
            harass.Add(new MenuCheckbox("HW", "[W] Venom Cask", true));
            harass.Add(new MenuSlider("HMana", "Min Mana [%] to Harass", 0, 100, 60));

            var killsteal = Main.AddSubMenu("Killsteal Settings");
            killsteal.Add(new MenuCheckbox("KSE", "[E] Contaminate", true));
            
            var draw = Main.AddSubMenu("Draw Settings");
            draw.Add(new MenuCheckbox("DrawW", "Draw [W] Range", true));
            draw.Add(new MenuCheckbox("DrawE", "Draw [E] Range", true));
            draw.Add(new MenuCheckbox("DrawR", "Draw [R] Range", true));
            draw.Add(new MenuCheckbox("DrawLT", "Draw Laneclear Toggle", true));
            draw.Add(new MenuCheckbox("DrawJT", "Draw Jungleclear Toggle", true));
            draw.Add(new MenuCheckbox("DrawHT", "Draw Harass Toggle", true));
        }
    }
}