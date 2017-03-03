using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace SpellSpammer
{
    class Program
    {
        private static Menu menu;
        private static CheckBox QCheckBox;
        private static CheckBox QChampCheckBox;
        private static CheckBox WCheckBox;
        private static CheckBox WChampCheckBox;
        private static CheckBox ECheckBox;
        private static CheckBox EChampCheckBox;
        private static CheckBox RCheckBox;
        private static CheckBox RChampCheckBox;
        private static Spell.SpellBase QSpell;
        private static Spell.SpellBase WSpell;
        private static Spell.SpellBase ESpell;
        private static Spell.SpellBase RSpell;

        static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            menu = MainMenu.AddMenu("URF Spammer", "urf_spam");
            menu.AddLabel("THIS IS FOR SPAMMING SPELLS TICKED HERE\nTHERE'S NO LOGIC FOR ANY OF THEM\n\nUSE AT YOUR OWN RISK");
            menu.AddLabel("If spell is targeted, check the checkbox for it to be cast on nearest champion position.\nOtherwise it will be cast on you.");
            QCheckBox = menu.Add("QSpam", new CheckBox("Spam Q (to nearest champion if targeted)", false));
            QChampCheckBox = menu.Add("QCastOn", new CheckBox("Cast Q on nearest champion", false));
            WCheckBox = menu.Add("WSpam", new CheckBox("Spam W (to nearest champion if targeted)", false));
            WChampCheckBox = menu.Add("WCastOn", new CheckBox("Cast W on nearest champion", false));
            ECheckBox = menu.Add("ESpam", new CheckBox("Spam E (to nearest champion if targeted)", false));
            EChampCheckBox = menu.Add("ECastOn", new CheckBox("Cast E on nearest champion", false));
            RCheckBox = menu.Add("RSpam", new CheckBox("Spam R (to nearest champion if targeted)", false));
            RChampCheckBox = menu.Add("RCastOn", new CheckBox("Cast R on nearest champion", false));

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (QCheckBox.CurrentValue && Player.Instance.Spellbook.CanUseSpell(SpellSlot.Q) == SpellState.Ready)
            {
                if (QChampCheckBox.CurrentValue)
                {
                    var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.Q).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                    if (nearestChamp != null)
                    {
                        Player.Instance.Spellbook.CastSpell(SpellSlot.Q, nearestChamp);
                    }
                }
                else
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.Q);
                }
            }
            if (WCheckBox.CurrentValue && Player.Instance.Spellbook.CanUseSpell(SpellSlot.W) == SpellState.Ready)
            {
                if (WChampCheckBox.CurrentValue)
                {
                    var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                    if (nearestChamp != null)
                    {
                        Player.Instance.Spellbook.CastSpell(SpellSlot.W, nearestChamp);
                    }
                }
                else
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.W);
                }
            }
            if (ECheckBox.CurrentValue && Player.Instance.Spellbook.CanUseSpell(SpellSlot.E) == SpellState.Ready)
            {
                if (EChampCheckBox.CurrentValue)
                {
                    var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.E).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                    if (nearestChamp != null)
                    {
                        Player.Instance.Spellbook.CastSpell(SpellSlot.E, nearestChamp);
                    }
                }
                else
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.E);
                }
            }
            if (RCheckBox.CurrentValue && Player.Instance.Spellbook.CanUseSpell(SpellSlot.R) == SpellState.Ready)
            {
                if (RChampCheckBox.CurrentValue)
                {
                    var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.R).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                    if (nearestChamp != null)
                    {
                        Player.Instance.Spellbook.CastSpell(SpellSlot.R, nearestChamp);
                    }
                }
                else
                {
                    Player.Instance.Spellbook.CastSpell(SpellSlot.R);
                }
            }
        }
    }
}
