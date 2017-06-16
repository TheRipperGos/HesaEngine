using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;

using static AwakenedAhri.AhriMenu;
using static AwakenedAhri.AhriCombo;
/*
using static AwakenedAhri.AhriLaneclear;
using static AwakenedAhri.AhriHarass;
*/
using static AwakenedAhri.AhriDrawings;

namespace AwakenedAhri
{
    public class AwakenedAhri : IScript
    {
        public string Author => "Romanov";
        public string Name => "AwakenedAhri";
        public string Version => "7.12";
        
        public static Spell Q, W, E, R;
        public static AIHeroClient Ahri => ObjectManager.Player;
        public static Orbwalker.OrbwalkerInstance MyOrb => Core.Orbwalker;
        
        public void OnInitialize()
        {
            Game.OnGameLoaded += LoadComplete;
        }
        
        private void LoadComplete()
        {
            if (ObjectManager.Player.Hero != Champion.Ahri) return;

            Chat.Print("Awakened Ahri by Romanov Loaded");

            SetMenu();
            SetSpells();
            SetDrawings();

            Game.OnUpdate += GameUpdate;
        }
        
        private void GameUpdate()
        {
            switch (MyOrb.ActiveMode)
            {
                case Orbwalker.OrbwalkingMode.Combo:
                    UseCombo();
                    break;
                /*
                case Orbwalker.OrbwalkingMode.LaneClear:
                    LaneExec();
                    break;
                case Orbwalker.OrbwalkingMode.Harass:
                    HarassExec();
                    break;
                */
            }
        }

        private void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 880, TargetSelector.DamageType.Magical);
            W = new Spell(SpellSlot.W, 700, TargetSelector.DamageType.Magical);
            E = new Spell(SpellSlot.E, 975, TargetSelector.DamageType.Magical);
            R = new Spell(SpellSlot.R, 450, TargetSelector.DamageType.Magical);

            Q.SetSkillshot(0.25f, 80f, 1700f, false, SkillshotType.SkillshotLine);
            E.SetSkillshot(0.25f, 80f, 1600f, true, SkillshotType.SkillshotLine);
        }
    }
}