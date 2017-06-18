using HesaEngine.SDK;
using HesaEngine.SDK.Enums;
using HesaEngine.SDK.GameObjects;

using static AwakenedTwitch.TwitchMenu;
using static AwakenedTwitch.TwitchCombo;
using static AwakenedTwitch.TwitchLaneclear;
using static AwakenedTwitch.TwitchJungleclear;
using static AwakenedTwitch.TwitchHarass;
using static AwakenedTwitch.TwitchDrawings;
using static AwakenedTwitch.TwitchKillsteal;

namespace AwakenedTwitch
{
    public class AwakenedTwitch : IScript
    {
        public string Author => "Romanov";
        public string Name => "AwakenedTwitch";
        public string Version => "7.12";
        
        public static Spell Q, W, E, R;
        public static AIHeroClient Twitch => ObjectManager.Player;
        public static Orbwalker.OrbwalkerInstance MyOrb => Core.Orbwalker;
        
        public void OnInitialize()
        {
            Game.OnGameLoaded += LoadComplete;
        }
        
        private void LoadComplete()
        {
            if (ObjectManager.Player.Hero != Champion.Twitch) return;

            Chat.Print("Awakened Twitch");

            SetMenu();
            SetSpells();
            SetDrawings();

            Game.OnUpdate += GameUpdate;
            Orbwalker.AfterAttack += Orbwalking_AfterAttack;
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
        }

        private void Orbwalking_AfterAttack(AttackableUnit unit, AttackableUnit argsTarget)
        {
            if (!unit.IsMe || unit.IsDead || argsTarget == null || argsTarget.IsDead || !argsTarget.IsValidTarget() ||  
                argsTarget.ObjectType != GameObjectType.AIHeroClient) return;
            
            if (Main.Get<MenuCheckbox>("CQ").Checked && Q.IsReady() && 
                MyOrb.ActiveMode == Orbwalker.OrbwalkingMode.Combo)
            {
                Q.Cast();
            }
        }

        private void SetSpells()
        {
            Q = new Spell(SpellSlot.Q, 550);
            W = new Spell(SpellSlot.W, 950);
            E = new Spell(SpellSlot.E, 1200);
            R = new Spell(SpellSlot.R, 850);
            
            W.SetSkillshot(0.25f, 100f, 1400f, false, SkillshotType.SkillshotCircle);
        }
    }
}