using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace CaitlynTheTroll
{
    internal static class CaitlynTheTrollMeNu
    {
        private static Menu _myMenu;
        public static Menu ComboMenu, DrawMeNu, HarassMeNu, Activator, FarmMeNu, MiscMeNu;

        public static void LoadMenu()
        {
            MyCaitlynTheTrollPage();
            DrawMeNuPage();
            ComboMenuPage();
            FarmMeNuPage();
            HarassMeNuPage();
            ActivatorPage();
            MiscMeNuPage();
        }

        private static void MyCaitlynTheTrollPage()
        {
            _myMenu = MainMenu.AddMenu("Caitlyn The Troll", "main");
            _myMenu.AddLabel(" Caitlyn The Troll " + Program.Version);
            _myMenu.AddLabel(" Made by MeLoDag");
        }

        private static void DrawMeNuPage()
        {
            DrawMeNu = _myMenu.AddSubMenu("Draw  settings", "Draw");
            DrawMeNu.AddGroupLabel("G�sterge Ayarlar�:");
            DrawMeNu.Add("nodraw",
                new CheckBox("Bi�ey g�sterme", false));
          DrawMeNu.AddSeparator();
            DrawMeNu.Add("draw.Q",
                new CheckBox("G�ster Q"));
            DrawMeNu.Add("draw.W",
                new CheckBox("G�ster W"));
            DrawMeNu.Add("draw.E",
                new CheckBox("G�ster E"));
            DrawMeNu.Add("draw.R",
                new CheckBox("G�ster R"));
          }

        private static void ComboMenuPage()
        {
            ComboMenu = _myMenu.AddSubMenu("Combo settings", "Combo");
            ComboMenu.AddGroupLabel("Combo Ayarlar�:");
            ComboMenu.AddLabel("Q Kullan");
            foreach (var enemies in EntityManager.Heroes.Enemies.Where(i => !i.IsMe))
            {
                ComboMenu.Add("combo.Q" + enemies.ChampionName, new CheckBox("" + enemies.ChampionName));
            }
            ComboMenu.AddSeparator();
            ComboMenu.Add("combo.E",
                new CheckBox("Kullan E"));
            ComboMenu.Add("combo.w",
                new CheckBox("Kullan W"));
          ComboMenu.Add("combo.R",
                new CheckBox("Kullan R"));
            ComboMenu.AddSeparator();
            ComboMenu.AddGroupLabel("Kombo �zellikelri:");
           ComboMenu.Add("comboEQbind",
                new KeyBind("Kullan E + Q B�y�leri", false, KeyBind.BindTypes.HoldActive, 'Z'));
            ComboMenu.Add("combo.CC",
                new CheckBox("Kullan E CC"));
            ComboMenu.Add("combo.CCQ",
                new CheckBox("Kullan Q CC"));
            ComboMenu.Add("combo.CCW",
               new CheckBox("Kullan W CC"));
            ComboMenu.Add("combo.REnemies",
                new Slider("R i�in en az d��man", 1, 0, 5));
        }


        private static void FarmMeNuPage()
        {
            FarmMeNu = _myMenu.AddSubMenu("Lane Clear Settings", "laneclear");
            FarmMeNu.AddGroupLabel("Lane Temizleme Ayarlar�:");
            FarmMeNu.Add("Lane.Q",
                new CheckBox("Kullan Q"));
            FarmMeNu.Add("LaneMana",
                new Slider("Lanetemizleme i�in en az mana %", 60));
            FarmMeNu.AddSeparator();
            FarmMeNu.AddGroupLabel("Orman Ayarlar�");
            FarmMeNu.Add("jungle.Q",
                new CheckBox("Kullan Q"));
        }

        private static void HarassMeNuPage()
        {
            HarassMeNu = _myMenu.AddSubMenu("Harass/Killsteal Settings", "hksettings");
            HarassMeNu.AddGroupLabel("D�rtme Ayarlar�:");
            HarassMeNu.AddSeparator();
            HarassMeNu.AddLabel("Q Kullan");
            foreach (var enemies in EntityManager.Heroes.Enemies.Where(i => !i.IsMe))
            {
                HarassMeNu.Add("Harass.Q" + enemies.ChampionName, new CheckBox("" + enemies.ChampionName));
            }
            HarassMeNu.Add("harass.QE",
                new Slider("D�rtme i�in mana %", 55));
            HarassMeNu.AddSeparator();
            HarassMeNu.AddGroupLabel("Kill�alma ayarlar�:");
            HarassMeNu.Add("killsteal.Q",
                new CheckBox("Kullan Q", false));
        }

        private static void ActivatorPage()
        {
            Activator = _myMenu.AddSubMenu("Activator Settings", "Items");
            Activator.AddGroupLabel("Auto QSS if :");
            Activator.Add("Blind",
                new CheckBox("K�r", false));
            Activator.Add("Charm",
                new CheckBox("�ekiliyorsa(ahri)"));
            Activator.Add("Fear",
                new CheckBox("Korkmu�sa"));
            Activator.Add("Polymorph",
                new CheckBox("Polymorph"));
            Activator.Add("Stun",
                new CheckBox("Sabitlenmi�se"));
            Activator.Add("Snare",
                new CheckBox("Tuza�a d���nce"));
            Activator.Add("Silence",
                new CheckBox("Sustutulduysa", false));
            Activator.Add("Taunt",
                new CheckBox("Alay ediliyorsa"));
            Activator.Add("Suppression",
                new CheckBox("Durdurulmu�sa"));
            Activator.AddGroupLabel("Item Kullan�m�:");
            Activator.AddSeparator();
       Activator.Add("bilgewater",
                new CheckBox("Bilgewater palas� Kullan"));
            Activator.Add("bilgewater.HP",
                new Slider("Kullanmak i�in can {0}(%)", 60));
            Activator.AddSeparator();
            Activator.Add("botrk",
                new CheckBox("Mahvolmu� k�l�c� kullan"));
            Activator.Add("botrk.HP",
                new Slider("mahvolmu� i�in can {0}(%)", 60));
            Activator.AddSeparator();
            Activator.Add("youmus",
                new CheckBox("Kullan Youmus"));
            Activator.Add("items.Youmuss.HP",
                new Slider("Youumu i�in can {0}(%)", 60, 1));
            Activator.Add("youmus.Enemies",
                new Slider("Youumu i�in ka� d��man menzilde olsun", 3, 1, 5));
            Activator.AddSeparator();
            Activator.AddGroupLabel("�ksir Ayarlar�");
            Activator.Add("spells.Potions.Check",
                new CheckBox("Kullan �ksirler"));
            Activator.Add("spells.Potions.HP",
                new Slider("Can�m �undan azsa {0}(%)", 60, 1));
            Activator.Add("spells.Potions.Mana",
                new Slider("Manam �undan azsa {0}(%)", 60, 1));
            Activator.AddSeparator();
            Activator.AddGroupLabel("B�y� Ayarlar�:");
            Activator.AddGroupLabel("Bariyer Ayarlar�:");
            Activator.Add("spells.Barrier.Hp",
                new Slider("Bariyer kullanmak i�in gereken can {0}(%)", 30, 1));
            Activator.AddGroupLabel("�yile�tirme Ayarlar�:");
            Activator.Add("spells.Heal.Hp",
                new Slider("�yile�tirme i�in gereken can {0}(%)", 30, 1));
            Activator.AddGroupLabel("Tutu�tur Ayarlar�:");
            Activator.Add("spells.Ignite.Focus",
                new Slider("Tutu�tur kullanmak i�in hedefin can� {0}(%)", 10, 1));
        }

        private static void MiscMeNuPage()
        {
            MiscMeNu = _myMenu.AddSubMenu("Misc Menu", "othermenu");
            MiscMeNu.AddGroupLabel("Ka�ma ayarlar�");
            MiscMeNu.Add("useEmouse",
                new KeyBind("Kullan E Fareye do�ru", false, KeyBind.BindTypes.HoldActive, "T".ToCharArray()[0]));
            MiscMeNu.AddGroupLabel("Anti Gap Closer/Interrupt");
            MiscMeNu.Add("gapcloser.E",
                new CheckBox("Kullan E GapCloser"));
            MiscMeNu.Add("gapcloser.W",
                new CheckBox("Kullan W GapCloser"));
            MiscMeNu.Add("interupt.W",
              new CheckBox("Kullan W Interrupt"));
            MiscMeNu.AddSeparator();
            MiscMeNu.AddGroupLabel("Kost�m Ayarlar�");
            MiscMeNu.Add("checkSkin",
                new CheckBox("Kost�m De�i�trici:", false));
            MiscMeNu.Add("skin.Id",
                new Slider("Kost�m De�i�tir", 5, 0, 10));
        }

        public static bool Nodraw()
        {
            return DrawMeNu["nodraw"].Cast<CheckBox>().CurrentValue;
        }
        
        public static bool DrawingsQ()
        {
            return DrawMeNu["draw.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsW()
        {
            return DrawMeNu["draw.W"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsE()
        {
            return DrawMeNu["draw.E"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsR()
        {
            return DrawMeNu["draw.R"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsT()
        {
            return DrawMeNu["draw.T"].Cast<CheckBox>().CurrentValue;
        }

        public static bool ComboE()
        {
            return ComboMenu["combo.E"].Cast<CheckBox>().CurrentValue;
        }

        public static bool ComboW()
        {
            return ComboMenu["combo.W"].Cast<CheckBox>().CurrentValue;
        }
        public static float ComboREnemies()
        {
            return ComboMenu["combo.REnemies"].Cast<Slider>().CurrentValue;
        }
        public static bool ComboR()
        {
            return ComboMenu["combo.R"].Cast<CheckBox>().CurrentValue;
        }
        public static bool ComboEq()
        {
            return ComboMenu["comboEQbind"].Cast<KeyBind>().CurrentValue;
        }
       public static bool LaneQ()
        {
            return FarmMeNu["lane.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static float LaneMana()
        {
            return FarmMeNu["LaneMana"].Cast<Slider>().CurrentValue;
        }

        public static bool JungleQ()
        {
            return FarmMeNu["jungle.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static bool HarassQ()
        {
            return HarassMeNu["harass.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static float HarassQe()
        {
            return HarassMeNu["harass.QE"].Cast<Slider>().CurrentValue;
        }

        public static bool KillstealQ()
        {
            return HarassMeNu["killsteal.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Bilgewater()
        {
            return Activator["bilgewater"].Cast<CheckBox>().CurrentValue;
        }

        public static float BilgewaterHp()
        {
            return Activator["bilgewater.HP"].Cast<Slider>().CurrentValue;
        }

        public static bool Botrk()
        {
            return Activator["botrk"].Cast<CheckBox>().CurrentValue;
        }

        public static float BotrkHp()
        {
            return Activator["botrk.HP"].Cast<Slider>().CurrentValue;
        }

        public static bool Youmus()
        {
            return Activator["youmus"].Cast<CheckBox>().CurrentValue;
        }
        public static float YoumusEnemies()
        {
            return Activator["youmus.Enemies"].Cast<Slider>().CurrentValue;
        }

        public static float ItemsYoumuShp()
        {
            return Activator["items.Youmuss.HP"].Cast<Slider>().CurrentValue;
        }

        public static bool SpellsPotionsCheck()
        {
            return Activator["spells.Potions.Check"].Cast<CheckBox>().CurrentValue;
        }

        public static float SpellsPotionsHp()
        {
            return Activator["spells.Potions.HP"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsPotionsM()
        {
            return Activator["spells.Potions.Mana"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsHealHp()
        {
            return Activator["spells.Heal.HP"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsIgniteFocus()
        {
            return Activator["spells.Ignite.Focus"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsBarrierHp()
        {
            return Activator["spells.Barrier.Hp"].Cast<Slider>().CurrentValue;
        }

        public static bool Blind()
        {
            return Activator["Blind"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Charm()
        {
            return Activator["Charm"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Fear()
        {
            return Activator["Fear"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Polymorph()
        {
            return Activator["Polymorph"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Stun()
        {
            return Activator["Stun"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Snare()
        {
            return Activator["Snare"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Silence()
        {
            return Activator["Silence"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Taunt()
        {
            return Activator["Taunt"].Cast<CheckBox>().CurrentValue;
        }

        public static bool Suppression()
        {
            return Activator["Suppression"].Cast<CheckBox>().CurrentValue;
        }

        public static int SkinId()
        {
            return MiscMeNu["skin.Id"].Cast<Slider>().CurrentValue;
        }

        public static bool GapcloserE()
        {
            return MiscMeNu["gapcloser.E"].Cast<CheckBox>().CurrentValue;
        }

        public static bool GapcloserW()
        {
            return MiscMeNu["gapcloser.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool InterupteW()
        {
            return MiscMeNu["interupt.W"].Cast<CheckBox>().CurrentValue;
        }

        public static bool SkinChanger()
        {
            return MiscMeNu["SkinChanger"].Cast<CheckBox>().CurrentValue;
        }

        public static bool CheckSkin()
        {
            return MiscMeNu["checkSkin"].Cast<CheckBox>().CurrentValue;
        }

        public static bool UseEmouse()
        {
            return MiscMeNu["useEmouse"].Cast<KeyBind>().CurrentValue;
        }
    }
}