using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game7D2D.Class;
using Game7D2D.Perk;

namespace Game7D2D.Utilities
{
    public static class InitPerks
    {
        #region Strength
        public static List<Perks> StrengthPerkList = new List<Perks>
        {
            new Perks("Strength", "attstrength", 1, 10),
            new Perks("Boomstick","perkboomstick", 1, 5),
            new Perks("Pummel Pete","perkpummelpete", 1, 5),
            new Perks("Skull Crusher","perkskullcrusher", 1, 5),
            new Perks("Big and Fast","perkflurryofstrength", 1, 3),
            new Perks("Heavy Armor","perkheavyarmor", 1, 4),
            new Perks("Pack Mule","perkpackmule", 1, 5),
            new Perks("Master Chef","perkmasterchef", 1, 3),
            new Perks("Miner 69'er","perkminer69r", 1, 5),
            new Perks("Mother Lode","perkmotherlode", 1, 5)
        };
        #endregion

        #region Agility
        public static List<Perks> AgilityPerkList = new List<Perks>
        {
            new Perks("Agility", "attagility", 1, 10),
            new Perks("Archery","perkarchery", 1, 5),
            new Perks("Gunslinger","perkgunslinger", 1, 5),
            new Perks("Deep Cuts","perkdeepcuts", 1, 5),
            new Perks("Whirlwind","perkflurryofagility", 1, 3),
            new Perks("Run and Gun","perkrunandgun", 1, 3),
            new Perks("Light Armor","perklightarmor", 1, 4),
            new Perks("Parkour","perkparkour", 1, 4),
            new Perks("Hidden Strike","perkhiddenstrike", 1, 5),
            new Perks("From The Shadows","perkfromtheshadows", 1, 5)
        };
        #endregion

        #region Fortitude
        public static List<Perks> FortitudePerkList = new List<Perks>
        {
            new Perks("Fortitude", "attfortitude", 1, 10),
            new Perks("The Brawler","perkbrawler", 1, 5),
            new Perks("Machine Gunner","perkmachinegunner", 1, 5),
            new Perks("Lightning Hands","perkflurryoffortitude", 1, 3),
            new Perks("The Huntsman","perkthehuntsman", 1, 5),
            new Perks("Well Insulated","perkwellinsulated", 1, 3),
            new Perks("Living off the Land","perklivingofftheland", 1, 3),
            new Perks("Pain Tolerance","perkpaintolerance", 1, 5),
            new Perks("Healing Factor","perkhealingfactor", 1, 5),
            new Perks("Iron Gut","perkslowmetabolism", 1, 5),
            new Perks("Rule 1: Cardio","perkruleonecardio", 1, 3)
        };
        #endregion

        #region Perception
        public static List<Perks> PerceptionPerkList = new List<Perks>
        {
            new Perks("Perception", "attperception", 1, 10),
            new Perks("Dead Eye", "perkdeadeye", 1, 5),
            new Perks("Demolitions Expert", "perkdemolitionsexpert", 1, 5),
            new Perks("Spear Eye", "perkjavelinmaster", 1, 5),
            new Perks("Quick and Perceptive", "perkflurryofperception", 1, 3),
            new Perks("The Infiltrator", "perkinfiltrator", 1, 3),
            new Perks("Animal Tracker", "perkanimaltracker", 1, 3),
            new Perks("The Penetrator", "perkpenetrator", 1, 4),
            new Perks("Lucky Looter", "perkluckylooter", 1, 5),
            new Perks("Treasure Hunter", "perktreasurehunter", 1, 3),
            new Perks("Salvage Operations", "perksalvageoperations", 1, 5),
        };
        #endregion

        #region Intellect
        public static List<Perks> IntellectPerkList = new List<Perks>
        {
            new Perks("Intellect", "attintellect", 1, 10),
            new Perks("Electrocutioner", "perkelectrocutioner", 1, 5),
            new Perks("Robotics Inventor", "perkturrets", 1, 5),
            new Perks("Calculated Attack", "perkflurryofintellect", 1, 3),
            new Perks("Better Barter", "perkbetterbarter", 1, 5),
            new Perks("The Daring Adventurer", "perkdaringadventurer", 1, 4),
            new Perks("Charismatic Nature", "perkcharismaticnature", 1, 5),
            new Perks("Physician", "perkphysician", 1, 5),
            new Perks("Advanced Engineering", "perkadvancedengineering", 1, 5),
            new Perks("Grease Monkey", "perkgreasemonkey", 1, 5),
            new Perks("Lock Picking", "perklockpicking", 1, 3),
        };
        #endregion

        #region CraftingBook

