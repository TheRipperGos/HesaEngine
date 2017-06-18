using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;

using static AwakenedGragas.GragasMenu;
using static AwakenedGragas.GragasCombo;
using static AwakenedGragas.GragasLaneclear;
using static AwakenedGragas.GragasJungleclear;
using static AwakenedGragas.GragasHarass;
using static AwakenedGragas.GragasDrawings;
using static AwakenedGragas.GragasKillsteal;
using static AwakenedGragas.GragasInsec;

namespace AwakenedGragas
{
    
    public class AwakenedGragas : IScript
    {
        public string Author => "Romanov";
        public string Name => "AwakenedGragas";
        public string Version => "7.12";
        public static Spell Q, W, E, R;
        public static AIHeroClient Gragas => ObjectManager.Player;
        public static Orbwalker.OrbwalkerInstance MyOrb => Core.Orbwalker;
        
        public void OnInitialize()
        {
            Game.OnGameLoaded += LoadComplete;
        }
        
        private void LoadComplete()
        {
            if (ObjectManager.Player.Hero != Champion.Gragas) return;

            Chat.Print("Awakened Gragas " + Version);

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
                    
                case Orbwalker.OrbwalkingMode.LaneClear:
                    UseLaneclear();
                    break;
                
                case Orbwalker.OrbwalkingMode.JungleClear:
                    UseJungleclear();
                    break;
                
                case Orbwalker.OrbwalkingMode.Harass:
                    UseHarass();
                    break;
            }

            UseKillsteal();
            UseInsec();
        }

        private void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 850, TargetSelector.DamageType.Magical);
            W = new Spell(SpellSlot.W, 125, TargetSelector.DamageType.Magical);
            E = new Spell(SpellSlot.E, 600, TargetSelector.DamageType.Magical);
            R = new Spell(SpellSlot.R, 1000, TargetSelector.DamageType.Magical);

            Q.SetSkillshot(0.25f, 110f, 1000f, false, SkillshotType.SkillshotCircle);
            E.SetSkillshot(0.25f, 50f, 900f, true, SkillshotType.SkillshotLine);
            R.SetSkillshot(0.25f, 120f, 1000f, false, SkillshotType.SkillshotCircle);
        }
    }
}