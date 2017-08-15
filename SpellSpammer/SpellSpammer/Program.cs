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
        private static ComboBox QChampCheckBox;
        private static CheckBox WCheckBox;
        private static ComboBox WChampCheckBox;
        private static CheckBox ECheckBox;
        private static ComboBox EChampCheckBox;
        private static CheckBox RCheckBox;
        private static ComboBox RChampCheckBox;
        private static KeyBind KeyBind;

        static void Main()
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            menu = MainMenu.AddMenu("URF Spammer", "urf_spam");
            menu.AddLabel("THIS IS FOR SPAMMING SPELLS TICKED HERE\nTHERE'S NO LOGIC FOR ANY OF THEM\n\nUSE AT YOUR OWN RISK", 50);
            menu.AddSeparator();
            KeyBind = menu.Add("keybind", new KeyBind("Toggle spam key", true, KeyBind.BindTypes.PressToggle));
            menu.AddSeparator();
            QCheckBox = menu.Add("QSpam", new CheckBox("Spam Q", false));
            QChampCheckBox = menu.Add("QCastOn", new ComboBox("Q usage: ", 3, "On nearest champion", "On self", "On mouse position", "Just cast goddammit"));
            WCheckBox = menu.Add("WSpam", new CheckBox("Spam W", false));
            WChampCheckBox = menu.Add("WCastOn", new ComboBox("W usage: ", 3, "On nearest champion", "On self", "On mouse position", "Just cast goddammit"));
            ECheckBox = menu.Add("ESpam", new CheckBox("Spam E", false));
            EChampCheckBox = menu.Add("ECastOn", new ComboBox("E usage: ", 3, "On nearest champion", "On self", "On mouse position", "Just cast goddammit"));
            RCheckBox = menu.Add("RSpam", new CheckBox("Spam R", false));
            RChampCheckBox = menu.Add("RCastOn", new ComboBox("R usage: ", 3, "On nearest champion", "On self", "On mouse position", "Just cast goddammit"));

            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            if (!KeyBind.CurrentValue) return;

            if (QCheckBox.CurrentValue && Player.Instance.Spellbook.GetSpell(SpellSlot.Q).IsReady)
            {
                switch (QChampCheckBox.CurrentValue)
                {
                    case 0:
                        var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.Q).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                        if (nearestChamp != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.Q, nearestChamp);
                        }
                        break;
                    case 1:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.Q, Player.Instance);
                        break;
                    case 2:
                        var unitsByMouse =
                            EntityManager.Enemies.Where(
                                    x =>
                                        !x.IsDead &&
                                        x.Distance(Player.Instance.ServerPosition) <
                                        Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange && x.Distance(Game.CursorPos) < 200)
                                .OrderBy(x => x.Distance(Game.CursorPos));
                        if (unitsByMouse.FirstOrDefault(x => x is AIHeroClient) != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.Q, unitsByMouse.First(x => x is AIHeroClient));
                            break;
                        }
                        if (unitsByMouse.FirstOrDefault() != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.Q, unitsByMouse.First());
                            break;
                        }
                        Player.Instance.Spellbook.CastSpell(SpellSlot.Q, Game.CursorPos);
                        break;
                    case 3:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.Q);
                        break;
                }
            }
            if (WCheckBox.CurrentValue && Player.Instance.Spellbook.GetSpell(SpellSlot.W).IsReady)
            {
                switch (WChampCheckBox.CurrentValue)
                {
                    case 0:
                        var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                        if (nearestChamp != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.W, nearestChamp);
                        }
                        break;
                    case 1:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.W, Player.Instance);
                        break;
                    case 2:
                        var unitsByMouse =
                            EntityManager.Enemies.Where(
                                    x =>
                                        !x.IsDead &&
                                        x.Distance(Player.Instance.ServerPosition) <
                                        Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange && x.Distance(Game.CursorPos) < 200)
                                .OrderBy(x => x.Distance(Game.CursorPos));
                        if (unitsByMouse.FirstOrDefault(x => x is AIHeroClient) != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.W, unitsByMouse.First(x => x is AIHeroClient));
                            break;
                        }
                        if (unitsByMouse.FirstOrDefault() != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.W, unitsByMouse.First());
                            break;
                        }
                        Player.Instance.Spellbook.CastSpell(SpellSlot.W, Game.CursorPos);
                        break;
                    case 3:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.W);
                        break;
                }
            }
            if (ECheckBox.CurrentValue && Player.Instance.Spellbook.GetSpell(SpellSlot.E).IsReady)
            {
                switch (EChampCheckBox.CurrentValue)
                {
                    case 0:
                        var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.E).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                        if (nearestChamp != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.E, nearestChamp);
                        }
                        break;
                    case 1:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.E, Player.Instance);
                        break;
                    case 2:
                        var unitsByMouse =
                            EntityManager.Enemies.Where(
                                    x =>
                                        !x.IsDead &&
                                        x.Distance(Player.Instance.ServerPosition) <
                                        Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange && x.Distance(Game.CursorPos) < 200)
                                .OrderBy(x => x.Distance(Game.CursorPos));
                        if (unitsByMouse.FirstOrDefault(x => x is AIHeroClient) != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.E, unitsByMouse.First(x => x is AIHeroClient));
                            break;
                        }
                        if (unitsByMouse.FirstOrDefault() != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.E, unitsByMouse.First());
                            break;
                        }
                        Player.Instance.Spellbook.CastSpell(SpellSlot.E, Game.CursorPos);
                        break;
                    case 3:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.E);
                        break;
                }
            }
            if (RCheckBox.CurrentValue && Player.Instance.Spellbook.GetSpell(SpellSlot.R).IsReady)
            {
                switch (RChampCheckBox.CurrentValue)
                {
                    case 0:
                        var nearestChamp =
                        EntityManager.Heroes.Enemies.Where(
                                x => !x.IsDead && x.Distance(Player.Instance.ServerPosition) < Player.Instance.Spellbook.GetSpell(SpellSlot.R).SData.CastRange)
                            .OrderBy(x => x.Distance(Player.Instance.ServerPosition))
                            .FirstOrDefault();
                        if (nearestChamp != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.R, nearestChamp);
                        }
                        break;
                    case 1:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.R, Player.Instance);
                        break;
                    case 2:
                        var unitsByMouse =
                            EntityManager.Enemies.Where(
                                    x =>
                                        !x.IsDead &&
                                        x.Distance(Player.Instance.ServerPosition) <
                                        Player.Instance.Spellbook.GetSpell(SpellSlot.W).SData.CastRange && x.Distance(Game.CursorPos) < 200)
                                .OrderBy(x => x.Distance(Game.CursorPos));
                        if (unitsByMouse.FirstOrDefault(x => x is AIHeroClient) != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.R, unitsByMouse.First(x => x is AIHeroClient));
                            break;
                        }
                        if (unitsByMouse.FirstOrDefault() != null)
                        {
                            Player.Instance.Spellbook.CastSpell(SpellSlot.R, unitsByMouse.First());
                            break;
                        }
                        Player.Instance.Spellbook.CastSpell(SpellSlot.R, Game.CursorPos);
                        break;
                    case 3:
                        Player.Instance.Spellbook.CastSpell(SpellSlot.R);
                        break;
                }
            }
        }
    }
}