        public static List<Perks> CraftingBooksList = new List<Perks>
        {
            new Perks("Harvesting Tools", "craftingharvestingtools", 1, 100),
            new Perks("Repair Tools", "craftingrepairtools", 1, 50),
            new Perks("Salvage Tools", "craftingsalvagetools", 1, 75),
            new Perks("Knuckles", "craftingknuckles", 1, 75),
            new Perks("Blades", "craftingblades", 1, 75),
            new Perks("Clubs", "craftingclubs", 1, 75),
            new Perks("Sledgehammers", "craftingsledgehammers", 1, 75),
            new Perks("Bows", "craftingbows", 1, 100),
            new Perks("Spears", "craftingspears", 1, 75),
            new Perks("Handguns", "craftinghandguns", 1, 100),
            new Perks("Shotguns", "craftingshotguns", 1, 100),
            new Perks("Rifles", "craftingrifles", 1, 100),
            new Perks("Machine Guns", "craftingmachineguns", 1, 100),
            new Perks("Explosives", "craftingexplosives", 1, 100),
            new Perks("Robotics", "craftingrobotics", 1, 100),
            new Perks("Armor", "craftingarmor", 1, 75),
            new Perks("Medical", "craftingmedical", 1, 75),
            new Perks("Food", "craftingfood", 1, 100),
            new Perks("Seeds", "craftingseeds", 1, 20),
            new Perks("Electrician", "craftingelectrician", 1, 100),
            new Perks("Traps", "craftingtraps", 1, 75),
            new Perks("Workstations", "craftingworkstations", 1, 75),
            new Perks("Vehicles", "craftingvehicles", 1, 100),
        };

        #endregion

        #region SkillBook DECIDED NOT TO DO SINCE IT'S EASY TO ACHIEVE VIA CREATIVE MENU

        //public static List<PerkBookSet> SkillBooksList = new List<PerkBookSet>
        //{
        //    TheArtOfMining,

        //};

        #region BookSet

        //public static PerkBookSet TheArtOfMining = new PerkBookSet("The Art of Mining", "perkartofminingcomplete",
        //    new List<SkillBook>
        //    {
        //        new SkillBook("perkartofminingluckystrike", false),
        //        new SkillBook("perkartofminingdiamondtools", false),
        //        new SkillBook("perkartofminingcoffee", false),
        //        new SkillBook("perkartofminingblackstrap", false),
        //        new SkillBook("perkartofminingpallets", false),
        //        new SkillBook("perkartofminingavalanche", false),
        //        new SkillBook("perkartofminingdamage", false),
        //    });

        //public static PerkBookSet TheAutomaticWeaponHandbook = new PerkBookSet("The Automatic Weapon Handbook", "perkautoweaponscomplete",
        //    new List<SkillBook>
        //    {
        //        new SkillBook("perkautoweaponsdamage", false),
        //        new SkillBook("perkautoweaponsuncontrolledburst", false),
        //        new SkillBook("perkautoweaponsmaintenance", false),
        //        new SkillBook("perkautoweaponsdrummag", false),
        //        new SkillBook("perkautoweaponsrecoil", false),
        //        new SkillBook("perkautoweaponsragdoll", false),
        //        new SkillBook("perkautoweaponsmachineguns", false),
        //    });

        //public static PerkBookSet BatterUp = new PerkBookSet("Batter Up!", "perkbatterupcomplete",
        //    new List<SkillBook>
        //    {
        //        new SkillBook("perkbatterupbighits", false),
        //        new SkillBook("perkbatterupstealingbases", false),
        //        new SkillBook("perkbatterupslowpitch", false),
        //        new SkillBook("perkbatterupknockdown", false),
        //        new SkillBook("perkbatterupmaintenance", false),
        //        new SkillBook("perkbatterupfoulballs", false),
        //        new SkillBook("perkbatterupmetalchain", false),
        //    });

        //public static PerkBookSet BarBrawler = new PerkBookSet("Bar Brawler", "perkbarbrawling8complete",
        //    new List<SkillBook>
        //    {
        //        new SkillBook("perkbarbrawling1basicmoves", false),
        //        new SkillBook("perkbarbrawling2dropabomb", false),
        //        new SkillBook("perkbarbrawling3killerinstinct", false),
        //        new SkillBook("perkbarbrawling4finishingmoves", false),
        //        new SkillBook("perkbarbrawling5adrenalinehealing", false),
        //        new SkillBook("perkbarbrawling6ragemode", false),
        //        new SkillBook("perkbarbrawling7boozedup", false),
        //    });

        //public static PerkBookSet TheFiremanAlmanac = new PerkBookSet("The Fireman's Almanac", "perkbarbrawling8complete",
        //    new List<SkillBook>
        //    {
        //        new SkillBook("perkbarbrawling1basicmoves", false),
        //        new SkillBook("perkbarbrawling2dropabomb", false),
        //        new SkillBook("perkbarbrawling3killerinstinct", false),
        //        new SkillBook("perkbarbrawling4finishingmoves", false),
        //        new SkillBook("perkbarbrawling5adrenalinehealing", false),
        //        new SkillBook("perkbarbrawling6ragemode", false),
        //        new SkillBook("perkbarbrawling7boozedup", false),
        //    });


        #endregion

        #endregion
    }
}
